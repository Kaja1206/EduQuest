import React from 'react';
import { Link } from 'react-router-dom';

const HelpAndSupport = () => {
  return (
    <div className="flex justify-center items-center min-h-screen bg-gradient-to-br from-blue-200 via-green-300 to-yellow-300">
      <div className="bg-white rounded-3xl shadow-xl p-8 w-96 max-w-lg">
        <h2 className="text-center text-3xl font-extrabold text-yellow-600 mb-6">🆘 Help & Support 🆘</h2>

        <div className="space-y-6">
          <div className="flex flex-col items-center">
            <h3 className="text-2xl font-semibold text-blue-700 mb-4">Need Help? 🤔</h3>
            <p className="text-lg text-gray-700 mb-6">Choose one of the options below to get assistance! 🌟</p>
          </div>

          {/* Help Categories */}
          <div className="space-y-4">
            <div className="flex justify-between items-center bg-blue-200 hover:bg-blue-300 rounded-xl p-4">
              <div className="w-12 text-center text-blue-600">
                💻
              </div>
              <Link to="/tech-support" className="text-xl text-blue-700 font-semibold">Technical Support 🛠️</Link>
            </div>

            <div className="flex justify-between items-center bg-yellow-200 hover:bg-yellow-300 rounded-xl p-4">
              <div className="w-12 text-center text-yellow-600">
                👤
              </div>
              <Link to="/account-issues" className="text-xl text-yellow-700 font-semibold">Account Issues 🧑‍💻</Link>
            </div>

            <div className="flex justify-between items-center bg-green-200 hover:bg-green-300 rounded-xl p-4">
              <div className="w-12 text-center text-green-600">
                ❓
              </div>
              <Link to="/faqs" className="text-xl text-green-700 font-semibold">FAQs 📚</Link>
            </div>
          </div>

          {/* Call to Action */}
          <div className="mt-8 flex justify-center space-x-6">
            <Link to="/" className="bg-purple-500 text-white py-3 px-6 rounded-full shadow-lg hover:bg-purple-600 transition-all transform hover:scale-105">
              🏠 Back to Home
            </Link>
            <Link to="/contact-us" className="bg-blue-500 text-white py-3 px-6 rounded-full shadow-lg hover:bg-blue-600 transition-all transform hover:scale-105">
              📞 Contact Us
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default HelpAndSupport;
