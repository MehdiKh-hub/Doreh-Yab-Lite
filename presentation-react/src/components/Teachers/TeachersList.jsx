import { useState, useEffect } from 'react'
import { teachersApi } from '../../services/api'

const TeachersList = () => {
  const [teachers, setTeachers] = useState([])
  const [loading, setLoading] = useState(true)
  const [search, setSearch] = useState('')
  const [sortBy, setSortBy] = useState('rank')

  useEffect(() => {
    fetchTeachers()
  }, [search, sortBy])

  const fetchTeachers = async () => {
    try {
      const response = await teachersApi.getAll(search, sortBy)
      setTeachers(response.data)
    } catch (error) {
      console.error('Error fetching teachers:', error)
    } finally {
      setLoading(false)
    }
  }

  if (loading) return <div className="text-center p-4">در حال بارگذاری...</div>

  return (
    <div>
      <h2 className="text-2xl font-bold mb-6">معلمان</h2>
      
      <div className="mb-6 flex gap-4">
        <input
          type="text"
          placeholder="جستجو در معلمان..."
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
          <option value="name">مرتب سازی بر اساس نام</option>
        </select>
      </div>

      <div className="grid gap-4">
        {teachers.map(teacher => (
          <div key={teacher.id} className="bg-white p-4 rounded shadow">
            <h3 className="text-lg font-semibold mb-2">{teacher.fullName}</h3>
            <p className="text-gray-600 mb-2">{teacher.bio}</p>
            <div className="grid grid-cols-2 gap-4 text-sm">
              <p><strong>ایمیل:</strong> {teacher.email}</p>
              <p><strong>رتبه:</strong> {teacher.rank}</p>
              <p><strong>تعداد دوره ها:</strong> {teacher.coursesCount}</p>
            </div>
            {teacher.courseTitles && teacher.courseTitles.length > 0 && (
              <div className="mt-2">
                <strong>دوره ها:</strong>
                <ul className="list-disc list-inside text-sm text-gray-600">
                  {teacher.courseTitles.map((title, index) => (
                    <li key={index}>{title}</li>
                  ))}
                </ul>
              </div>
            )}
          </div>
        ))}
      </div>
    </div>
  )
}

export default TeachersList