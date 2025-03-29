import React from 'react';

const FaqsPage = () => {
  return (
    <div className="flex justify-center items-center min-h-screen bg-gradient-to-br from-pink-300 via-yellow-300 to-blue-400">
      <div className="bg-white rounded-3xl shadow-2xl p-10 w-[90%] sm:w-96 max-w-lg transform hover:scale-105 transition duration-300 ease-in-out">
        <h2 className="text-center text-4xl font-extrabold text-pink-600 mb-6 animate__animated animate__fadeIn animate__delay-1s">
          ❓ Frequently Asked Questions ❓
        </h2>
        <div className="space-y-6">
          <p className="text-2xl text-pink-700 font-semibold animate__animated animate__fadeIn animate__delay-2s">
            🔎 Common Questions
          </p>
          <ul className="list-disc pl-6 space-y-2 text-gray-700">
            <li className="hover:text-pink-600 transform hover:scale-105 transition duration-200">
              How can I reset my password?
            </li>
            <li className="hover:text-pink-600 transform hover:scale-105 transition duration-200">
              How do I change my email address?
            </li>
            <li className="hover:text-pink-600 transform hover:scale-105 transition duration-200">
              What should I do if my account is locked?
            </li>
          </ul>

          <div className="mt-6 text-center">
            <a
              href="mailto:support@example.com"
              className="bg-pink-500 text-white py-3 px-6 rounded-lg shadow-lg hover:bg-pink-600 transform hover:scale-110 transition duration-300"
            >
              📧 Contact Support
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default FaqsPage;
