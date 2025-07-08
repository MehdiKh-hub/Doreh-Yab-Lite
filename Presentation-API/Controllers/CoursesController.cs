using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseReadService _courseService;

        public CoursesController(ICourseReadService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// دریافت لیست دوره‌ها با امکان جستجو و مرتب‌سازی
        /// </summary>
        /// <param name="search">کلمه جستجو در عنوان یا توضیح</param>
        /// <param name="sortBy">معیار مرتب‌سازی: rank (پیش‌فرض)، title، duration</param>
        /// <returns>لیست دوره‌ها</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? search, [FromQuery] string? sortBy = "rank")
        {
            var courses = await _courseService.GetCourseAsync(search, sortBy);
            return Ok(courses);
        }
    }
}
