using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseRankingController(ICourseRankingService courseRankingService) : ControllerBase
    {
        private readonly ICourseRankingService _courseRankingService = courseRankingService;

        /// <summary>
        /// دریافت لیست دوره‌های برتر بر اساس جمع امتیازات دوره، استاد و منبع آموزشی
        /// </summary>
        /// <returns>لیست دوره‌های مرتب شده از بالا به پایین بر اساس جمع امتیازات</returns>
        [HttpGet("top-courses")]
        [ProducesResponseType(typeof(IReadOnlyList<CourseRankingDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<CourseRankingDto>>> GetTopRankedCourses()
        {
            try
            {
                var result = await _courseRankingService.GetTopRankedCoursesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "خطا در دریافت اطلاعات", error = ex.Message });
            }
        }
    }
}
