using Notices.Domain.Entities;

namespace Notices.Application.Commands.CreateNotice;

public record CreateOfferDto(
    EducationLevel EducationLevel,
    decimal Price
    );