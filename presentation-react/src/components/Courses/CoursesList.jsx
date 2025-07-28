import { useState, useEffect } from 'react'
import { coursesApi } from '../../services/api'

const CoursesList = () => {
  const [courses, setCourses] = useState([])
  const [loading, setLoading] = useState(true)
  const [search, setSearch] = useState('')
  const [sortBy, setSortBy] = useState('rank')

  useEffect(() => {
    fetchCourses()
  }, [search, sortBy])

  const fetchCourses = async () => {
    try {
      const response = await coursesApi.getAll(search, sortBy)
      setCourses(response.data)
    } catch (error) {
      console.error('Error fetching courses:', error)
    } finally {
      setLoading(false)
    }
  }

  if (loading) return <div className="text-center p-4">در حال بارگذاری...</div>

  return (
    <div>
      <h2 className="text-2xl font-bold mb-6">دوره ها</h2>
      
      <div className="mb-6 flex gap-4">
        <input
          type="text"
          placeholder="جستجو در دوره ها..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          className="flex-1 border p-2 rounded"
        />
        <select
          value={sortBy}
          onChange={(e) => setSortBy(e.target.value)}
          className="border p-2 rounded"
        >
          <option value="rank">مرتب سازی بر اساس رتبه</option>
          <option value="title">مرتب سازی بر اساس عنوان</option>
          <option value="duration">مرتب سازی بر اساس مدت</option>
        </select>
      </div>

      <div className="grid gap-4">
        {courses.map(course => (
          <div key={course.id} className="bg-white p-4 rounded shadow">
            <h3 className="text-lg font-semibold mb-2">{course.title}</h3>
            <p className="text-gray-600 mb-2">{course.description}</p>
            <div className="grid grid-cols-2 gap-4 text-sm">
              <p><strong>مدت:</strong> {course.durationInHours} ساعت</p>
              <p><strong>رتبه:</strong> {course.rank}</p>
              <p><strong>موضوع:</strong> {course.subjectTitle}</p>
              <p><strong>منبع:</strong> {course.sourceTitle}</p>
              <p><strong>معلم:</strong> {course.teacherFullName}</p>
            </div>
          </div>
        ))}
      </div>
    </div>
  )
}

export default CoursesList