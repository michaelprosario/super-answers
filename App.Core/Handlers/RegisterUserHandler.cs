using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;
using System.Runtime.Serialization;
using System;
using FluentValidation.Results;
using System.Collections.Generic;

namespace App.Core.Handlers
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
    }

    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.UserName).NotEmpty();
            RuleFor(r => r.Password).NotEmpty();
        }
    }

    public class RegisterUserResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class RegisterUserHandler : BaseHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IUserService usersService;

        public RegisterUserHandler(IUserService usersService)
        {
            this.usersService = usersService;
        }

        protected override RegisterUserResponse Handle(RegisterUserCommand command)
        {
            var response = new RegisterUserResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Request is null.");
            var validationResult = new RegisterUserRequestValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }


            string password = command.Password;
            Entities.User user = new Entities.User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserName = command.UserName
            };

            try
            {
                usersService.Create(user, password);
            }
            catch (Exception ex)
            {
                response.ValidationErrors = new List<ValidationFailure>();
                response.ValidationErrors.Add(new ValidationFailure("", ex.Message));
                return response;
            }
            return response;
        }
    }
}
