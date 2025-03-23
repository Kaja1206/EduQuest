import React, { useState, useEffect, useRef } from "react";
import { FaBars, FaHeadset } from "react-icons/fa";
import { Link, useNavigate } from "react-router-dom";
import logo from "../assets/images/logo.png";

const Career = () => {
  const [menuOpen, setMenuOpen] = useState(false);
  const [careerOpen, setCareerOpen] = useState(false);
  const menuRef = useRef(null);
  const navigate = useNavigate();

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (menuRef.current && !menuRef.current.contains(event.target)) {
        setMenuOpen(false);
      }
    };
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  const handleCareerClick = () => setCareerOpen(true);
  const handleCloseModal = () => setCareerOpen(false);

  return (
    <div className="relative w-full h-screen overflow-hidden bg-gradient-to-b from-black via-purple-900 to-black">
  {/* Dark Overlay */}
  <div className="absolute top-0 left-0 w-full h-full opacity-70 z-0"></div>

  {/* Centered Text and Emojis */}
  <div className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 text-center z-10">
    <h1 className="text-4xl md:text-5xl font-bold text-white mb-4">
      🌟 Welcome to GameZone! 🎮
    </h1>
    <p className="text-lg md:text-2xl text-white mb-6">
      🎉 Play, Explore & Learn! 🧩  
      Unlock amazing adventures 🏆 and collect fun rewards 🎁 along the way!  
      Ready to start your journey? 🚀
    </p>
    
  </div>



      {/* Navbar */}
      <nav className="absolute top-0 left-0 w-full flex justify-between items-center px-6 py-4 bg-white shadow-md text-black">
        {/* Left Side - Logo & Name */}
        <div className="flex items-center space-x-3">
          <img src={logo} alt="Logo" className="w-30 h-20" />
        
        </div>

        {/* Right Side - Menu Icons */}
        <div className="relative flex items-center space-x-6">
          {/* Menu Icon */}
          <div className="relative">
            <FaBars
              className="text-xl cursor-pointer hover:text-purple-400"
              title="Menu"
              onClick={() => setMenuOpen(!menuOpen)}
            />
            {menuOpen && (
              <div
                ref={menuRef}
                className="absolute right-0 top-full mt-2 min-w-[150px] bg-black bg-opacity-90 text-white rounded-lg shadow-lg border border-purple-700 z-50"
              >
                <Link
                  to="/auth"
                  className="block px-4 py-2 hover:bg-purple-700 transition"
                >
                  🔓 Logout
                </Link>
                <Link
                  to="/profile"
                  className="block px-4 py-2 hover:bg-purple-700 transition"
                >
                  👤 Profile
                </Link>
              </div>
            )}
          </div>

          {/* Help & Support Icon */}
        <Link to="/help-and-support">
          <FaHeadset
            className="text-xl cursor-pointer hover:text-purple-300"
            title="Help & Support"
          />
        </Link>
          {/* Career Button */}
          <button
            onClick={handleCareerClick}
            className="text-lg text-purple-700 bg-purple-300 hover:bg-purple-400 hover:text-white font-semibold py-2 px-4 border border-purple-700 rounded-lg transition duration-200 ease-in-out transform hover:scale-105"
          >
            Career
          </button>
        </div>
      </nav>

      {/* Career Modal */}
      {careerOpen && (
        <div className="absolute top-0 left-0 right-0 bottom-0 bg-black bg-opacity-80 flex items-center justify-center p-4 z-20">
          <div className="bg-gray-900 bg-opacity-95 p-8 rounded-lg w-full max-w-4xl shadow-xl">
            <div className="space-y-6 text-center">
              <h3 className="text-3xl font-bold text-purple-400">
                🌟 Career Adventure
              </h3>
              <p className="text-gray-400">
                Welcome to your exciting career path! 🎮🚀 
                Here you can track your achievements, face new challenges, and win rewards. Get ready to explore and level up! 🌈🔥
              </p>

              <div className="grid grid-cols-2 gap-4 md:grid-cols-3">
                <Link
                  to="/progress"
                  className="w-full flex items-center justify-center text-lg text-purple-700 bg-purple-300 hover:bg-purple-400 hover:text-white font-semibold py-2 px-4 border border-purple-700 rounded-lg transition transform hover:scale-105"
                >
                  📈 My Progress
                </Link>
                <Link
                  to="/achievements"
                  className="w-full flex items-center justify-center text-lg text-purple-700 bg-purple-300 hover:bg-purple-400 hover:text-white font-semibold py-2 px-4 border border-purple-700 rounded-lg transition transform hover:scale-105"
                >
                  🏆 Achievements
                </Link>
                <Link
                  to="/challenges"
                  className="w-full flex items-center justify-center text-lg text-purple-700 bg-purple-300 hover:bg-purple-400 hover:text-white font-semibold py-2 px-4 border border-purple-700 rounded-lg transition transform hover:scale-105"
                >
                  ⚔️ Challenges
                </Link>
                <Link
                  to="/game-selection"
                  className="w-full flex items-center justify-center text-lg text-purple-700 bg-purple-300 hover:bg-purple-400 hover:text-white font-semibold py-2 px-4 border border-purple-700 rounded-lg transition transform hover:scale-105"
                >
                  🎮 Game Selection
                </Link>
                <Link
                  to="/rewards"
                  className="w-full flex items-center justify-center text-lg text-purple-700 bg-purple-300 hover:bg-purple-400 hover:text-white font-semibold py-2 px-4 border border-purple-700 rounded-lg transition transform hover:scale-105"
                >
                  🎁 Rewards
                </Link>
                <Link
                  to="/courses"
                  className="w-full flex items-center justify-center text-lg text-purple-700 bg-purple-300 hover:bg-purple-400 hover:text-white font-semibold py-2 px-4 border border-purple-700 rounded-lg transition transform hover:scale-105"
                >
                  📚 Courses
                </Link>
              </div>
            </div>

            {/* Close Button */}
            <button
              onClick={handleCloseModal}
              className="mt-6 w-full bg-purple-700 hover:bg-purple-800 text-white font-bold py-3 px-6 rounded-lg transition transform hover:scale-105"
            >
              ❌ Close
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Career;
