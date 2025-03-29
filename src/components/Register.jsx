import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { motion } from "framer-motion";
import signupImage from "../assets/images/signup.png"; // Assuming this is the signup image

const Register = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const navigate = useNavigate();

  const handleSubmit = () => {
    if (password !== confirmPassword) {
      alert("Passwords do not match!");
      return;
    }
    console.log("Registering with", email, password);
    navigate("/profile");
  };

  return (
    <div className="flex justify-center items-center min-h-screen bg-gradient-to-r from-black to-purple-800">
      <motion.div
        className="flex bg-white p-12 rounded-2xl shadow-2xl w-[50%] h-[600px] max-w-4xl"
        initial={{ opacity: 0, scale: 0.9 }}
        animate={{ opacity: 1, scale: 1 }}
        transition={{ duration: 0.5 }}
      >
        {/* Left Side - Registration Form Container */}
        <div className="w-1/2 flex flex-col justify-center items-start pr-8">
          <h1 className="text-4xl font-bold mb-4 text-purple-600">
            Join EduQuest!
          </h1>
          <p className="text-gray-500 text-lg mb-6">
            Start your learning adventure today!
          </p>

          {/* Email Input */}
          <input
            type="email"
            placeholder="Enter your email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            className="p-3 border border-gray-300 rounded-md w-full mb-4 focus:outline-none focus:ring-2 focus:ring-purple-500"
          />

          {/* Password Input */}
          <input
            type="password"
            placeholder="Create a password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="p-3 border border-gray-300 rounded-md w-full mb-4 focus:outline-none focus:ring-2 focus:ring-purple-500"
          />

          {/* Confirm Password Input */}
          <input
            type="password"
            placeholder="Confirm your password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            className="p-3 border border-gray-300 rounded-md w-full mb-4 focus:outline-none focus:ring-2 focus:ring-purple-500"
          />

          {/* Submit Button */}
          <motion.button
            onClick={handleSubmit}
            className="bg-purple-600 hover:bg-purple-700 text-white w-full p-3 rounded-lg font-semibold transition duration-300"
            whileHover={{ scale: 1.05 }}
            whileTap={{ scale: 0.95 }}
          >
            Register
          </motion.button>
        </div>

        {/* Right Side - Image Container */}
        <div className="w-1/2">
          <img
            src={signupImage}
            alt="Signup Illustration"
            className="w-full h-full object-cover rounded-2xl"
          />
        </div>
      </motion.div>
    </div>
  );
};

export default Register;
