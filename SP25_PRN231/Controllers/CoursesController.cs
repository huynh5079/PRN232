using BusinessLayer.Services;
using DataLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace SP25_PRN231.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Lấy danh sách tất cả khóa học với khả năng truy vấn động OData.
        /// </summary>
        /// <returns>Danh sách các khóa học.</returns>
        [HttpGet]
        [EnableQuery] // <-- BẬT TÍNH NĂNG ODATA CHO ENDPOINT NÀY
        public ActionResult<IQueryable<CourseDto>> GetCourses()
        {
            // Trả về IQueryable để OData có thể xây dựng câu lệnh SQL tối ưu
            var courses = _courseService.GetAllAsQueryable();
            return Ok(courses);
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một khóa học theo ID.
        /// </summary>
        /// <param name="id">ID của khóa học.</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound(); // Trả về 404 Not Found nếu không tìm thấy
            }
            return Ok(course);
        }

        /// <summary>
        /// Tạo một khóa học mới.
        /// </summary>
        /// <param name="courseDto">Dữ liệu để tạo khóa học mới.</param>
        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateCourse([FromBody] CourseCreateDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Trả về 400 Bad Request nếu dữ liệu không hợp lệ
            }

            var newCourse = await _courseService.CreateCourseAsync(courseDto);

            // Trả về 201 Created cùng với location của resource mới và đối tượng vừa tạo
            return CreatedAtAction(nameof(GetCourseById), new { id = newCourse.CoursesId }, newCourse);
        }

        /// <summary>
        /// Cập nhật thông tin một khóa học.
        /// </summary>
        /// <param name="id">ID của khóa học cần cập nhật.</param>
        /// <param name="courseDto">Dữ liệu cập nhật.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseUpdateDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiểm tra xem khóa học có tồn tại không trước khi cập nhật
            var courseExists = await _courseService.GetCourseByIdAsync(id);
            if (courseExists == null)
            {
                return NotFound();
            }

            await _courseService.UpdateCourseAsync(id, courseDto);
            return NoContent(); // Trả về 204 No Content khi cập nhật thành công
        }

        /// <summary>
        /// Xóa một khóa học.
        /// </summary>
        /// <param name="id">ID của khóa học cần xóa.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var courseExists = await _courseService.GetCourseByIdAsync(id);
            if (courseExists == null)
            {
                return NotFound();
            }

            await _courseService.DeleteCourseAsync(id);
            return NoContent(); // Trả về 204 No Content khi xóa thành công
        }
    }
}