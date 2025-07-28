import React, { useState, useEffect } from 'react';

const StudentForm = ({ student, onSubmit, onCancel }) => {
    const [formData, setFormData] = useState({
        fullName: '',
        age: '',
        level: ''
    });

    useEffect(() => {
        if (student) {
            setFormData({
                fullName: student.fullName || '',
                age: student.age || '',
                level: student.level || ''
            });
        }
    }, [student]);

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit({
            ...formData,
            age: parseInt(formData.age)
        });
    };

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    return (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center">
            <div className="bg-white p-6 rounded-lg w-96">
                <h2 className="text-xl font-bold mb-4">
                    {student ? 'ویرایش دانشجو' : 'افزودن دانشجوی جدید'}
                </h2>

                <form onSubmit={handleSubmit}>
                    <div className="mb-4">
                        <label className="block text-sm font-medium mb-2">نام و نام خانوادگی</label>
                        <input
                            type="text"
                            name="fullName"
                            value={formData.fullName}
                            onChange={handleChange}
                            required
                            className="w-full border border-gray-300 rounded px-3 py-2"
                        />
                    </div>

                    <div className="mb-4">
                        <label className="block text-sm font-medium mb-2">سن</label>
                        <input
                            type="number"
                            name="age"
                            value={formData.age}
                            onChange={handleChange}
                            required
                            className="w-full border border-gray-300 rounded px-3 py-2"
                        />
                    </div>

                    <div className="mb-4">
                        <label className="block text-sm font-medium mb-2">سطح</label>
                        <input
                            type="text"
                            name="level"
                            value={formData.level}
                            onChange={handleChange}
                            required
                            className="w-full border border-gray-300 rounded px-3 py-2"
                        />
                    </div>

                    <div className="flex justify-end gap-2">
                        <button
                            type="button"
                            onClick={onCancel}
                            className="px-4 py-2 text-gray-600 border border-gray-300 rounded hover:bg-gray-50"
                        >
                            انصراف
                        </button>
                        <button
                            type="submit"
                            className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
                        >
                            {student ? 'ویرایش' : 'افزودن'}
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default StudentForm;