import React from 'react';

const ContactUsPage = () => {
  return (
    <div className="flex justify-center items-center min-h-screen bg-gradient-to-br from-blue-400 via-green-300 to-yellow-300">
      <div className="bg-white rounded-3xl shadow-2xl p-8 w-[90%] sm:w-96 max-w-lg transform hover:scale-105 transition duration-300 ease-in-out">
        <h2 className="text-center text-4xl font-extrabold text-blue-600 mb-6 animate__animated animate__fadeIn animate__delay-1s">
          📞 Contact Us 📞
        </h2>
        <p className="text-lg text-gray-700 mb-6 animate__animated animate__fadeIn animate__delay-2s">
          We'd love to hear from you! Reach out for any queries or support.
        </p>
        <div className="space-y-6">
          <div className="space-y-2">
            <p className="text-2xl text-blue-700 font-semibold animate__animated animate__fadeIn animate__delay-3s">📧 Email</p>
            <p className="text-lg text-gray-700 animate__animated animate__fadeIn animate__delay-4s">
              <a href="mailto:support@example.com" className="text-blue-500 hover:text-blue-600 transform hover:scale-105 transition duration-200">
                support@example.com
              </a>
            </p>
          </div>
          <div className="space-y-2">
            <p className="text-2xl text-blue-700 font-semibold animate__animated animate__fadeIn animate__delay-5s">📞 Phone</p>
            <p className="text-lg text-gray-700 animate__animated animate__fadeIn animate__delay-6s">
              <a href="tel:+18001234567" className="text-blue-500 hover:text-blue-600 transform hover:scale-105 transition duration-200">
                +1 (800) 123-4567
              </a>
            </p>
          </div>
        </div>

        <div className="mt-6 text-center">
          <a
            href="/contact-form"
            className="bg-blue-500 text-white py-3 px-8 rounded-lg shadow-lg hover:bg-blue-600 transform hover:scale-110 transition duration-300"
          >
            📝 Reach Out
          </a>
        </div>
      </div>
    </div>
  );
};

export default ContactUsPage;
