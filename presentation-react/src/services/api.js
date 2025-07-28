import axios from 'axios'

const API_BASE_URL = 'https://localhost:7032/api'

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json'
  }
})

export const studentsApi = {
  getAll: () => api.get('/students'),
  getById: (id) => api.get(`/students/${id}`),
  create: (student) => api.post('/students', student),
  update: (id, student) => api.put(`/students/${id}`, student),
  delete: (id) => api.delete(`/students/${id}`)
}

export const coursesApi = {
  getAll: (search, sortBy = 'rank') => api.get('/courses', { params: { search, sortBy } })
}

export const teachersApi = {
  getAll: (search, sortBy = 'rank') => api.get('/teacher', { params: { search, sortBy } })
}

export const courseRankingApi = {
  getTopCourses: () => api.get('/courseranking/top-courses')
}