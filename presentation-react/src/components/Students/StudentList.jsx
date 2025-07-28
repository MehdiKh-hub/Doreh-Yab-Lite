import React, { useState, useEffect } from 'react';
import { studentService } from '../../services/studentService';
import StudentCard from './StudentCard';
import StudentForm from './StudentForm';

const StudentList = () => {
    const [students, setStudents] = useState([]);
    const [loading, setLoading] = useState(true);
    const [showForm, setShowForm] = useState(false);
    const [selectedStudent, setSelectedStudent] = useState(null);

    useEffect(() => {
        loadStudents();
    }, []);

    const loadStudents = async () => {
        try {
            setLoading(true);
            const data = await studentService.getAll();
            setStudents(data);
        } catch (error) {
            console.error('خطا در دریافت دانشجویان:', error);
        } finally {
            setLoading(false);
        }
    };

    const handleCreate = async (studentData) => {
        try {
            await studentService.create(studentData);
            loadStudents();
            setShowForm(false);
        } catch (error) {
            console.error('خطا در ایجاد دانشجو:', error);
        }
    };

    const handleUpdate = async (id, studentData) => {
        try {
            await studentService.update(id, studentData);
            loadStudents();
            setSelectedStudent(null);
            setShowForm(false);
        } catch (error) {
            console.error('خطا در به‌روزرسانی دانشجو:', error);
        }
    };

    const handleDelete = async (id) => {
        if (window.confirm('آیا مطمئن هستید؟')) {
            try {
                await studentService.delete(id);
                loadStudents();
            } catch (error) {
                console.error('خطا در حذف دانشجو:', error);
            }
        }
    };

    const handleEdit = (student) => {
        setSelectedStudent(student);
        setShowForm(true);
    };

    if (loading) return <div>در حال بارگذاری...</div>;

    return (
        <div className="container mx-auto p-4">
            <div className="flex justify-between items-center mb-6">
                <h1 className="text-3xl font-bold">دانشجویان</h1>
                <button
                    onClick={() => setShowForm(true)}
                    className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
                >
                    افزودن دانشجوی جدید
                </button>
            </div>

            {showForm && (
                <StudentForm
                    student={selectedStudent}
                    onSubmit={selectedStudent ?
                        (data) => handleUpdate(selectedStudent.id, data) :
                        handleCreate
                    }
                    onCancel={() => {
                        setShowForm(false);
                        setSelectedStudent(null);
                    }}
                />
            )}

            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                {students.map(student => (
                    <StudentCard
                        key={student.id}
                        student={student}
                        onEdit={handleEdit}
                        onDelete={handleDelete}
                    />
                ))}
            </div>
        </div>
    );
};

export default StudentList;