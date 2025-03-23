import React from "react";
import { motion } from "framer-motion";
import child from "../assets/images/challenge.png";

const challenges = [
  {
    id: 1,
    title: "Math Challenge",
    description: "Solve a set of math problems to unlock rewards!",
    buttonText: "Start",
  },
  {
    id: 2,
    title: "Science Quiz",
    description: "Answer questions from various science topics.",
    buttonText: "Start",
  },
  {
    id: 3,
    title: "Reading Challenge",
    description: "Read a set of books and take quizzes.",
    buttonText: "Start",
  },
  {
    id: 4,
    title: "Art Competition",
    description: "Create and submit your best artwork!",
    buttonText: "Start",
  },
  {
    id: 5,
    title: "Spell Bee",
    description: "Test your spelling skills and win prizes.",
    buttonText: "Start",
  },
  {
    id: 6,
    title: "Puzzle Master",
    description: "Solve puzzles and enhance your brain power.",
    buttonText: "Start",
  },
  {
    id: 7,
    title: "NatureHunt",
    description: "Find and identify different objects from the nature.",
    buttonText: "Start",
  },
  {
    id: 8,
    title: "History Trivia",
    description: "Answer history-based questions and learn fun facts.",
    buttonText: "Start",
  },
];

const Challenges = () => {
  return (
    <div className="min-h-screen bg-gradient-to-b from-indigo-500 via-purple-600 to-pink-500 py-16 relative overflow-hidden">
      <div className="container mx-auto text-center px-6">
        <motion.h1
          className="text-5xl font-extrabold text-white mb-16 drop-shadow-xl tracking-wide"
          initial={{ scale: 0.8, opacity: 0 }}
          animate={{ scale: 1, opacity: 1 }}
          transition={{ duration: 1.5, ease: "easeInOut" }}
        >
          Fun & Exciting Challenges
        </motion.h1>

        <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-12">
          {challenges.map((challenge) => (
            <motion.div
              key={challenge.id}
              className="relative bg-white text-black py-8 px-6 rounded-3xl shadow-2xl transform transition-all duration-500 hover:scale-105 hover:shadow-3xl"
              initial={{ opacity: 0, y: 50 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.8, delay: challenge.id * 0.2 }}
            >
              <h2 className="text-3xl font-bold text-transparent bg-clip-text bg-gradient-to-r from-yellow-400 to-orange-500 mb-4">
                {challenge.title}
              </h2>
              <p className="text-lg font-medium mb-6 text-gray-700">
                {challenge.description}
              </p>
              <motion.button
                className="bg-gradient-to-r from-orange-400 to-red-500 text-white px-8 py-4 rounded-full text-lg font-semibold transform transition-all duration-300 hover:scale-110 hover:bg-gradient-to-l hover:shadow-xl"
                whileHover={{ scale: 1.1 }}
                whileTap={{ scale: 0.95 }}
              >
                {challenge.buttonText}
              </motion.button>
            </motion.div>
          ))}
        </div>
      </div>

      {/* Floating Child Image in Bottom Right Corner with Animation */}
      <motion.img
        src={child}
        alt="Challenging Child"
        className="absolute bottom-0 right-0 w-80 md:w-96 lg:w-112 transform"
        initial={{ scale: 0.9, y: 50, opacity: 0 }}
        animate={{ scale: 1.2, y: 0, opacity: 1 }}
        transition={{
          duration: 2,
          ease: "easeInOut",
          yoyo: Infinity, // make it bounce up and down
        }}
      />
    </div>
  );
};

export default Challenges;
