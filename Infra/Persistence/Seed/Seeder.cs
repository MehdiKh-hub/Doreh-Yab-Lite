using Bogus;
using Domain.Entities;

namespace Infra.Persistence.Seed
{
    public class Seeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (context.Students.Any()) return;

            var faker = new Faker("en");

            // 1. Subject
            var subjects = new List<Subject>
            {
                new Subject("C#", 1, "C# Programming"),
                new Subject("JavaScript", 2, "JS Programming"),
                new Subject("SQL", 3, "Database Concepts")
            };
                
            // 2. Source
            var sources = new List<Source>
            {
                new Source("Udemy", 1, "https://udemy.com"),
                new Source("Coursera", 2, "https://coursera.org"),
                new Source("YouTube", 3, "https://youtube.com"),
                new Source("Toplearn", 2, "https://toplearn.com"),
                new Source("MaktabKhoneh", 3, "https://maktabkhooneh.org"),
                new Source("Tosinso", 1, "https://tosinso.com"),
                new Source("Faradars", 2, "https://faradars.org"),
                new Source("LinkedIn Learning", 3, "https://linkedin.com/learning"),
                new Source("Pluralsight", 2, "https://pluralsight.com"),
                new Source("Codecademy", 3, "https://codecademy.com")
            };

            // 3. Teacher (10 تا با Bogus)
            var teachers = new List<Teacher>();
            for (int i = 0; i < 10; i++)
            {
                teachers.Add(new Teacher(
                    fullName: faker.Name.FullName(),
                    rank: faker.Random.Int(1, 5),
                    bio: faker.Name.JobTitle(),
                    email: faker.Internet.Email()
                ));
            }

            await context.Subjects.AddRangeAsync(subjects);
            await context.Sources.AddRangeAsync(sources);
            await context.Teachers.AddRangeAsync(teachers);
            await context.SaveChangesAsync();

            // 4. Course (20 تا با ترکیب رندوم)
            var courses = new List<Course>();
            for (int i = 0; i < 20; i++)
            {
                var course = new Course(
                    title: faker.Company.CatchPhrase(),
                    duration: faker.Random.Int(10, 50),
                    rank: faker.Random.Int(1, 5),
                    subjectId: faker.PickRandom(subjects).Id,
                    sourceId: faker.PickRandom(sources).Id,
                    teacherId: faker.PickRandom(teachers).Id,
                    description: faker.Lorem.Sentence()
                );

                courses.Add(course);
            }

            await context.Courses.AddRangeAsync(courses);
            await context.SaveChangesAsync();

            // 5. Student (100 تا با Bogus)
            var students = new List<Student>();
            for (int i = 0; i < 100; i++)
            {
                students.Add(new Student(
                    fullName: faker.Name.FullName(),
                    age: faker.Random.Int(18, 30),
                    level: faker.PickRandom("Beginner", "Intermediate", "Advanced")
                ));
            }

            await context.Students.AddRangeAsync(students);
            await context.SaveChangesAsync();

            // 6. StudentCourse (ثبت‌نام در 1 تا 3 دوره)
            var enrollments = new List<StudentCourse>();
            var courseIds = courses.Select(c => c.Id).ToList();
            var rand = new Random();

            foreach (var student in students)
            {
                var enrolledCourses = courseIds.OrderBy(_ => rand.Next()).Take(rand.Next(1, 4)).ToList();

                foreach (var courseId in enrolledCourses)
                {
                    enrollments.Add(new StudentCourse(student.Id, courseId));
                }
            }

            await context.StudentCourses.AddRangeAsync(enrollments);
            await context.SaveChangesAsync();
        }
    }
}
