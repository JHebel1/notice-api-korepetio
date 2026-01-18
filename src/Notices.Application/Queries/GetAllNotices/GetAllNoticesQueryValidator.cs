using FluentValidation;

namespace Notices.Application.Queries.GetAllNotices;

public class GetAllNoticesQueryValidator : AbstractValidator<GetAllNoticesQuery>
{
    public GetAllNoticesQueryValidator()
    {
        RuleFor(x => x.page)
            .NotEmpty()
            .WithErrorCode(NoticeQueryErrors.PageRequired.ErrorCode)
            .WithMessage(NoticeQueryErrors.PageRequired.ErrorMessage);
        RuleFor(x => x.pageSize)
            .NotEmpty()
            .WithErrorCode(NoticeQueryErrors.PageSizeRequired.ErrorCode)
            .WithMessage(NoticeQueryErrors.PageSizeRequired.ErrorMessage);
    }
}