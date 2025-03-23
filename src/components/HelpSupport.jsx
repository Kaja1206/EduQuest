import React from "react";

const HelpSupport = () => {
  return (
    <div className="p-6 bg-blue-100">
      <h1 className="text-3xl font-bold text-center text-blue-700 mb-6">
        Help & Support
      </h1>
      <div className="mb-4">
        <h2 className="text-2xl font-semibold text-blue-600 mb-2">FAQs</h2>
        <ul className="list-disc ml-6">
          <li className="text-xl">How do I start using EduQuest?</li>
          <li className="text-xl">
            What should I do if my child faces difficulties?
          </li>
          <li className="text-xl">How can I track my child's progress?</li>
        </ul>
      </div>
      <div>
        <h2 className="text-2xl font-semibold text-blue-600 mb-2">
          Contact Support
        </h2>
        <p className="text-xl">Email us at: support@eduquest.com</p>
      </div>
    </div>
  );
};

export default HelpSupport;
