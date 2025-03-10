import React, { useState, useEffect } from "react";
import { motion } from "framer-motion";
import Confetti from "react-confetti";
import { useWindowSize } from "react-use";

const achievements = [
  {
    id: 1,
    title: "Math Genius",
    description: "Completed 100 math challenges.",
    icon: "🧮",
  },
  {
    id: 2,
    title: "Science Wiz",
    description: "Answered 50 science quiz questions.",
    icon: "🔬",
  },
  {
    id: 3,
    title: "Reading Master",
    description: "Read 10 books this month.",
    icon: "📚",
  },
  {
    id: 4,
    title: "Artistic Talent",
    description: "Submitted 5 amazing artworks.",
    icon: "🎨",
  },
];

const Achievements = () => {
  const { width, height } = useWindowSize();
  const [showConfetti, setShowConfetti] = useState(true);

  // Stop confetti after 5 seconds
  useEffect(() => {
    const timer = setTimeout(() => {
      setShowConfetti(false);
    }, 5000);
    return () => clearTimeout(timer);
  }, []);

  return (
    <div className="min-h-screen bg-gradient-to-t from-green-400 via-blue-500 to-purple-600 py-16 relative">
      {/* Firecracker effect */}
      {showConfetti && (
        <Confetti
          width={width}
          height={height}
          numberOfPieces={300}
          gravity={0.3}
        />
      )}

      <div className="container mx-auto text-center px-6 relative">
        <motion.h1
          className="text-5xl font-extrabold text-white mb-16 drop-shadow-xl"
          initial={{ scale: 0.8, opacity: 0 }}
          animate={{ scale: 1, opacity: 1 }}
          transition={{ duration: 1.5, ease: "easeInOut" }}
        >
          🎉 Your Achievements 🎉
        </motion.h1>

        <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-12">
          {achievements.map((achievement) => (
            <motion.div
              key={achievement.id}
              className="relative bg-white text-black py-8 px-6 rounded-3xl shadow-lg transform transition-all duration-500 hover:scale-105 hover:shadow-2xl"
              initial={{ opacity: 0, y: 50 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.8, delay: achievement.id * 0.2 }}
            >
              <div className="text-6xl mb-4">{achievement.icon}</div>
              <h2 className="text-3xl font-bold text-transparent bg-clip-text bg-gradient-to-r from-pink-400 to-yellow-500 mb-4">
                {achievement.title}
              </h2>
              <p className="text-lg font-medium">{achievement.description}</p>
            </motion.div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Achievements;
