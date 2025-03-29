import React from "react";
import { motion } from "framer-motion";

const courses = [
  {
    id: 1,
    title: "Math Mastery",
    description:
      "Master the fundamentals of mathematics through interactive lessons.",
    buttonText: "Start Learning",
  },
  {
    id: 2,
    title: "Science Discovery",
    description:
      "Explore the exciting world of science with fun experiments and quizzes.",
    buttonText: "Enroll Now",
  },
  {
    id: 3,
    title: "English Language Arts",
    description: "Improve your reading, writing, and comprehension skills.",
    buttonText: "Start Course",
  },
  {
    id: 4,
    title: "Creative Arts",
    description:
      "Learn how to express yourself through painting, drawing, and more.",
    buttonText: "Join Now",
  },
  {
    id: 5,
    title: "History Explorer",
    description:
      "Dive into the rich history of the world with interactive lessons.",
    buttonText: "Enroll Today",
  },
  {
    id: 6,
    title: "Puzzle & Brain Teasers",
    description: "Sharpen your mind with challenging puzzles and brain games.",
    buttonText: "Start Solving",
  },
];

const Courses = () => {
  return (
    <div className="min-h-screen bg-gradient-to-b from-purple-500 via-indigo-600 to-blue-500 py-16">
      <div className="container mx-auto text-center px-6">
        <motion.h1
          className="text-5xl font-extrabold text-white mb-16 drop-shadow-xl"
          initial={{ scale: 0.8, opacity: 0 }}
          animate={{ scale: 1, opacity: 1 }}
          transition={{ duration: 1.5, ease: "easeInOut" }}
        >
          Explore Our Fun Courses
        </motion.h1>

        <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-12">
          {courses.map((course) => (
            <motion.div
              key={course.id}
              className="relative bg-white text-black py-8 px-6 rounded-3xl shadow-lg transform transition-all duration-500 hover:scale-105 hover:shadow-2xl"
              initial={{ opacity: 0, y: 50 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.8, delay: course.id * 0.2 }}
            >
              <h2 className="text-3xl font-bold text-transparent bg-clip-text bg-gradient-to-r from-pink-400 to-yellow-500 mb-4">
                {course.title}
              </h2>
              <p className="text-lg font-medium mb-6">{course.description}</p>
              <motion.button
                className="bg-gradient-to-r from-yellow-400 to-orange-500 text-white px-8 py-4 rounded-full text-lg font-semibold transform transition-all duration-300 hover:scale-105 hover:bg-gradient-to-l hover:shadow-xl"
                whileHover={{ scale: 1.1 }}
                whileTap={{ scale: 0.95 }}
              >
                {course.buttonText}
              </motion.button>
            </motion.div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Courses;
