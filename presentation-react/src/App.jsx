import React, { useState } from 'react';
import StudentList from './components/Students/StudentList.jsx';
import CourseList from './components/Courses/CourseList.jsx';

function App() {
    const [currentPage, setCurrentPage] = useState('students');

    const renderPage = () => {
        switch (currentPage) {
            case 'students':
                return <StudentList />;
            case 'courses':
                return <CourseList />;
            default:
                return <StudentList />;
        }
    };

    return (
        <div style={{
            minHeight: '100vh',
            backgroundColor: '#f8f9fa',
            fontFamily: 'Arial, sans-serif'
        }}>
            <header style={{
                backgroundColor: '#007bff',
                color: 'white',
                padding: '15px 0',
                boxShadow: '0 2px 4px rgba(0,0,0,0.1)'
            }}>
                <div style={{ maxWidth: '1200px', margin: '0 auto', padding: '0 20px' }}>
                    <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                        <h1 style={{ margin: 0, fontSize: '24px' }}>
                            سیستم مدیریت دوره‌یاب
                        </h1>

                        <nav>
                            <button
                                onClick={() => setCurrentPage('students')}
                                style={{
                                    backgroundColor: currentPage === 'students' ? '#0056b3' : 'transparent',
                                    color: 'white',
                                    border: '1px solid rgba(255,255,255,0.3)',
                                    padding: '8px 16px',
                                    margin: '0 5px',
                                    borderRadius: '4px',
                                    cursor: 'pointer',
                                    fontSize: '14px'
                                }}
                            >
                                دانشجویان
                            </button>
                            <button
                                onClick={() => setCurrentPage('courses')}
                                style={{
                                    backgroundColor: currentPage === 'courses' ? '#0056b3' : 'transparent',
                                    color: 'white',
                                    border: '1px solid rgba(255,255,255,0.3)',
                                    padding: '8px 16px',
                                    margin: '0 5px',
                                    borderRadius: '4px',
                                    cursor: 'pointer',
                                    fontSize: '14px'
                                }}
                            >
                                دوره‌ها
                            </button>
                        </nav>
                    </div>
                </div>
            </header>

            <main>
                {renderPage()}
            </main>
        </div>
    );
}

export default App;