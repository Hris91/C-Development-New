using System;
using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            using (StudentSystemContext studentContext = new StudentSystemContext())
            {
                studentContext.Database.EnsureCreated();

                Seed(studentContext);
                studentContext.SaveChanges();
            }
        }

        public static void Seed(StudentSystemContext studentContext)
        {
            var students = new Student[]
            {
                new Student()
                {
                    Name = "Pesho",
                    PhoneNumber = "1234567890",
                    RegisteredOn = new DateTime(2017, 01, 01),                                       
                }
            };

            studentContext.AddRange(students);

            var courses = new Course[]
            {
                new Course()
                {
                    Name = "Codene",
                    StartDate = new DateTime(2017, 01, 01),
                    EndDate = new DateTime(2018, 01, 01),
                    Price = 3000
                }
            };

            studentContext.AddRange(courses);

            var resources = new Resource[]
            {
                new Resource()
                {
                    Name = "Zlato",
                    Url = "www.CodeForGold.com",
                    ResourceType = ResourceType.Video,
                    Course = courses[0]
                }
            };

            studentContext.AddRange(resources);

            var homework = new Homework[]
            {
                new Homework()
                {
                    Content = "D:/tamNqkude",
                    ContentType = ContentType.Zip,
                    SubmissionTime = new DateTime(2017, 05, 06),
                    Course = courses[0],
                    Student = students[0]
                }
            };

            studentContext.AddRange(homework);

            var studentCoursesArray = new StudentCourse[]
            {
                new StudentCourse()
                {
                    Student = students[0],
                    Course = courses[0]
                }
            };

            studentContext.AddRange(studentCoursesArray);
        }
    }
}
