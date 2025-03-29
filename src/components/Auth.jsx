import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { motion } from "framer-motion";
import loginImage from "../assets/images/cartoon.png";
import signupImage from "../assets/images/signup.png";

const Auth = () => {
  const [isLogin, setIsLogin] = useState(true);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleSubmit = () => {
    if (isLogin) {
      console.log("Logging in with", email, password);
    } else {
      console.log("Signing up with", email, password);
    }
    navigate("/dashboard");
  };

  return (
    <div
      className={`flex justify-center items-center min-h-screen ${
        isLogin
          ? "bg-gradient-to-r from-purple-400 to-pink-500"
          : "bg-gradient-to-r from-pink-400 to-yellow-500"
      }`}
    >
      <motion.div
        className="flex bg-white p-12 rounded-2xl shadow-2xl w-[50%] h-[600px] max-w-4xl"
        initial={{ opacity: 0, scale: 0.9 }}
        animate={{ opacity: 1, scale: 1 }}
        transition={{ duration: 0.5 }}
      >
        {/* Left Side - Form Container */}
        <div className="w-1/2 flex flex-col justify-center items-start pr-8">
          <h1
            className={`text-4xl font-bold mb-4 ${
              isLogin ? "text-purple-700" : "text-pink-600"
            }`}
          >
            {isLogin ? "Welcome Back!" : "Join EduQuest!"}
          </h1>
          <p className="text-gray-500 text-lg mb-6">
            {isLogin
              ? "Ready to continue your adventure?"
              : "Start your learning adventure today!"}
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
            placeholder={isLogin ? "Enter your password" : "Create a password"}
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="p-3 border border-gray-300 rounded-md w-full mb-4 focus:outline-none focus:ring-2 focus:ring-purple-500"
          />

          {/* Submit Button */}
          <motion.button
            onClick={handleSubmit}
            className={`${
              isLogin
                ? "bg-purple-600 hover:bg-purple-700"
                : "bg-pink-600 hover:bg-pink-700"
            } text-white w-full p-3 rounded-lg font-semibold transition duration-300`}
            whileHover={{ scale: 1.05 }}
            whileTap={{ scale: 0.95 }}
          >
            {isLogin ? "Login" : "Sign Up"}
          </motion.button>

          {/* Toggle Login/Signup */}
          <p className="text-center text-gray-600 mt-4">
            {isLogin ? "Don't have an account? " : "Already have an account? "}
            <button
              onClick={() => setIsLogin(!isLogin)}
              className={`${
                isLogin ? "text-purple-600" : "text-pink-600"
              } font-semibold hover:underline`}
            >
              {isLogin ? "Sign Up" : "Login"}
            </button>
          </p>
        </div>

        {/* Right Side - Image Container */}
        <div className="w-1/2">
          <img
            src={isLogin ? loginImage : signupImage}
            alt={isLogin ? "Login Illustration" : "Signup Illustration"}
            className="w-full h-full object-cover rounded-2xl"
          />
        </div>
      </motion.div>
    </div>
  );
};

export default Auth;
