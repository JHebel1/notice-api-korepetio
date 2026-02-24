namespace Notices.Application.Responses.Notice;

public record OfferDto(
    EducationLevelDto EducationLevel,
    decimal Price
    );