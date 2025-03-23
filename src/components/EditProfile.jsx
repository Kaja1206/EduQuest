import React, { useState } from 'react';

const EditProfile = () => {
  const [profileImage, setProfileImage] = useState(null);
  const [username, setUsername] = useState("Kiddo123");
  const [age, setAge] = useState("8 years old");
  const [favoriteColor, setFavoriteColor] = useState("Blue");
  const [favoriteGame, setFavoriteGame] = useState("Super Mario");

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setProfileImage(reader.result);
      };
      reader.readAsDataURL(file);
    }
  };

  return (
    <div className="flex justify-center items-center min-h-screen bg-gradient-to-r from-yellow-400 via-pink-500 to-purple-600">
      <div className="bg-white rounded-3xl shadow-2xl p-6 w-80 max-w-md transform scale-100 animate-fadeIn">
        <h2 className="text-center text-3xl font-bold text-yellow-300 mb-4 tracking-wide animate-bounce">
          🎉 Edit Profile 🎉
        </h2>

        <div className="flex flex-col items-center mb-4">
          <label htmlFor="profileImage" className="cursor-pointer">
            <div className="w-24 h-24 rounded-full border-4 border-yellow-500 overflow-hidden shadow-lg hover:opacity-80 transition">
              {profileImage ? (
                <img src={profileImage} alt="Profile" className="w-full h-full object-cover" />
              ) : (
                <div className="w-full h-full flex items-center justify-center bg-gray-300 text-gray-700">
                  📷 Upload
                </div>
              )}
            </div>
          </label>
          <input
            id="profileImage"
            type="file"
            accept="image/*"
            className="hidden"
            onChange={handleImageChange}
          />
        </div>

        <form className="space-y-4">
          <div className="flex flex-col space-y-2">
            <label className="text-lg font-semibold text-purple-700">👑 Username:</label>
            <input 
              type="text" 
              className="border-2 border-yellow-500 rounded-lg px-3 py-2 w-full text-base focus:outline-none focus:ring-4 focus:ring-pink-500 transition transform hover:scale-105" 
              value={username} 
              onChange={(e) => setUsername(e.target.value)}
            />
          </div>
          <div className="flex flex-col space-y-2">
            <label className="text-lg font-semibold text-purple-700">🎂 Age:</label>
            <input 
              type="text" 
              className="border-2 border-yellow-500 rounded-lg px-3 py-2 w-full text-base focus:outline-none focus:ring-4 focus:ring-pink-500 transition transform hover:scale-105" 
              value={age} 
              onChange={(e) => setAge(e.target.value)}
            />
          </div>
          <div className="flex flex-col space-y-2">
            <label className="text-lg font-semibold text-purple-700">🎨 Favorite Color:</label>
            <input 
              type="text" 
              className="border-2 border-yellow-500 rounded-lg px-3 py-2 w-full text-base focus:outline-none focus:ring-4 focus:ring-pink-500 transition transform hover:scale-105" 
              value={favoriteColor} 
              onChange={(e) => setFavoriteColor(e.target.value)}
            />
          </div>
          <div className="flex flex-col space-y-2">
            <label className="text-lg font-semibold text-purple-700">🎮 Favorite Game:</label>
            <input 
              type="text" 
              className="border-2 border-yellow-500 rounded-lg px-3 py-2 w-full text-base focus:outline-none focus:ring-4 focus:ring-pink-500 transition transform hover:scale-105" 
              value={favoriteGame} 
              onChange={(e) => setFavoriteGame(e.target.value)}
            />
          </div>

          <div className="mt-6 flex justify-center space-x-4">
            <button 
              className="bg-pink-500 text-white py-2 px-6 rounded-full shadow-xl hover:bg-pink-600 transform transition-all duration-300 scale-105 hover:scale-110"
            >
              💾 Save
            </button>
            <button 
              className="bg-purple-500 text-white py-2 px-6 rounded-full shadow-xl hover:bg-purple-600 transform transition-all duration-300 scale-105 hover:scale-110"
            >
              ❌ Cancel
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default EditProfile;
