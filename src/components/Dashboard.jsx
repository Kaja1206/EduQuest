import React, { useState } from "react";
import { Link } from "react-router-dom";
import {
  FaGamepad,
  FaChartBar,
  FaChalkboardTeacher,
  FaUsers,
  FaTrophy,
  FaRegStar,
  FaGift,
  FaBars,
  FaUser,
  FaSignOutAlt,
  FaEdit
} from "react-icons/fa";

const Dashboard = () => {
  const [menuOpen, setMenuOpen] = useState(false);

  return (
    <div className="relative p-6 bg-gradient-to-br from-purple-400 to-blue-500 min-h-screen flex flex-col">

      {/* Background */}
      <div
        className="absolute top-0 left-0 w-full h-full bg-cover bg-center z-0"
        style={{
          backgroundImage: "url('/gif.gif')", 
          objectFit: "cover",
          height: "100%",
          width: "100%",
          position: "absolute",
        }}
      ></div>

    
    <div className="absolute top-0 left-0 w-full h-full bg-black opacity-50 z-10"></div>

      {/* Top Menu Bar */}
      
 <header className="bg-white shadow-md p-4 rounded-xl flex justify-between items-center relative z-20">
        <h1 className="text-xl font-bold text-blue-700">EduQuest Dashboard</h1>
        <div className="relative">
          <FaBars className="text-2xl text-blue-700 cursor-pointer" onClick={() => setMenuOpen(!menuOpen)} />
          {menuOpen && (
            <div className="absolute right-0 mt-2 w-48 bg-white rounded-lg shadow-lg p-2">
              <Link to="/profile" className="flex items-center p-2 hover:bg-gray-200 rounded">
                <FaUser className="mr-2" /> Profile
              </Link>
              <Link to="/edit-profile" className="flex items-center p-2 hover:bg-gray-200 rounded">
                <FaEdit className="mr-2" /> Edit Profile
              </Link>
              <Link to="/help-and-support" className="flex items-center p-2 hover:bg-gray-200 rounded ">
                <FaSignOutAlt className="mr-2" /> Help and Support
              </Link>
              <Link to="/" className="flex items-center p-2 hover:bg-gray-200 rounded text-red-600">
                <FaSignOutAlt className="mr-2" /> Logout
              </Link>
            </div>
          )}
        </div>
      </header>

      {/* Middle Content */}
      <div className="flex flex-col items-center justify-center flex-grow z-10 text-center text-white relative px-6 py-12 mt-20">
        <h2 className="text-4xl font-extrabold text-shadow-md mb-6 leading-tight md:text-5xl">
          Learn, Play, and Level Up! 🌟
        </h2>
        <p className="text-lg md:text-xl text-gray-200 max-w-3xl mx-auto leading-relaxed">
          Explore exciting games, complete fun challenges, and unlock awesome rewards as you grow your skills. 
          Dive into a world where learning meets fun and see how far you can go!
        </p>
      </div>

      {/* Bottom Navigation Bar */}
      <nav className="bg-white shadow-md p-4 rounded-xl flex justify-around mt-auto w-full z-20">
        <Link to="/games" className="flex flex-col items-center text-blue-700">
          <FaGamepad className="text-2xl" />
          <span>Games</span>
        </Link>
        <Link to="/progress" className="flex flex-col items-center text-blue-700">
          <FaChartBar className="text-2xl" />
          <span>Progress</span>
        </Link>
        <Link to="/courses" className="flex flex-col items-center text-blue-700">
          <FaChalkboardTeacher className="text-2xl" />
          <span>Courses</span>
        </Link>
        <Link to="/challenges" className="flex flex-col items-center text-blue-700">
          <FaUsers className="text-2xl" />
          <span>Challenges</span>
        </Link>
        <Link to="/achievements" className="flex flex-col items-center text-blue-700">
          <FaTrophy className="text-2xl" />
          <span>Achievements</span>
        </Link>
        <Link to="/rewards" className="flex flex-col items-center text-blue-700">
          <FaGift className="text-2xl" />
          <span>Rewards</span>
        </Link>
        <Link to="/parent-dashboard" className="flex flex-col items-center text-blue-700">
          <FaRegStar className="text-2xl" />
          <span>Parental</span>
        </Link>
      </nav>

    </div>
  );
};

export default Dashboard; 
