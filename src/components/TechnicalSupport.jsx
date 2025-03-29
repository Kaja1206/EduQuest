import React from 'react';
import { useSpring, animated } from 'react-spring'; // For animations

const TechnicalSupportPage = () => {
  const pageAnimation = useSpring({
    opacity: 1,
    transform: 'scale(1)',
    from: { opacity: 0, transform: 'scale(0.9)' },
    config: { tension: 200, friction: 20 },
  });

  const titleAnimation = useSpring({
    opacity: 1,
    transform: 'translateY(0)',
    from: { opacity: 0, transform: 'translateY(-20px)' },
    config: { tension: 150, friction: 25 },
  });

  const textAnimation = useSpring({
    opacity: 1,
    transform: 'translateY(0)',
    from: { opacity: 0, transform: 'translateY(20px)' },
    config: { tension: 150, friction: 25 },
    delay: 200,
  });

  const buttonHoverAnimation = {
    transform: 'scale(1.1)',
    transition: 'transform 0.2s ease-in-out',
  };

  return (
    <animated.div style={pageAnimation} className="flex justify-center items-center min-h-screen bg-gradient-to-br from-yellow-300 via-pink-300 to-purple-300">
      <div className="bg-white rounded-3xl shadow-xl p-6 w-[90%] max-w-3xl">
        <animated.h2 style={titleAnimation} className="text-center text-3xl font-extrabold text-blue-600 mb-4">
          🖥️ Tech Support for Kids! 🎮
        </animated.h2>
        <animated.p style={textAnimation} className="text-lg text-gray-700 mb-4">
          Uh-oh! Did something go wrong with your device? No worries, we're here to help you fix it super fast! 🚀
        </animated.p>

        <div className="space-y-4">
          <div className="bg-blue-100 p-4 rounded-lg shadow-lg">
            <animated.p style={textAnimation} className="text-xl text-blue-700 font-semibold">
              🔧 What Can We Fix?
            </animated.p>
            <ul className="list-disc pl-6 space-y-2">
              <li>💡 My device won't turn on! 😱</li>
              <li>⚠️ My game keeps crashing! 😵</li>
              <li>🌐 I can’t connect to Wi-Fi! 🙄</li>
              <li>🖥️ My screen is frozen! 😬</li>
              <li>📱 My app isn’t working right! 😢</li>
            </ul>
          </div>

          <div className="mt-4 text-center">
            <animated.p style={textAnimation} className="text-lg font-semibold text-gray-700 mb-4">
              Need help? Reach out and we'll help you!
            </animated.p>
            <div className="flex justify-center space-x-4">
              <a
                href="mailto:support@example.com"
                className="bg-blue-500 text-white py-2 px-6 rounded-lg shadow-lg hover:bg-blue-600 transform hover:scale-105 transition duration-200"
                style={buttonHoverAnimation}
              >
                📧 Email Us
              </a>
              <a
                href="tel:+18001234567"
                className="bg-green-500 text-white py-2 px-6 rounded-lg shadow-lg hover:bg-green-600 transform hover:scale-105 transition duration-200"
                style={buttonHoverAnimation}
              >
                📞 Call Us
              </a>
            </div>
          </div>

          <div className="mt-6">
            <animated.p style={textAnimation} className="text-lg font-semibold text-indigo-600">
              Still need more help?
            </animated.p>
            <animated.p style={textAnimation} className="text-md text-gray-600">
              Check out our <a href="/faqs" className="text-blue-600 underline">FAQ Section</a> for super easy fixes! 🛠️
            </animated.p>
          </div>
        </div>
      </div>
    </animated.div>
  );
};

export default TechnicalSupportPage;
