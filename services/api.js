const API_URL = "http://localhost:5000/api"; // Backend URL

export const apiRequest = async (endpoint, method = "GET", body = null) => {
  const token = localStorage.getItem("token"); // Get JWT token
  const headers = {
    "Content-Type": "application/json",
    Authorization: `Bearer ${token}`, // Attach token
  };

  const options = { method, headers };
  if (body) options.body = JSON.stringify(body);

  const response = await fetch(`${API_URL}${endpoint}`, options);
  return response.json();
};
