import axios from "axios";

const API_URL = "http://localhost:5000/api/auth"; // Adjust for deployment

// Set default configurations
axios.defaults.withCredentials = true; // Allows sending cookies with requests

export const registerUser = async (name, email, password) => {
  try {
    const response = await axios.post(`${API_URL}/register`, {
      name,
      email,
      password,
    });
    return response.data;
  } catch (error) {
    console.error("Registration Error:", error.response?.data || error.message);
    return null;
  }
};

export const loginUser = async (email, password) => {
  try {
    const response = await axios.post(`${API_URL}/login`, { email, password });
    return response.data;
  } catch (error) {
    console.error("Login Error:", error.response?.data || error.message);
    return null;
  }
};

export const logoutUser = async () => {
  try {
    await axios.post(`${API_URL}/logout`);
  } catch (error) {
    console.error("Logout Error:", error.response?.data || error.message);
  }
};

export const fetchUserProfile = async () => {
  try {
    const response = await axios.get(`${API_URL}/profile`);
    return response.data;
  } catch (error) {
    console.error(
      "Fetch User Profile Error:",
      error.response?.data || error.message
    );
    return null;
  }
};
