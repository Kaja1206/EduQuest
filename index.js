require("dotenv").config();
const express = require("express");
const mongoose = require("mongoose");
const cors = require("cors");
const cookieParser = require("cookie-parser");

//Initialize Express app
const app = express();

// Middleware
app.use(express.json());
app.use(cookieParser());
app.use(cors({
  origin: "https://eduquest.com",
  credentials: true,
}));

// Connect to MongoDB
mongoose.connect(process.env.MONGO_URI)
.then(() => console.log("MongoDB Connected"))
.catch(err => console.error("MongoDB Connection Error: ", err));

//Use authentication routes
app.use("/api/auth", require("./routes/auth"));

// Test Route
app.get("/", (req, res) => {
  res.send("EduQuest Backend Running");
});

// Start Server
const PORT = process.env.PORT || 5000;
app.listen(PORT, () => 
  console.log(`Server running on port ${PORT}`));
