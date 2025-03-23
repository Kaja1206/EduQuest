module.exports = {
  content: [
    './src/**/*.{html,js,jsx,ts,tsx}', // Adjust the path based on your project structure
  ],
  theme: {
    extend: {
      animation: {
        fall: "fall 3s ease-out forwards", // Faster animation (3 seconds)
      },
      keyframes: {
        fall: {
          "0%": {
            transform: "translateY(-100%) rotate(0deg)",
            opacity: 0,
          },
          "50%": {
            transform: "translateY(50vh) rotate(180deg)",
            opacity: 1,
          },
          "100%": {
            transform: "translateY(0) rotate(360deg)",
            opacity: 1,
          },
        },
      },
      fontSize: {
        "5xl": "3rem",  // Adjusted size for better fit
        "6xl": "5rem", // Medium size for larger screens
        "7xl": "7rem", // Larger size for extra large screens
        "8xl": "8rem", // Extra large size
      },
    },
  },
  plugins: [],
};
