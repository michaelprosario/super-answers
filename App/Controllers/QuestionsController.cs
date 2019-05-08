using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using App.Core.Handlers;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [AllowAnonymous]
        [HttpPost("AddQuestion")]
        public async Task<IActionResult> AddQuestionAsync([FromBody] AddQuestionRequest request)
        {
            request.UserId = "test";
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("EditQuestion")]
        public async Task<IActionResult> EditQuestionAsync([FromBody] EditQuestionRequest request)
        {
            request.UserId = "test";
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("DeleteQuestion")]
        public async Task<IActionResult> DeleteQuestionAsync([FromBody] DeleteQuestionRequest request)
        {
            request.UserId = "test";
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("ListQuestions")]
        public async Task<IActionResult> ListQuestionsAsync([FromBody] ListQuestionsRequest request)
        {
            request.UserId = "test";
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("GetQuestion")]
        public async Task<IActionResult> GetQuestionAsync([FromBody] GetQuestionRequest request)
        {
            request.UserId = "test";
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}