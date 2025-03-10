import React from 'react';

const AccountIssuesPage = () => {
  return (
    <div className="flex justify-center items-center min-h-screen bg-gradient-to-br from-green-300 via-yellow-300 to-pink-300">
      <div className="bg-white rounded-3xl shadow-2xl p-10 w-[90%] sm:w-96 max-w-lg transform hover:scale-105 transition duration-300 ease-in-out">
        <h2 className="text-center text-4xl font-extrabold text-green-600 mb-6 animate__animated animate__fadeIn animate__delay-1s">
          👤 Account Issues 👤
        </h2>
        <p className="text-lg text-gray-700 mb-6 animate__animated animate__fadeIn animate__delay-2s">
          Having trouble with your account? Don’t worry, we can help you get it fixed quickly! 😊
        </p>
        <div className="space-y-6">
          <p className="text-2xl text-green-700 font-semibold animate__animated animate__fadeIn animate__delay-3s">🔒 Common Account Issues</p>
          <ul className="list-disc pl-6 space-y-2 text-gray-700">
            <li className="hover:text-green-600 transform hover:scale-105 transition duration-200">Forgot password</li>
            <li className="hover:text-green-600 transform hover:scale-105 transition duration-200">Account not verified</li>
            <li className="hover:text-green-600 transform hover:scale-105 transition duration-200">Unable to login</li>
          </ul>
          <div className="mt-6 text-center">
            <a
              href="mailto:support@example.com"
              className="bg-green-500 text-white py-3 px-6 rounded-lg shadow-lg hover:bg-green-600 transform hover:scale-110 transition duration-300"
            >
              📧 Contact Support
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AccountIssuesPage;
