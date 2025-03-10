import React from "react";
import { motion } from "framer-motion";
import { useNavigate } from "react-router-dom";

const Home = () => {
  const navigate = useNavigate(); // Hook for navigation

  return (
    <div className="relative w-full h-screen overflow-hidden">
      {/* Background Video */}
      <video
        autoPlay
        loop
        muted
        className="absolute top-0 left-0 w-full h-full object-cover"
      >
        <source src="/d4eb372334e3a2f21cf6317294ac6700.mp4" type="video/mp4" />
        Your browser does not support the video tag.
      </video>

      {/* Content Overlay */}
      <div className="absolute inset-0 flex flex-col items-center justify-center text-white bg-black bg-opacity-50">
        {/* Heading */}
        <motion.h1
          className="text-6xl font-extrabold mb-6 drop-shadow-lg"
          initial={{ opacity: 0, y: -50 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 1 }}
        >
          Welcome to <span className="text-yellow-300">EduQuest</span>
        </motion.h1>

        {/* Subtitle */}
        <motion.p
          className="text-2xl mb-8 text-center max-w-lg"
          initial={{ opacity: 0, y: 20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 1, delay: 0.5 }}
        >
          Embark on a fun and interactive learning adventure!
        </motion.p>

        {/* Animated Get Started Button */}
        <motion.button
          className="bg-yellow-400 hover:bg-yellow-500 text-blue-900 font-semibold px-8 py-4 rounded-full text-xl shadow-lg transition-all"
          whileHover={{ scale: 1.1 }}
          whileTap={{ scale: 0.9 }}
          onClick={() => navigate("/auth")} // Navigate to Login Page
        >
          Get Started
        </motion.button>
      </div>
    </div>
  );
};

export default Home;
