import api from './api';

export const courseService = {
    // دریافت همه دوره‌ها با جستجو و مرتب‌سازی
    getAll: async (search = '', sortBy = 'rank') => {
        const response = await api.get('/courses', {
            params: { search, sortBy }
        });
        return response.data;
    },

    // دریافت دوره‌های برتر
    getTopRanked: async () => {
        const response = await api.get('/courseranking/top-courses');
        return response.data;
    }
};