using BitWise.Services;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BitWise.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo _db;

        public CourseController(ICourseRepo db)
        {
            _db = db;
        }

        //Once I update the migration and prefill the DB with a bogus course or two should be good to add
        //other views.

        public IActionResult Index()
        {
            //Used this method to add fake data to the DB.
            //_db.CreateTestEntries();
            //_db.AddImages();
            var model = _db.ReadCourses();

            return View(model);
        }

        public IActionResult CourseDetails(int id)
        {
            var model = _db.ReadCourse(id);


            return View(model);
        }
    }
}
