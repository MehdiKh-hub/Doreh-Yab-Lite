import api from './api';

export const studentService = {
    // دریافت همه دانشجویان
    getAll: async () => {
        const response = await api.get('/students');
        return response.data;
    },

    // دریافت دانشجو بر اساس ID
    getById: async (id) => {
        const response = await api.get(`/students/${id}`);
        return response.data;
    },

    // ایجاد دانشجوی جدید
    create: async (studentData) => {
        const response = await api.post('/students', studentData);
        return response.data;
    },

    // به‌روزرسانی دانشجو
    update: async (id, studentData) => {
        const response = await api.put(`/students/${id}`, studentData);
        return response.data;
    },

    // حذف دانشجو
    delete: async (id) => {
        const response = await api.delete(`/students/${id}`);
        return response.data;
    }
};