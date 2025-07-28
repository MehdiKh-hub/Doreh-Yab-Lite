import React, { useState, useEffect } from 'react';

const CourseList = () => {
    const [courses, setCourses] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Mock data برای تست
        setTimeout(() => {
            setCourses([
                {
                    id: 1,
                    title: 'دوره React جامع',
                    description: 'آموزش کامل React از صفر تا صد',
                    durationInHours: 40,
                    rank: 95,
                    subjectTitle: 'برنامه‌نویسی وب',
                    sourceTitle: 'آکادمی آنلاین',
                    teacherFullName: 'احمد محمدی'
                },
                {
                    id: 2,
                    title: 'دوره Node.js پیشرفته',
                    description: 'توسعه بک‌اند با Node.js',
                    durationInHours: 35,
                    rank: 88,
                    subjectTitle: 'برنامه‌نویسی بک‌اند',
                    sourceTitle: 'یودمی',
                    teacherFullName: 'سارا احمدی'
                },
                {
                    id: 3,
                    title: 'دوره Python برای علم داده',
                    description: 'تحلیل داده با Python',
                    durationInHours: 50,
                    rank: 92,
                    subjectTitle: 'علم داده',
                    sourceTitle: 'کورسرا',
                    teacherFullName: 'علی کریمی'
                }
            ]);
            setLoading(false);
        }, 1000);
    }, []);

    if (loading) {
        return (
            <div style={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                height: '300px',
                fontSize: '18px'
            }}>
                در حال بارگذاری دوره‌ها...
            </div>
        );
    }

    return (
        <div style={{ padding: '20px', maxWidth: '1200px', margin: '0 auto' }}>
            <div style={{
                display: 'flex',
                justifyContent: 'space-between',
                alignItems: 'center',
                marginBottom: '30px'
            }}>
                <h1 style={{ fontSize: '32px', color: '#333' }}>لیست دوره‌ها</h1>
                <div style={{ display: 'flex', gap: '10px' }}>
                    <input
                        type="text"
                        placeholder="جستجو در دوره‌ها..."
                        style={{
                            padding: '8px 12px',
                            border: '1px solid #ddd',
                            borderRadius: '4px',
                            fontSize: '14px',
                            width: '200px'
                        }}
                    />
                    <select style={{
                        padding: '8px 12px',
                        border: '1px solid #ddd',
                        borderRadius: '4px',
                        fontSize: '14px'
                    }}>
                        <option value="rank">مرتب‌سازی بر اساس رتبه</option>
                        <option value="title">مرتب‌سازی بر اساس عنوان</option>
                        <option value="duration">مرتب‌سازی بر اساس مدت</option>
                    </select>
                </div>
            </div>

            <div style={{
                display: 'grid',
                gridTemplateColumns: 'repeat(auto-fill, minmax(350px, 1fr))',
                gap: '20px'
            }}>
                {courses.map(course => (
                    <div key={course.id} style={{
                        backgroundColor: 'white',
                        boxShadow: '0 2px 8px rgba(0,0,0,0.1)',
                        borderRadius: '8px',
                        padding: '20px',
                        border: '1px solid #eee'
                    }}>
                        <div style={{
                            display: 'flex',
                            justifyContent: 'space-between',
                            alignItems: 'flex-start',
                            marginBottom: '10px'
                        }}>
                            <h3 style={{ margin: '0', color: '#333', fontSize: '18px' }}>
                                {course.title}
                            </h3>
                            <span style={{
                                backgroundColor: '#28a745',
                                color: 'white',
                                padding: '4px 8px',
                                borderRadius: '12px',
                                fontSize: '12px',
                                fontWeight: 'bold'
                            }}>
                                رتبه: {course.rank}
                            </span>
                        </div>

                        <p style={{
                            margin: '10px 0',
                            color: '#666',
                            fontSize: '14px',
                            lineHeight: '1.5'
                        }}>
                            {course.description}
                        </p>

                        <div style={{ marginBottom: '15px' }}>
                            <p style={{ margin: '5px 0', color: '#555', fontSize: '14px' }}>
                                <strong>استاد:</strong> {course.teacherFullName}
                            </p>
                            <p style={{ margin: '5px 0', color: '#555', fontSize: '14px' }}>
                                <strong>موضوع:</strong> {course.subjectTitle}
                            </p>
                            <p style={{ margin: '5px 0', color: '#555', fontSize: '14px' }}>
                                <strong>منبع:</strong> {course.sourceTitle}
                            </p>
                            <p style={{ margin: '5px 0', color: '#555', fontSize: '14px' }}>
                                <strong>مدت زمان:</strong> {course.durationInHours} ساعت
                            </p>
                        </div>

                        <div style={{ display: 'flex', gap: '10px', justifyContent: 'flex-end' }}>
                            <button style={{
                                backgroundColor: '#007bff',
                                color: 'white',
                                padding: '8px 16px',
                                border: 'none',
                                borderRadius: '4px',
                                cursor: 'pointer',
                                fontSize: '14px'
                            }}>
                                مشاهده جزئیات
                            </button>
                            <button style={{
                                backgroundColor: '#28a745',
                                color: 'white',
                                padding: '8px 16px',
                                border: 'none',
                                borderRadius: '4px',
                                cursor: 'pointer',
                                fontSize: '14px'
                            }}>
                                ثبت نام
                            </button>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default CourseList;