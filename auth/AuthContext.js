import { createContext, useContext, useState, useEffect } from "react";
import { apiRequest } from "../services/api";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) fetchUserData();
  }, []);

  const fetchUserData = async () => {
    const data = await apiRequest("/auth/me");
    if (data) setUser(data);
  };

  const login = async (email, password) => {
    const data = await apiRequest("/auth/login", "POST", { email, password });
    if (data.token) {
      localStorage.setItem("token", data.token);
      fetchUserData();
    }
  };

  const logout = () => {
    localStorage.removeItem("token");
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
