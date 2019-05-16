using System;
using System.Threading.Tasks;
using App.Core.Handlers;
using App.Core.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
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
        public async Task<AddQuestionResponse> AddQuestionAsync([FromBody] AddQuestionRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("EditQuestion")]
        public async Task<EditQuestionResponse> EditQuestionAsync([FromBody] EditQuestionRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("DeleteQuestion")]
        public async Task<VoidResponse> DeleteQuestionAsync([FromBody] DeleteQuestionRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("ListQuestions")]
        public async Task<ListQuestionsResponse> ListQuestionsAsync([FromBody] ListQuestionsRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("GetQuestion")]
        public async Task<GetQuestionResponse> GetQuestionAsync([FromBody] GetQuestionRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("AddQuestionTag")]
        public async Task<AddQuestionTagResponse> AddQuestionTagAsync([FromBody] AddQuestionTagRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("DeleteQuestionTag")]
        public async Task<VoidResponse> DeleteQuestionTagAsync([FromBody] DeleteQuestionTagRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("ListQuestionTags")]
        public async Task<ListQuestionTagsResponse> ListQuestionTagsAsync([FromBody] ListQuestionTagsRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("AddQuestionAnswer")]
        public async Task<AddQuestionAnswerResponse> AddQuestionAnswerAsync([FromBody] AddQuestionAnswerRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("EditQuestionAnswer")]
        public async Task<EditQuestionAnswerResponse> EditQuestionAnswerAsync(
            [FromBody] EditQuestionAnswerRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("DeleteQuestionAnswer")]
        public async Task<VoidResponse> DeleteQuestionAnswerAsync([FromBody] DeleteQuestionAnswerRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("ListQuestionAnswers")]
        public async Task<ListQuestionAnswersResponse> ListQuestionAnswersAsync(
            [FromBody] ListQuestionAnswersRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("GetQuestionAnswer")]
        public async Task<GetQuestionAnswerResponse> GetQuestionAnswerAsync([FromBody] GetQuestionAnswerRequest request)
        {
            request.UserId = "test";
            return await _mediator.Send(request);
        }
    }
}