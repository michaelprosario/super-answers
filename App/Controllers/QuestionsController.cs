using System;
using System.Threading.Tasks;
using App.Core.Handlers;
using App.Core.Interfaces;
using App.Core.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public QuestionsController(IMediator mediator, IUserService userService)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._userService = userService;
        }

        string GetUserName()
        {
            string id = HttpContext.User.Identity.Name;
            var user = _userService.GetById(id);
            return user.UserName;
        }

        [HttpPost("AddQuestion")]
        public async Task<AddQuestionResponse> AddQuestionAsync([FromBody] AddQuestionRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("EditQuestion")]
        public async Task<EditQuestionResponse> EditQuestionAsync([FromBody] EditQuestionRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("DeleteQuestion")]
        public async Task<VoidResponse> DeleteQuestionAsync([FromBody] DeleteQuestionRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("ListQuestions")]
        public async Task<ListQuestionsResponse> ListQuestionsAsync([FromBody] ListQuestionsRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("GetQuestion")]
        public async Task<GetQuestionResponse> GetQuestionAsync([FromBody] GetQuestionRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("AddQuestionTag")]
        public async Task<AddQuestionTagResponse> AddQuestionTagAsync([FromBody] AddQuestionTagRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("DeleteQuestionTag")]
        public async Task<VoidResponse> DeleteQuestionTagAsync([FromBody] DeleteQuestionTagRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("ListQuestionTags")]
        public async Task<ListQuestionTagsResponse> ListQuestionTagsAsync([FromBody] ListQuestionTagsRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("AddQuestionAnswer")]
        public async Task<AddQuestionAnswerResponse> AddQuestionAnswerAsync([FromBody] AddQuestionAnswerRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("EditQuestionAnswer")]
        public async Task<EditQuestionAnswerResponse> EditQuestionAnswerAsync(
            [FromBody] EditQuestionAnswerRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("DeleteQuestionAnswer")]
        public async Task<VoidResponse> DeleteQuestionAnswerAsync([FromBody] DeleteQuestionAnswerRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("ListQuestionAnswers")]
        public async Task<ListQuestionAnswersResponse> ListQuestionAnswersAsync(
            [FromBody] ListQuestionAnswersRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("GetQuestionAnswer")]
        public async Task<GetQuestionAnswerResponse> GetQuestionAnswerAsync([FromBody] GetQuestionAnswerRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }

        [HttpPost("AddAnswerVote")]
        public async Task<AddAnswerVoteResponse> AddAnswerVoteAsync([FromBody] AddAnswerVoteRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }

        
        [HttpPost("AddQuestionVote")]
        public async Task<AddQuestionVoteResponse> AddQuestionVoteAsync([FromBody] AddQuestionVoteRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }

        [HttpPost("DeleteQuestionVote")]
        public async Task<VoidResponse> DeleteQuestionVoteAsync([FromBody] DeleteQuestionVoteRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }

        [HttpPost("SearchByKeyword")]
        public async Task<SearchByKeywordResponse> SearchByKeywordAsync([FromBody] SearchByKeywordRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }

        [HttpPost("GetMostRecentQuestions")]
        public async Task<GetMostRecentQuestionsResponse> GetMostRecentQuestionsAsync([FromBody] GetMostRecentQuestionsRequest request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
    }
}