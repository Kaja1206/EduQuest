const express = require("express");
const bcrypt = require("bcryptjs");
const jwt = require("jsonwebtoken");
const User = require("../models/User");
const { body, validationResult } = require("express-validator");

const router = express.Router();

// Register User
router.post(
  "/register",
  [
    body("name").notEmpty(),
    body("email").isEmail(),
    body("password").isLength({ min: 8 }),
  ],
  async (req, res) => {
    // Validate input
    const errors = validationResult(req);
    if (!errors.isEmpty())
      return res.status(400).json({ errors: errors.array() });

    try {
      const { name, email, password } = req.body;

      // Check if user already exists
      let user = await User.findOne({ email });
      if (user) return res.status(400).json({ message: "User already exists" });

      // Hash password
      const hashedPassword = await bcrypt.hash(password, 10);

      // Create new user
      user = new User({ name, email, password: hashedPassword });
      await user.save();

      res.status(201).json({ message: "User registered successfully" });
    } catch (err) {
      res.status(500).json({ message: "Server error" });
    }
  }
);

//Login User
router.post("/login", async (req, res) => {
  try {
    const { email, password } = req.body;

    // Check if user exists
    let user = await User.findOne({ email });
    if (!user) return res.status(400).json({ message: "Invalid credentials" });

    const isMatch = await bcrypt.compare(password, user.password);
    if (!isMatch)
      return res.status(400).json({ message: "Invalid credentials" });

    // Create JWT token
    const token = jwt.sign({ id: user._id }, process.env.JWT_SECRET, {
      expiresIn: "7d",
    });

    res.cookie("token", token, {
      httpOnly: true, // Important for security
      secure: process.env.NODE_ENV === "production", // Set secure for production
      sameSite: "Strict", // CSRF protection
    });

    res.json({ message: "User logged in successfully" });
  } catch (err) {
    res.status(500).json({ message: "Server error" });
  }
});

const authenticateUser = require("./middleware/authMiddleware");

//Protected Routes
router.get("/profile", authenticateUser, async (req, res) => {
  try {
    const user = await User.findById(req.user.id).select("-password"); // Exclude password
    res.json(user);
  } catch (err) {
    res.status(500).json({ message: "Server error" });
  }
});

// Logout User
router.post("/logout", (req, res) => {
  res.clearCookie("token", {
    httpOnly: true,
    secure: process.env.NODE_ENV === "production",
    sameSite: "Strict",
  });
  res.json({ message: "Logged out successfully" });
});

module.exports = router;
