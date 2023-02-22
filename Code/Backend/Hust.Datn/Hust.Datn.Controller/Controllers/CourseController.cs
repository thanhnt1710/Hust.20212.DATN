using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hust.Datn.Controller.Controllers
{
    [Authorize]
    public class CourseController : BaseController<Course>
    {
        protected readonly ICourseService _courseService;

        public CourseController(ICourseService courseService) : base(courseService)
        {
            _courseService = courseService;
        }

        #region Methods
        [HttpPost("save-course")]
        public async Task<IActionResult> SaveCourse(Course course)
        {
            try
            {
                var result = await _courseService.SaveCourse(course);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("remove-course/{id}")]
        public async Task<IActionResult> RemoveCourse(Guid id)
        {
            try
            {
                var result = await _courseService.RemoveCourse(id);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        /// <summary>
        /// Lấy ID lớn nhất 
        /// </summary>
        /// <returns></returns>
        [HttpPost("max-id")]
        public async Task<IActionResult> GetMaxID()
        {
            try
            {
                var result = await _courseService.GetMaxID();

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        /// <summary>
        /// Lấy Khóa học theo CourseID or UserID
        /// Type: 1-CourseID; 2-UserID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("get-course-by-courseid/{id}")]
        public async Task<IActionResult> GetCourseByCourseID(Guid id)
        {
            try
            {
                var result = await _courseService.GetCourseByCourseID(id);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("get-course-by-userid/{id}")]
        public async Task<IActionResult> GetCourseByUserID(Guid id)
        {
            try
            {
                var result = await _courseService.GetCourseByUserID(id);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        #endregion
    }
}
