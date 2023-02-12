﻿using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hust.Datn.Controller.Controllers
{
    public class AttachmentController : BaseController<Attachment>
    {
        #region Declare
        protected readonly IAttachmentService _attachmentService;
        #endregion

        #region Constructor
        public AttachmentController(IAttachmentService attachmentService) : base(attachmentService)
        {
            _attachmentService = attachmentService;
        }
        #endregion

        #region Methods
        [HttpPost("upload")]
        public async Task<IActionResult> UploadAttachment(IFormFile file)
        {
            try
            {
                var result = await _attachmentService.UploadAttachment(file);

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