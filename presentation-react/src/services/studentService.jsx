import api from './api.jsx';

export const studentService = {
    getAll: async () => {
        try {
            const response = await api.get('/students');
            return response.data;
        } catch (error) {
            console.error('Error fetching students:', error);
            throw new Error('خطا در دریافت لیست دانشجویان');
        }
    },

    getById: async (id) => {
        try {
            const response = await api.get(`/students/${id}`);
            return response.data;
        } catch (error) {
            console.error('Error fetching student:', error);
            throw new Error('خطا در دریافت اطلاعات دانشجو');
        }
    },

    create: async (studentData) => {
        try {
            const response = await api.post('/students', studentData);
            return response.data;
        } catch (error) {
            console.error('Error creating student:', error);
            throw new Error('خطا در ایجاد دانشجو');
        }
    },

    update: async (id, studentData) => {
        try {
            const response = await api.put(`/students/${id}`, studentData);
            return response.data;
        } catch (error) {
            console.error('Error updating student:', error);
            throw new Error('خطا در به‌روزرسانی دانشجو');
        }
    },

    delete: async (id) => {
        try {
            const response = await api.delete(`/students/${id}`);
            return response.data;
        } catch (error) {
            console.error('Error deleting student:', error);
            throw new Error('خطا در حذف دانشجو');
        }
    }
};