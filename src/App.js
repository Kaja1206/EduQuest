import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";

// Importing components
import Home from "./components/Home";
import Auth from "./components/Auth";
import GameSelection from "./components/GameSelection";
import Dashboard from "./components/Dashboard";
import ParentalDashboard from "./components/ParentalDashboard";
import ContactUs from './components/ContactUs';


import Achievements from "./components/Achivements";





import AccountIssues from './components/AccountIssues';







function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/auth" element={<Auth />} />
          <Route path="/games" element={<GameSelection />} />
          
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/parental-dashboard" element={<ParentalDashboard />} />
          <Route path="/contact-us" element={<ContactUs />} />
          
          
          <Route path="/achievements" element={<Achievements />} />
          
          
          
          
          
          
          
          
          <Route path="/account-issues" element={<AccountIssues />} />
          
      
          
          
        </Routes>
      </div>
    </Router>
  );
}

export default App;
