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
        public async Task<AddQuestionResponse> AddQuestionAsync([FromBody] AddQuestionCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }
        
        [HttpPost("EditQuestion")]
        public async Task<EditQuestionResponse> EditQuestionAsync([FromBody] EditQuestionCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }
        
        [HttpPost("DeleteQuestion")]
        public async Task<VoidResponse> DeleteQuestionAsync([FromBody] DeleteQuestionCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }
        
        [HttpPost("ListQuestions")]
        public async Task<ListQuestionsResponse> ListQuestionsAsync([FromBody] ListQuestionsQuery query)
        {
            query.UserId = GetUserName();
            return await _mediator.Send(query);
        }
        
        [HttpPost("GetQuestion")]
        public async Task<GetQuestionResponse> GetQuestionAsync([FromBody] GetQuestionQuery query)
        {
            query.UserId = GetUserName();
            return await _mediator.Send(query);
        }
        
        [HttpPost("AddQuestionTag")]
        public async Task<AddQuestionTagResponse> AddQuestionTagAsync([FromBody] AddQuestionTagCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }
        
        [HttpPost("DeleteQuestionTag")]
        public async Task<VoidResponse> DeleteQuestionTagAsync([FromBody] DeleteQuestionTagCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }
        
        [HttpPost("ListQuestionTags")]
        public async Task<ListQuestionTagsResponse> ListQuestionTagsAsync([FromBody] ListQuestionTagsQuery query)
        {
            query.UserId = GetUserName();
            return await _mediator.Send(query);
        }
        
        [HttpPost("AddQuestionAnswer")]
        public async Task<AddQuestionAnswerResponse> AddQuestionAnswerAsync([FromBody] AddQuestionAnswerCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }
        
        [HttpPost("EditQuestionAnswer")]
        public async Task<EditQuestionAnswerResponse> EditQuestionAnswerAsync(
            [FromBody] EditQuestionAnswerCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }
        
        [HttpPost("DeleteQuestionAnswer")]
        public async Task<VoidResponse> DeleteQuestionAnswerAsync([FromBody] DeleteQuestionAnswerCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }
        
        [HttpPost("ListQuestionAnswers")]
        public async Task<ListQuestionAnswersResponse> ListQuestionAnswersAsync(
            [FromBody] ListQuestionAnswersQuery request)
        {
            request.UserId = GetUserName();
            return await _mediator.Send(request);
        }
        
        [HttpPost("GetQuestionAnswer")]
        public async Task<GetQuestionAnswerResponse> GetQuestionAnswerAsync([FromBody] GetQuestionAnswerQuery query)
        {
            query.UserId = GetUserName();
            return await _mediator.Send(query);
        }

        [HttpPost("AddAnswerVote")]
        public async Task<AddAnswerVoteResponse> AddAnswerVoteAsync([FromBody] AddAnswerVoteCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }

        
        [HttpPost("AddQuestionVote")]
        public async Task<AddQuestionVoteResponse> AddQuestionVoteAsync([FromBody] AddQuestionVoteCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }

        [HttpPost("DeleteQuestionVote")]
        public async Task<VoidResponse> DeleteQuestionVoteAsync([FromBody] DeleteQuestionVoteCommand command)
        {
            command.UserId = GetUserName();
            return await _mediator.Send(command);
        }

        [HttpPost("SearchByKeyword")]
        public async Task<SearchByKeywordResponse> SearchByKeywordAsync([FromBody] SearchByKeywordQuery query)
        {
            query.UserId = GetUserName();
            return await _mediator.Send(query);
        }

        [HttpPost("GetMostRecentQuestions")]
        public async Task<GetMostRecentQuestionsResponse> GetMostRecentQuestionsAsync([FromBody] GetMostRecentQuestionsQuery query)
        {
            query.UserId = GetUserName();
            return await _mediator.Send(query);
        }
    }
}