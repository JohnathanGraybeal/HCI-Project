using BitWise.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitWise.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo _db;

        public CourseController (ICourseRepo db)
        {
            _db = db;
        }

        //Once I update the migration and prefill the DB with a bogus course or two should be good to add
        //other views.

        public IActionResult Index()
        {
            var model = _db.ReadCourses();

            return View(model);
        }

    }
}
