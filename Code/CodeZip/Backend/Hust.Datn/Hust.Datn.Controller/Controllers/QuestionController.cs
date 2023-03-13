using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hust.Datn.Controller.Controllers
{
    public class QuestionController : BaseController<Question>
    {
        protected readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService) : base(questionService)
        {
            _questionService = questionService;
        }

        #region Methods
        /// <summary>
        /// Lấy ID lớn nhất 
        /// </summary>
        /// <returns></returns>
        [HttpPost("max-id")]
        public async Task<IActionResult> GetMaxID()
        {
            try
            {
                var result = await _questionService.GetMaxID();

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("scroing-test")]
        public async Task<IActionResult> ScroingTest(List<Question> questions)
        {
            try
            {
                var result = await _questionService.ScroingTest(questions);

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

