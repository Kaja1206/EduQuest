const mongoose = require("mongoose");

const gameProgressSchema = new mongoose.Schema({
  userId: { type: mongoose.Schema.Types.ObjectId, ref: "User", required: true },
  grade: { type: Number, required: true }, // Grade (1-4)
  subject: { type: String, required: true }, // Subject (e.g., Math, Science)
  progress: { type: Number, default: 0 }, // The progress, could be points or percentage
  lastPlayed: { type: Date, default: Date.now }, // Timestamp of last played session
});

module.exports = mongoose.model("GameProgress", gameProgressSchema);
