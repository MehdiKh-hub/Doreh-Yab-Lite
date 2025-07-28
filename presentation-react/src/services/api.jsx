import axios from "axios";

// آدرس API خود را بر اساس تنظیمات بک‌اند قرار دهید
const API_BASE_URL = "https://localhost:5001/api";

const api = axios.create({
    baseURL: API_BASE_URL,
    headers: {
        "Content-Type": "application/json",
    },
    withCredentials: false, // اگر به کوکی نیاز ندارید
});

export default api;