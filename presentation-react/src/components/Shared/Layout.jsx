import { Link } from 'react-router-dom'

const Layout = ({ children }) => {
  return (
    <div className="min-h-screen bg-gray-50" dir="rtl">
      <nav className="bg-blue-600 text-white p-4">
        <div className="container mx-auto flex justify-between items-center">
          <h1 className="text-xl font-bold">دوره یاب لایت</h1>
          <div className="space-x-4 space-x-reverse">
            <Link to="/students" className="hover:bg-blue-700 px-3 py-2 rounded">دانش آموزان</Link>
            <Link to="/courses" className="hover:bg-blue-700 px-3 py-2 rounded">دوره ها</Link>
            <Link to="/teachers" className="hover:bg-blue-700 px-3 py-2 rounded">معلمان</Link>
          </div>
        </div>
      </nav>
      <main className="container mx-auto p-4">
        {children}
      </main>
    </div>
  )
}

export default Layout