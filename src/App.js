import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";

// Importing components
import Home from "./components/Home";
import Auth from "./components/Auth";
import GameSelection from "./components/GameSelection";
import Dashboard from "./components/Dashboard";
import ParentalDashboard from "./components/ParentalDashboard";
import Career from "./components/Career";
import Register from "./components/Register";


import Achievements from "./components/Achivements";
import Rewards from "./components/Rewards";
import Progress from "./components/Progress";
import Courses from "./components/Courses";
import Challenges from "./components/Challanges";
import ContactForm from './components/ContactForm';



import AccountIssues from './components/AccountIssues';

import ContactUs from './components/ContactUs';





function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/auth" element={<Auth />} />
          <Route path="/games" element={<GameSelection />} />
          <Route path="/challenges" element={<Challenges />} />
          <Route path="/contact-Form" element={<ContactForm />} />
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/parental-dashboard" element={<ParentalDashboard />} />
          <Route path="/contact-us" element={<ContactUs />} />
          <Route path="/rewards" element={<Rewards />} /> 
          <Route path="/progress" element={<Progress />} />
          <Route path="/courses" element={<Courses />} />
          <Route path="/career" element={<Career />} />
          <Route path="/register" element={<Register/>} />
          
          <Route path="/achievements" element={<Achievements />} />
          
          
          
          
          
          
          
          
          <Route path="/account-issues" element={<AccountIssues />} />
          
      
          
          
        </Routes>
      </div>
    </Router>
  );
}

export default App;
