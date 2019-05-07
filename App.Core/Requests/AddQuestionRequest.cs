using App.Core.Interfaces;
using App.Core.Responses;
using MediatR;

namespace App.Core.Requests
{
    public class AddQuestionRequest : IRequest<AddQuestionResponse>, IUserRequest
    {
        public string QuestionTitle { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public bool NotifyMeOnResponse { get; set; }
        public string UserId { get; set; }
    }
}
