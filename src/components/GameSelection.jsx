import React from "react";
import { motion } from "framer-motion";

const GameSelection = () => {
  const games = [
    { grade: <b>Grade 1</b>, games: ["Puzzle Mania", "Math Adventure"] },
    { grade: <b>Grade 2</b>, games: ["Word Hunt", "Shapes Explorer"] },
    { grade: <b>Grade 3</b>, games: ["Animal Quiz", "Spelling Challenge"] },
    { grade: <b>Grade 4</b>, games: ["Number Ninja", "History Explorer"] },
    { grade: <b>Grade 5</b>, games: ["Science Detective", "Mastermind"] },
  ];

  return (
    <div className="relative min-h-screen flex flex-col items-center bg-gradient-to-r from-blue-400 to-purple-500 p-8 overflow-hidden">
      {/* Animated Background Wave */}
      <motion.div
        className="absolute inset-0 w-full h-full bg-opacity-30"
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 1.5 }}
      >
        <svg
          className="absolute bottom-0 w-full"
          viewBox="0 0 1440 200"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            fill="url(#gradient)"
            fillOpacity="1"
            d="M0,160L30,149.3C60,139,120,117,180,122.7C240,128,300,160,360,165.3C420,171,480,149,540,138.7C600,128,660,128,720,106.7C780,85,840,43,900,48C960,53,1020,107,1080,106.7C1140,107,1200,53,1260,48C1320,43,1380,85,1410,106.7L1440,128V200H0Z"
          />
          <defs>
            <linearGradient id="gradient" x1="0" y1="0" x2="1" y2="0">
              <stop offset="0%" stopColor="#ff9a9e" />
              <stop offset="100%" stopColor="#fad0c4" />
            </linearGradient>
          </defs>
        </svg>
      </motion.div>

      {/* Animated Title */}
      <motion.h1
        className="text-5xl font-extrabold text-white mb-10 drop-shadow-lg"
        initial={{ scale: 0.8, opacity: 0 }}
        animate={{ scale: 1, opacity: 1 }}
        transition={{ duration: 1, ease: "easeOut" }}
      >
        Choose Your Game!
      </motion.h1>

      {/* Game Cards (Circular Buttons) */}
      <div className="w-full max-w-5xl grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        {games.map((item, index) => (
          <motion.div
            key={index}
            className="p-8 bg-white rounded-3xl shadow-xl flex flex-col items-center transition transform hover:scale-105"
            initial={{ opacity: 0, y: 50 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.5, delay: index * 0.2 }}
          >
            <h2 className="text-3xl font-semibold text-center text-blue-700 mb-4">
              {item.grade}
            </h2>

            <div className="flex flex-wrap justify-center gap-4">
              {item.games.map((game, i) => (
                <motion.div
                  key={i}
                  className="w-28 h-28 flex items-center justify-center bg-yellow-400 text-white rounded-full text-center hover:bg-yellow-500 cursor-pointer shadow-lg transition duration-300"
                  whileHover={{ scale: 1.1, rotate: 5 }}
                  whileTap={{ scale: 0.9 }}
                >
                  <h3 className="text-lg font-semibold">{game}</h3>
                </motion.div>
              ))}
            </div>
          </motion.div>
        ))}
      </div>
    </div>
  );
};

export default GameSelection;
