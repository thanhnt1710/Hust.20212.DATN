using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hust.Datn.Controller.Controllers
{
    public class EvaluateController : BaseController<Evaluate>
    {
        protected readonly IEvaluateService _evaluateService;

        public EvaluateController(IEvaluateService evaluateService) : base(evaluateService)
        {
            _evaluateService = evaluateService;
        }

        #region Methods
        [HttpPost("get-by-courseid/{courseID}")]
        public async Task<IActionResult> GetEvaluateByCourseID([FromRoute] Guid courseID)
        {
            try
            {
                var result = await _evaluateService.GetEvaluateByCourseID(courseID);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("insert-evaluate")]
        public async Task<IActionResult> InsertEvaluate(Evaluate evaluate)
        {
            try
            {
                var result = await _evaluateService.InsertEvaluate(evaluate);

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
