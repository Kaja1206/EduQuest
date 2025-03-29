
import React, { useState } from 'react';
import { useSpring, animated } from 'react-spring';
import { Link } from 'react-router-dom';

const Profile = () => {
  const [profileImage, setProfileImage] = useState("https://via.placeholder.com/150");
  const [username, setUsername] = useState("");
  const [age, setAge] = useState("");
  const [favoriteColor, setFavoriteColor] = useState("");
  const [favoriteGame, setFavoriteGame] = useState("");

  const handleImageChange = (event) => {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setProfileImage(reader.result);
      };
      reader.readAsDataURL(file);
    }
  };

  const textProps = useSpring({
    opacity: 1,
    transform: "translateY(0px)",
    from: { opacity: 0, transform: "translateY(-30px)" },
    delay: 300,
  });

  return (
    <div className="flex justify-center items-center min-h-screen bg-gradient-to-br from-yellow-400 via-pink-300 to-purple-500">
      <animated.div style={textProps} className="bg-white rounded-3xl shadow-xl p-8 w-96 max-w-lg text-center">
        <h2 className="text-3xl font-bold text-yellow-300 mb-4 tracking-wide animate-bounce">
          🎉 My Profile 🎉
        </h2>

        {/* Profile Image */}
        <div className="relative w-32 h-32 mx-auto mb-4">
          <img src={profileImage} alt="Profile" className="w-32 h-32 rounded-full border-4 border-purple-500 shadow-md" />
          <label className="absolute bottom-0 right-0 bg-purple-500 text-white p-1 rounded-full cursor-pointer hover:bg-purple-600">
            📷
            <input type="file" accept="image/*" className="hidden" onChange={handleImageChange} />
          </label>
        </div>

        <div className="space-y-4 text-left">
          <div className="flex flex-col">
            <label className="font-semibold text-purple-700">Username:</label>
            <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} 
              className="border-2 border-yellow-500 rounded-lg px-3 py-2 text-lg focus:outline-none focus:ring-4 focus:ring-pink-500" 
              placeholder="Enter your username" />
          </div>
          <div className="flex flex-col">
            <label className="font-semibold text-purple-700">Age:</label>
            <input type="number" value={age} onChange={(e) => setAge(e.target.value)} 
              className="border-2 border-yellow-500 rounded-lg px-3 py-2 text-lg focus:outline-none focus:ring-4 focus:ring-pink-500" 
              placeholder="Enter your age" />
          </div>
          <div className="flex flex-col">
            <label className="font-semibold text-purple-700">Favorite Color:</label>
            <input type="text" value={favoriteColor} onChange={(e) => setFavoriteColor(e.target.value)} 
              className="border-2 border-yellow-500 rounded-lg px-3 py-2 text-lg focus:outline-none focus:ring-4 focus:ring-pink-500" 
              placeholder="Enter your favorite color" />
          </div>
          <div className="flex flex-col">
            <label className="font-semibold text-purple-700">Favorite Game:</label>
            <input type="text" value={favoriteGame} onChange={(e) => setFavoriteGame(e.target.value)} 
              className="border-2 border-yellow-500 rounded-lg px-3 py-2 text-lg focus:outline-none focus:ring-4 focus:ring-pink-500" 
              placeholder="Enter your favorite game" />
          </div>
        </div>

        <div className="mt-8 flex justify-center space-x-6">
          <button className="bg-pink-500 text-white py-3 px-6 rounded-full shadow-lg hover:bg-pink-600 transition-all transform hover:scale-105">
            💾 Save
          </button>
          <Link to="/" className="bg-purple-500 text-white py-3 px-6 rounded-full shadow-lg hover:bg-purple-600 transition-all transform hover:scale-105">
            🏠 Back to Home
          </Link>
        </div>
      </animated.div>
    </div>
  );
};

export default Profile;