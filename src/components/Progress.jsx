import React, {useEffect } from "react";
import { motion } from "framer-motion";

const progressData = [
  { id: 1, title: "Math Challenge", progress: 80 },
  { id: 2, title: "Science Quiz", progress: 50 },
  { id: 3, title: "Reading Challenge", progress: 100 },
  { id: 4, title: "Art Submission", progress: 40 },
];

const Progress = () => {
  useEffect(() => {
    // Check if any progress is 100% to trigger a temporary celebration effect
    if (progressData.some((game) => game.progress === 100)) {
      setTimeout(() => {
        // Celebration will stop after 5 sec (you can add celebration effect later if needed)
      }, 5000); // Stop after 5 sec
    }
  }, []); // Empty array means this effect runs once after the first render

  return (
    <div className="min-h-screen bg-gradient-to-t from-blue-500 via-purple-600 to-pink-500 py-16 relative">
      <div className="container mx-auto text-center px-6">
        <motion.h1
          className="text-5xl font-extrabold text-white mb-16 drop-shadow-xl"
          initial={{ scale: 0.8, opacity: 0 }}
          animate={{ scale: 1, opacity: 1 }}
          transition={{ duration: 1.5, ease: "easeInOut" }}
        >
          🎯 Track Your Progress!
        </motion.h1>

        <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-12">
          {progressData.map((game) => (
            <motion.div
              key={game.id}
              className="relative bg-white text-black py-8 px-8 rounded-3xl shadow-lg transform transition-all duration-500 hover:scale-105 hover:shadow-2xl"
              initial={{ opacity: 0, y: 50 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.8, delay: game.id * 0.2 }}
            >
              <h2 className="text-3xl font-bold text-transparent bg-clip-text bg-gradient-to-r from-green-400 to-yellow-500 mb-4">
                {game.title}
              </h2>

              <div className="w-full bg-gray-300 rounded-full h-5 mb-6 overflow-hidden">
                <motion.div
                  className="bg-gradient-to-r from-yellow-400 to-orange-500 h-5 rounded-full"
                  initial={{ width: "0%" }}
                  animate={{ width: `${game.progress}%` }}
                  transition={{ duration: 1.2, ease: "easeOut" }}
                ></motion.div>
              </div>

              <p className="text-lg font-medium">
                ✅ Completed:{" "}
                <span className="font-bold text-green-600">
                  {game.progress}%
                </span>
              </p>
            </motion.div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Progress;
