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

        //This is to add test data to the database
        public void CreateTestEntries()
        {

            var courses = new List<CourseName>
            {
                new CourseName {CourseNames = "Hello World" },
                new CourseName {CourseNames = "My First Variables" },
                new CourseName{CourseNames = "Fuctions for Beginners"}

            };


            var courseTopics = new List<CourseTopics>
            {
                new CourseTopics {CourseId = 1, Topic = "Lorem ipsum dolor sit amet."},
                new CourseTopics {CourseId = 1, Topic = "Lorem ipsum dolor"},
                new CourseTopics {CourseId = 1, Topic = "Ipsum dolor sit amet"},

                new CourseTopics {CourseId = 2, Topic = "Lorem ipsum dolor sit amet."},
                new CourseTopics {CourseId = 2, Topic = "Lorem ipsum dolor"},
                new CourseTopics {CourseId = 2, Topic = "Ipsum dolor sit amet"},
                new CourseTopics {CourseId = 2, Topic = "Lorem ipsum dolor sit amet."},

                new CourseTopics {CourseId = 3, Topic  = "Lorem ipsum dolor"},
                new CourseTopics {CourseId = 3, Topic = "Ipsum dolor sit amet"}
            };

            var topicImages = new List<TopicImage>
            {
                new TopicImage {TopicId = 1, 
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicId = 1,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicId = 1,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" },
                new TopicImage {TopicId = 3,
                    ImageURL = "https://as2.ftcdn.net/v2/jpg/02/97/07/81/1000_F_297078136_J3kH3VoAy4QcVuGbF0HQP2BaNCpaF7gP.jpg" }

            };

            var topicDesc = new List<TopicDescription>
            {
                new TopicDescription { TopicId = 1, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." +
                                                                " Donec ultrices tincidunt arcu non sodales neque sodales. Nisl condimentum id venenatis a condimentum vitae. Purus in mollis nunc sed id semper risus in " +
                                                                "hendrerit. Donec massa sapien faucibus et. Nunc mattis enim ut tellus elementum sagittis. Nisi porta lorem mollis aliquam. Sit amet cursus sit amet dictum" +
                                                                " sit amet justo donec.Scelerisque felis imperdiet proin fermentum leo vel orci. Lectus magna fringilla urna porttitor rhoncus dolor."},

                new TopicDescription { TopicId = 2, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est."},
                
                new TopicDescription { TopicId = 3, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                "hendrerit. Donec massa sapien faucibus et. Nunc mattis enim ut tellus elementum sagittis. Nisi porta lorem mollis aliquam. Sit amet cursus sit amet dictum" +
                                                                " sit amet justo donec.Scelerisque felis imperdiet proin fermentum leo vel orci. Lectus magna fringilla urna porttitor rhoncus dolor."},

                new TopicDescription { TopicId = 4, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla."},


                new TopicDescription { TopicId = 5, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },

                new TopicDescription { TopicId = 6, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },
                       
                new TopicDescription { TopicId = 7, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },

                new TopicDescription { TopicId = 8, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },
                       
                new TopicDescription { TopicId = 9, Description = "Laoreet id donec ultrices tincidunt arcu non sodales neque sodales. Integer eget aliquet nibh praesent tristique magna. Eget felis eget nunc lobortis. " +
                                                                "Scelerisque in dictum non consectetur. Aliquet eget sit amet tellus cras adipiscing enim eu. Risus pretium quam vulputate dignissim suspendisse in est." +
                                                                " Nulla pharetra diam sit amet nisl suscipit adipiscing bibendum. Blandit libero volutpat sed cras ornare arcu dui vivamus arcu. Duis ut diam quam nulla." },




             }
        }

        //Might need to adjust this one. 
        public CourseTopics? Read(int courseId)
        {
            return _db.CourseTopics
                    .Include(c => c.TopicDescriptions)
                    .Include(c=> c.TopicDescriptions)
                    .FirstOrDefault(c => c.Id == courseId);
        }
        //Might need to adjust this one. 
        public ICollection<CourseName> ReadCourses()
        {
            return _db.CourseNames
                .Include(c => c.CourseTopics)
                    .ThenInclude(c => c.TopicImages)
                .Include(c => c.CourseTopics)
                    .ThenInclude(c => c.TopicDescriptions)
                .ToList();
        }

        public ICollection<CourseTopics> ReadCourseTopics()
        {
            return _db.CourseTopics
               .Include(c => c.TopicDescriptions)
               .Include(c => c.TopicDescriptions).ToList();
        }

        public ICollection<TopicDescription> ReadTopicDescriptions()
        {
            return _db.TopicDescriptions.ToList();
        }

        public ICollection<TopicImage> ReadTopicImages()
        {
            return _db.TopicImages.ToList();
        }
    }
}
