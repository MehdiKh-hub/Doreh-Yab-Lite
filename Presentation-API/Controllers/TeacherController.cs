using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController(ITeacherReadService teacherService) : ControllerBase
    {
       private readonly ITeacherReadService _teacherService = teacherService;

        /// <summary>
        /// دریافت لیست معلمان با امکان جستجو و مرتب‌سازی
        /// </summary>
        /// <param name="search">کلمه جستجو در نام یا توضیح</param>
        /// <param name="sortBy">معیار مرتب‌سازی: rank (پیش‌فرض)، name</param>
        /// <returns>لیست معلمان</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? search, [FromQuery] string? sortBy = "rank")
        {
            var teachers = await _teacherService.GetTeacherAsync(search, sortBy);
            return Ok(teachers);
        }
    }
}
