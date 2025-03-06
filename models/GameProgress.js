const mongoose = require("mongoose");

const GameProgressSchema = new mongoose.Schema({
  userId: { type: mongoose.Schema.Types.ObjectId, ref: "User" },
  gameId: { type: String, required: true },
  score: { type: Number, default: 0 },
  completedLevels: [Number],
}, { timestamps: true });

module.exports = mongoose.model("GameProgress", GameProgressSchema);
