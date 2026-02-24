using FluentValidation;

namespace Notices.Application.Queries.GetNoticeById;

public class GetNoticeByIdQueryValidator : AbstractValidator<GetNoticeByIdQuery>
{
    public GetNoticeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithErrorCode(NoticeQueryErrors.IdRequired.ErrorCode)
            .WithMessage(NoticeQueryErrors.IdRequired.ErrorMessage);
    }
}