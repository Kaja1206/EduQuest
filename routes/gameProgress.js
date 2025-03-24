const express = require("express");
const GameSession = require("../models/GameSession");
const GameProgress = require("../models/GameProgress");
const authenticateUser = require("../middleware/authMiddleware"); // Authentication middleware
const router = express.Router();

// POST API to save/update game progress
router.post("/game-progress", authenticateUser, async (req, res) => {
  const { grade, subject, progress } = req.body; // Get game data from the request body
  const userId = req.user.id; // Get user ID from the JWT token

  try {
    // Check if the progress record exists for the specific user, grade, and subject
    let gameProgress = await GameProgress.findOne({ userId, grade, subject });

    if (gameProgress) {
      // If a record exists, update it
      gameProgress.progress = progress; // Set the new progress
      gameProgress.lastPlayed = Date.now(); // Update the timestamp
      await gameProgress.save();
    } else {
      // If no record exists, create a new one
      gameProgress = new GameProgress({
        userId,
        grade,
        subject,
        progress,
      });
      await gameProgress.save();
    }

    res.status(200).json({ message: "Progress saved successfully" });
  } catch (err) {
    res.status(500).json({ message: "Error saving progress", error: err });
  }
});

// GET API to fetch the game progress
router.get("/game-progress", authenticateUser, async (req, res) => {
  const { grade, subject } = req.query; // Get grade and subject from query parameters
  const userId = req.user.id; // Get user ID from the JWT token

  try {
    // Find the game progress for the user, grade, and subject
    const gameProgress = await GameProgress.findOne({ userId, grade, subject });

    if (!gameProgress) {
      return res.status(404).json({ message: "No progress found" });
    }

    res.status(200).json(gameProgress); // Send back the progress data
  } catch (err) {
    res.status(500).json({ message: "Error fetching progress", error: err });
  }
});

// POST: Save Game Session
router.post("/save-session", verifyToken, async (req, res) => {
  try {
    const { grade, subject, score, progress, timeSpent } = req.body;
    const userId = req.user.id;

    const newSession = new GameSession({
      userId,
      grade,
      subject,
      score,
      progress,
      timeSpent,
    });

    await newSession.save();
    res.json({ message: "Session saved!", session: newSession });
  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Server error" });
  }
});

// GET: Fetch All Sessions for a Child
router.get("/sessions", verifyToken, async (req, res) => {
  try {
    const userId = req.user.id;
    const sessions = await GameSession.find({ userId }).sort({ playedAt: -1 });

    res.json(sessions);
  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Server error" });
  }
});

module.exports = router;
