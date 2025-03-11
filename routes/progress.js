const express = require("express");
const GameProgress = require("../models/GameProgress");

const router = express.Router();

// Update game progress
router.post("/update", async (req, res) => {
  try {
    const { userId, gameId, score, completedLevels } = req.body;

    let progress = await GameProgress.findOne({ userId, gameId });

    if (!progress) {
      progress = new GameProgress({ userId, gameId, score, completedLevels });
    } else {
      // Update progress if score is higher or new levels are completed
      progress.score = Math.max(progress.score, score);
      progress.completedLevels = [...new Set([...progress.completedLevels, ...completedLevels])];
    }

    await progress.save();
    res.json({ message: "Progress updated", progress });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

module.exports = router;