import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Layout from './components/Shared/Layout'
import StudentsList from './components/Students/StudentsList'
import CoursesList from './components/Courses/CoursesList'
import TeachersList from './components/Teachers/TeachersList'

function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/" element={<StudentsList />} />
          <Route path="/students" element={<StudentsList />} />
          <Route path="/courses" element={<CoursesList />} />
          <Route path="/teachers" element={<TeachersList />} />
        </Routes>
      </Layout>
    </Router>
  )
}

export default App