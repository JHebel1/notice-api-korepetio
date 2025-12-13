using Notices.Domain.Entities;

namespace Notices.Application.DTO;

public record CreateOfferDto(
    EducationLevel EducationLevel,
    decimal Price
    );