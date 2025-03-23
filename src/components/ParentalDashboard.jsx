import React from "react";
import { motion } from "framer-motion";

const ParentalDashboard = () => {
  return (
    <div className="p-8 bg-gradient-to-br from-blue-100 to-blue-300 min-h-screen flex flex-col items-center">
      {/* Title */}
      <motion.h1
        className="text-4xl font-extrabold text-blue-800 mb-8 tracking-wide"
        initial={{ opacity: 0, y: -20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        📊 Parental Dashboard
      </motion.h1>

      {/* Dashboard Container */}
      <div className="bg-white p-8 rounded-lg shadow-xl max-w-4xl w-full">
        {/* Child's Progress */}
        <h2 className="text-2xl font-semibold text-blue-700 mb-4">
          Child's Progress Overview
        </h2>
        <p className="text-lg mb-4">
          Your child has completed <b>85%</b> of their learning goals!
        </p>
        <div className="relative w-full h-6 bg-gray-200 rounded-full overflow-hidden">
          <motion.div
            className="absolute top-0 left-0 h-full bg-gradient-to-r from-green-400 to-teal-500"
            initial={{ width: "0%" }}
            animate={{ width: "85%" }}
            transition={{ duration: 1 }}
          />
        </div>

        {/* Learning Goals */}
        <h2 className="text-xl font-semibold text-blue-700 mt-8">
          Learning Goals Progress
        </h2>
        <ul className="mt-4 space-y-3">
          <li className="text-lg flex justify-between">
            <span>✅ Mastermind</span>{" "}
            <span className="text-green-600 font-bold">100% Completed</span>
          </li>
          <li className="text-lg flex justify-between">
            <span>🟡Hunter</span>{" "}
            <span className="text-yellow-600 font-bold">75% In Progress</span>
          </li>
          <li className="text-lg flex justify-between">
            <span>🔴Block Puzzle</span>{" "}
            <span className="text-red-600 font-bold">50% Needs Review</span>
          </li>
        </ul>

        {/* Activity Summary */}
        <h2 className="text-xl font-semibold text-blue-700 mt-8">
          Recent Activity
        </h2>
        <div className="mt-4 p-6 bg-gray-50 rounded-lg shadow-md">
          <p className="text-lg">
            🧩 Played <b>Puzzle Mania</b> and solved 8/10 puzzles correctly.
          </p>
          <p className="text-lg">
            🔢 Completed <b>Math Adventure</b> with a score of 90%.
          </p>
        </div>
      </div>
    </div>
  );
};

export default ParentalDashboard;
