import { useState, useEffect } from 'react'
import { studentsApi } from '../../services/api'

const StudentsList = () => {
  const [students, setStudents] = useState([])
  const [loading, setLoading] = useState(true)
  const [showForm, setShowForm] = useState(false)
  const [editingStudent, setEditingStudent] = useState(null)
  const [formData, setFormData] = useState({ fullName: '', age: '', level: '' })

  useEffect(() => {
    fetchStudents()
  }, [])

  const fetchStudents = async () => {
    try {
      const response = await studentsApi.getAll()
      setStudents(response.data)
    } catch (error) {
      console.error('Error fetching students:', error)
    } finally {
      setLoading(false)
    }
  }

  const handleSubmit = async (e) => {
    e.preventDefault()
    try {
      if (editingStudent) {
        await studentsApi.update(editingStudent.id, formData)
      } else {
        await studentsApi.create(formData)
      }
      fetchStudents()
      setShowForm(false)
      setEditingStudent(null)
      setFormData({ fullName: '', age: '', level: '' })
    } catch (error) {
      console.error('Error saving student:', error)
    }
  }

  const handleEdit = (student) => {
    setEditingStudent(student)
    setFormData({ fullName: student.fullName, age: student.age, level: student.level })
    setShowForm(true)
  }

  const handleDelete = async (id) => {
    if (window.confirm('آیا مطمئن هستید؟')) {
      try {
        await studentsApi.delete(id)
        fetchStudents()
      } catch (error) {
        console.error('Error deleting student:', error)
      }
    }
  }

  if (loading) return <div className="text-center p-4">در حال بارگذاری...</div>

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-2xl font-bold">دانش آموزان</h2>
        <button 
          onClick={() => setShowForm(true)}
          className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
        >
          افزودن دانش آموز
        </button>
      </div>

      {showForm && (
        <div className="mb-6 p-4 border rounded bg-white">
          <form onSubmit={handleSubmit}>
            <div className="grid grid-cols-3 gap-4">
              <input
                type="text"
                placeholder="نام کامل"
                value={formData.fullName}
                onChange={(e) => setFormData({...formData, fullName: e.target.value})}
                className="border p-2 rounded"
                required
              />
              <input
                type="number"
                placeholder="سن"
                value={formData.age}
                onChange={(e) => setFormData({...formData, age: e.target.value})}
                className="border p-2 rounded"
                required
              />
              <input
                type="text"
                placeholder="سطح"
                value={formData.level}
                onChange={(e) => setFormData({...formData, level: e.target.value})}
                className="border p-2 rounded"
                required
              />
            </div>
            <div className="mt-4 space-x-2 space-x-reverse">
              <button type="submit" className="bg-green-500 text-white px-4 py-2 rounded">
                {editingStudent ? 'ویرایش' : 'افزودن'}
              </button>
              <button 
                type="button" 
                onClick={() => {setShowForm(false); setEditingStudent(null)}}
                className="bg-gray-500 text-white px-4 py-2 rounded"
              >
                انصراف
              </button>
            </div>
          </form>
        </div>
      )}

      <div className="grid gap-4">
        {students.map(student => (
          <div key={student.id} className="bg-white p-4 rounded shadow">
            <div className="flex justify-between items-center">
              <div>
                <h3 className="text-lg font-semibold">{student.fullName}</h3>
                <p>سن: {student.age} - سطح: {student.level}</p>
              </div>
              <div className="space-x-2 space-x-reverse">
                <button 
                  onClick={() => handleEdit(student)}
                  className="bg-yellow-500 text-white px-3 py-1 rounded"
                >
                  ویرایش
                </button>
                <button 
                  onClick={() => handleDelete(student.id)}
                  className="bg-red-500 text-white px-3 py-1 rounded"
                >
                  حذف
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  )
}

export default StudentsList