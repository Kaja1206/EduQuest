const mongoose = require("mongoose");

const UserSchema = new mongoose.Schema({
  username: { type: String, required: true, unique: true },
  email: { type: String, required: true, unique: true },
  password: { type: String, required: true },
  grade: { type: Number, required: true }, // Grade 1-4
  progress: [
    {
      gameId: String,       // The ID of the game played
      score: Number,        // Score obtained
      completedLevels: [Number], // List of levels completed
    }
  ],
}, { timestamps: true });

module.exports = mongoose.model("User", UserSchema);
