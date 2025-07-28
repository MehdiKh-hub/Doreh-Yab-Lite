import React from 'react';

const StudentCard = ({ student, onEdit, onDelete }) => {
    return (
        <div className="bg-white shadow-md rounded-lg p-4 border">
            <h3 className="text-lg font-semibold mb-2">{student.fullName}</h3>
            <p className="text-gray-600 mb-1">سن: {student.age}</p>
            <p className="text-gray-600 mb-4">سطح: {student.level}</p>

            <div className="flex justify-end gap-2">
                <button
                    onClick={() => onEdit(student)}
                    className="px-3 py-1 bg-yellow-500 text-white rounded text-sm hover:bg-yellow-600"
                >
                    ویرایش
                </button>
                <button
                    onClick={() => onDelete(student.id)}
                    className="px-3 py-1 bg-red-500 text-white rounded text-sm hover:bg-red-600"
                >
                    حذف
                </button>
            </div>
        </div>
    );
};

export default StudentCard;