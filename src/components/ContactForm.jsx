import React, { useState } from 'react';

const ContactFormPage = () => {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    message: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    alert('Thank you for reaching out! 😊');
    // Here you can handle form submission (e.g., sending the form data to an API)
  };

  return (
    <div className="flex justify-center items-center min-h-screen bg-gradient-to-br from-pink-400 via-purple-400 to-blue-500">
      <div className="bg-white rounded-3xl shadow-xl p-6 w-full sm:w-[85%] md:w-[65%] lg:w-[55%] max-w-xl">
        <h2 className="text-center text-3xl font-extrabold text-pink-600 mb-4">
          🧸 Contact Us! We’re here to help! 🎮
        </h2>
        <p className="text-center text-sm text-gray-700 mb-4">
          Need help or have a question? Fill out the form below and we’ll get back to you in no time! 🚀
        </p>

        <form onSubmit={handleSubmit} className="space-y-3">
          <div className="space-y-1">
            <label htmlFor="name" className="text-lg font-semibold text-pink-700">What’s your name? 👋</label>
            <input
              type="text"
              id="name"
              name="name"
              value={formData.name}
              onChange={handleChange}
              className="w-full p-2 bg-pink-100 rounded-lg shadow-lg placeholder-gray-400 focus:outline-none focus:ring-2 focus:ring-pink-500"
              placeholder="Your Name"
              required
            />
          </div>

          <div className="space-y-1">
            <label htmlFor="email" className="text-lg font-semibold text-pink-700">What's your email? 📧</label>
            <input
              type="email"
              id="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              className="w-full p-2 bg-blue-100 rounded-lg shadow-lg placeholder-gray-400 focus:outline-none focus:ring-2 focus:ring-blue-500"
              placeholder="Your Email"
              required
            />
          </div>

          <div className="space-y-1">
            <label htmlFor="message" className="text-lg font-semibold text-pink-700">Tell us your question or message! 📝</label>
            <textarea
              id="message"
              name="message"
              value={formData.message}
              onChange={handleChange}
              className="w-full p-2 bg-yellow-100 rounded-lg shadow-lg placeholder-gray-400 focus:outline-none focus:ring-2 focus:ring-yellow-500"
              placeholder="Your message"
              rows="3"
              required
            />
          </div>

          <div className="text-center">
            <button
              type="submit"
              className="bg-pink-500 text-white py-2 px-6 rounded-lg shadow-xl transform hover:scale-105 hover:bg-pink-600 transition duration-300 ease-in-out"
            >
              🚀 Send Message
            </button>
          </div>
        </form>

        <div className="mt-4 text-center">
          <p className="text-sm text-gray-600">
            Or reach us via our <a href="mailto:support@example.com" className="text-blue-500 underline">email</a> if you need more help! 📧
          </p>
        </div>
      </div>
    </div>
  );
};

export default ContactFormPage;
