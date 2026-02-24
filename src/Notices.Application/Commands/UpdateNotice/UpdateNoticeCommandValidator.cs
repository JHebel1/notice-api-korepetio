using FluentValidation;

namespace Notices.Application.Commands.UpdateNotice;

public class UpdateNoticeCommandValidator : AbstractValidator<UpdateNoticeCommand>
{
    public UpdateNoticeCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithErrorCode(NoticeCommandErrors.TitleRequired.ErrorCode)
            .WithMessage(NoticeCommandErrors.TitleRequired.ErrorMessage)
            .MaximumLength(100)
            .WithErrorCode(NoticeCommandErrors.TitleToLong.ErrorCode)
            .WithMessage(NoticeCommandErrors.TitleToLong.ErrorMessage);
        RuleFor(x => x.Content)
            .NotEmpty()
            .WithErrorCode(NoticeCommandErrors.ContentRequired.ErrorCode)
            .WithMessage(NoticeCommandErrors.ContentRequired.ErrorMessage)
            .MaximumLength(5000)
            .WithErrorCode(NoticeCommandErrors.ContentToLong.ErrorCode)
            .WithMessage(NoticeCommandErrors.ContentToLong.ErrorMessage);
        RuleFor(x => x.Subject)
            .NotEmpty()
            .WithErrorCode(NoticeCommandErrors.SubjectRequired.ErrorCode)
            .WithMessage(NoticeCommandErrors.SubjectRequired.ErrorMessage)
            .IsInEnum()
            .WithErrorCode(NoticeCommandErrors.SubjectNotInEnum.ErrorCode)
            .WithMessage(NoticeCommandErrors.SubjectNotInEnum.ErrorMessage);
        RuleFor(x => x.Offers)
            .NotEmpty()
            .WithErrorCode(NoticeCommandErrors.OfferRequired.ErrorCode)
            .WithMessage(NoticeCommandErrors.OfferRequired.ErrorMessage);
        RuleForEach(x => x.Offers).ChildRules(offer =>
        {
            offer.RuleFor(x => x.EducationLevel)
                .NotEmpty()
                .WithErrorCode(NoticeCommandErrors.OfferEducationLevelRequired.ErrorCode)
                .WithMessage(NoticeCommandErrors.OfferEducationLevelRequired.ErrorMessage)
                .IsInEnum()
                .WithErrorCode(NoticeCommandErrors.OfferEducationLevelNotInEnum.ErrorCode)
                .WithMessage(NoticeCommandErrors.OfferEducationLevelNotInEnum.ErrorMessage);
            offer.RuleFor(x => x.Price)
                .NotEmpty()
                .WithErrorCode(NoticeCommandErrors.OfferPriceRequired.ErrorCode)
                .WithMessage(NoticeCommandErrors.OfferPriceRequired.ErrorMessage)
                .GreaterThan(0)
                .WithErrorCode(NoticeCommandErrors.OfferPriceGreaterThanZero.ErrorCode)
                .WithMessage(NoticeCommandErrors.OfferPriceGreaterThanZero.ErrorMessage);
        });
    }
}