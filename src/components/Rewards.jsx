import React from "react";
import { motion } from "framer-motion";
import Snowfall from "react-snowfall";

const rewards = [
  {
    id: 1,
    title: "Golden Trophy 🏆",
    description: "Unlock this by completing 10 challenges!",
    progress: 80,
  },
  {
    id: 2,
    title: "Silver Medal 🥈",
    description: "Earn this by answering 100 quiz questions!",
    progress: 60,
  },
  {
    id: 3,
    title: "Art Superstar 🎨",
    description: "Unlock this by submitting 5 artworks!",
    progress: 30,
  },
];

const Rewards = () => {
  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-400 via-purple-500 to-pink-400 py-16 relative overflow-hidden">
      {/* Snow effect */}
      <Snowfall snowflakeCount={60} />

      {/* Animated stars */}
      <div className="absolute inset-0 pointer-events-none">
        <div className="absolute top-10 left-10 w-10 h-10 bg-yellow-300 rounded-full opacity-70 animate-ping"></div>
        <div className="absolute bottom-20 right-16 w-8 h-8 bg-white rounded-full opacity-50 animate-bounce"></div>
        <div className="absolute top-28 right-24 w-6 h-6 bg-yellow-200 rounded-full opacity-80 animate-pulse"></div>
      </div>

      <div className="container mx-auto text-center px-6 relative">
        <motion.h1
          className="text-5xl font-extrabold text-white mb-12 drop-shadow-lg"
          initial={{ scale: 0.8, opacity: 0 }}
          animate={{ scale: 1, opacity: 1 }}
          transition={{ duration: 1.5, ease: "easeInOut" }}
        >
          🎖️ Earn Your Rewards! 🎖️
        </motion.h1>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-10">
          {rewards.map((reward) => (
            <motion.div
              key={reward.id}
              className="relative bg-white text-black p-8 rounded-3xl shadow-2xl transform transition-all duration-500 hover:scale-105 hover:shadow-2xl"
              initial={{ opacity: 0, y: 50 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.8, delay: reward.id * 0.2 }}
            >
              {/* Reward title */}
              <h2 className="text-3xl font-bold text-transparent bg-clip-text bg-gradient-to-r from-purple-600 to-pink-500 mb-4">
                {reward.title}
              </h2>

              {/* Reward description */}
              <p className="text-lg font-medium mb-6 text-gray-700">
                {reward.description}
              </p>

              {/* Progress bar */}
              <div className="w-full bg-gray-200 rounded-full h-4 mb-4">
                <div
                  className="bg-gradient-to-r from-purple-400 to-pink-500 h-4 rounded-full"
                  style={{ width: `${reward.progress}%` }}
                ></div>
              </div>

              {/* Claim button */}
              <motion.button
                className="bg-gradient-to-r from-purple-500 to-pink-500 text-white px-6 py-3 rounded-full text-lg font-semibold transform transition-all duration-300 hover:scale-105 hover:shadow-xl"
                whileHover={{ scale: 1.1 }}
                whileTap={{ scale: 0.95 }}
              >
                🎁 Claim Reward
              </motion.button>
            </motion.div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Rewards;
