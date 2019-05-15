using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using App.Core.Handlers;
using System.Threading.Tasks;
using App.Core.Requests;

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
            Console.WriteLine(">>>>>>" + request.Id);
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
    }
}