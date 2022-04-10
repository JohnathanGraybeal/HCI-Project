using BitWise.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitWise.Services
{
    public class CourseRepo : ICourseRepo
    {
        private readonly CoursesDbContext _db;

        public CourseRepo(CoursesDbContext db)
        {
            _db = db;
        }

        

        public CourseViewModel ReadCourse(int courseId)
        {
            CourseViewModel course = new CourseViewModel();

            var co = _db.Course.FirstOrDefault(c => c.CourseId == courseId);

            course.CId = co.CourseId;
            course.CourseName = co.CourseNames;

            course.CourseTopics = ReadCourseTopics(courseId);

             

            foreach(var t in course.CourseTopics)
            {
                course.TopicDescriptions.Add(ReadTopicDescriptions(t.Id));
                course.TopicImages.Add(ReadTopicImages(t.Id));
            }



            return course;

        }


        //Might need to adjust this one. 
        public ICollection<Course> ReadCourses()
        {
            return _db.Course.AsNoTracking().ToList();
        }

        public ICollection<CourseTopic> ReadCourseTopics(int courseId)
        {
            return _db.CourseTopic.AsNoTracking().Where(t => t.CourseNumber == courseId).ToList();
        }

        public ICollection<TopicDescription> ReadTopicDescriptions(int topicId)
        {


            var d = _db.TopicDescription.AsNoTracking().Where(t => t.TopicNumber == topicId).ToList();

            if (d.Any())
            {
                return d;
            }
            else
            {
                return null;
            }
        }

        public ICollection<TopicImage> ReadTopicImages(int topicId)
        {
            return _db.TopicImage.AsNoTracking().Where(t => t.TopicNumber == topicId).ToList();
        }

        
        
        
        
        
        
        
        
        
        //This is to add test data to the database



        public void AddImages()
        {
            var topicImages = new List<TopicImage>
            {
                new TopicImage {TopicNumber = 2,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicNumber = 3,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicNumber = 4,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicNumber = 5,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                                new TopicImage {TopicNumber = 2,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicNumber = 6,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicNumber = 7,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicNumber = 8,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" }

            };

            int i = 0;

            foreach (var im in topicImages)
            {
                _db.TopicImage.Add(topicImages[i]);
                i++;
            }


            _db.SaveChanges();

        }


        public void CreateTestEntries()
        {

            var courses = new List<Course>
            {
                new Course {CourseNames = "Hello World" },
                new Course {CourseNames = "My First Variables" },
                new Course {CourseNames = "Fuctions for Beginners"}

            };


            var courseTopics = new List<CourseTopic>
            {
                new CourseTopic {CourseNumber = 1, Topic = "Lorem ipsum dolor sit amet."},
                new CourseTopic {CourseNumber = 1, Topic = "Lorem ipsum dolor"},
                new CourseTopic {CourseNumber = 1, Topic = "Ipsum dolor sit amet"},

                new CourseTopic {CourseNumber = 2, Topic = "Lorem ipsum dolor sit amet."},
                new CourseTopic {CourseNumber = 2, Topic = "Lorem ipsum dolor"},
                new CourseTopic {CourseNumber = 2, Topic = "Ipsum dolor sit amet"},
                new CourseTopic {CourseNumber = 2, Topic = "Lorem ipsum dolor sit amet."},

                new CourseTopic {CourseNumber = 3, Topic  = "Lorem ipsum dolor"},
                new CourseTopic {CourseNumber = 3, Topic = "Ipsum dolor sit amet"}
            };

            var topicImages = new List<TopicImage>
            {
                new TopicImage {TopicNumber = 1,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicNumber = 1,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicNumber = 1,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicNumber = 3,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" }

            };

            var topicDesc = new List<TopicDescription>
            {
                new TopicDescription { TopicNumber = 1, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." +
                                                                " Donec ultrices tincidunt arcu non sodales neque sodales. Nisl condimentum id venenatis a condimentum vitae. Purus in mollis nunc sed id semper risus in " +
                                                                "hendrerit. Donec massa sapien faucibus et. Nunc mattis enim ut tellus elementum sagittis. Nisi porta lorem mollis aliquam. Sit amet cursus sit amet dictum" +
                                                                " sit amet justo donec.Scelerisque felis imperdiet proin fermentum leo vel orci. Lectus magna fringilla urna porttitor rhoncus dolor."},

                new TopicDescription { TopicNumber = 2, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est."},

                new TopicDescription { TopicNumber = 3, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                "hendrerit. Donec massa sapien faucibus et. Nunc mattis enim ut tellus elementum sagittis. Nisi porta lorem mollis aliquam. Sit amet cursus sit amet dictum" +
                                                                " sit amet justo donec.Scelerisque felis imperdiet proin fermentum leo vel orci. Lectus magna fringilla urna porttitor rhoncus dolor."},

                new TopicDescription { TopicNumber = 4, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla."},


                new TopicDescription { TopicNumber = 5, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },

                new TopicDescription { TopicNumber = 6, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },

                new TopicDescription { TopicNumber = 7, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },

                new TopicDescription { TopicNumber = 8, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },

                new TopicDescription { TopicNumber = 9, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },


             };

            int i = 0;
            foreach (var c in courses)
            {
                _db.Course.Add(courses[i]);
                i++;
            }

            i = 0;

            foreach (var t in courseTopics)
            {
                _db.CourseTopic.Add(courseTopics[i]);
                i++;
            }

            i = 0;

            foreach (var d in topicDesc)
            {
                _db.TopicDescription.Add(topicDesc[i]);
                i++;
            }

            i = 0;

            foreach (var im in topicImages)
            {
                _db.TopicImage.Add(topicImages[i]);
                i++;
            }


            _db.SaveChanges();



        }
    }
}
