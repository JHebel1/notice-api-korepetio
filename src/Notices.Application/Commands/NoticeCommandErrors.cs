namespace Notices.Application.Commands;

public sealed class AppError
{
    public string ErrorCode { get; init; }
    public string ErrorMessage { get; init; }
}

public static class NoticeCommandErrors
{
    public static readonly AppError TitleRequired = new()
    {
        ErrorCode = "NOT-001",
        ErrorMessage = "Title is required."
    };
    public static readonly AppError TitleToLong = new()
    {
        ErrorCode = "NOT-002",
        ErrorMessage = "Title is too long, max 100 characters."
    };
    public static readonly AppError ContentRequired = new()
    {
        ErrorCode = "NOT-003",
        ErrorMessage = "Content is required."
    };
    public static readonly AppError ContentToLong = new()
    {
        ErrorCode = "NOT-004",
        ErrorMessage = "Content is too long, max 5000 characters."
    };
    public static readonly AppError SubjectRequired = new()
    {
        ErrorCode = "NOT-005",
        ErrorMessage = "Subject is required."
    };
    public static readonly AppError SubjectNotInEnum = new()
    {
        ErrorCode = "NOT-006",
        ErrorMessage = "Subject does not exist."
    };
    public static readonly AppError OfferRequired = new()
    {
        ErrorCode = "NOT-007",
        ErrorMessage = "Offer is required."
    };
    
    public static readonly AppError OfferPriceRequired = new()
    {
        ErrorCode = "NOT-008",
        ErrorMessage = "Offer price is required."
    };
    public static readonly AppError OfferPriceGreaterThanZero = new()
    {
        ErrorCode = "NOT-009",
        ErrorMessage = "Offer price must be greater than zero."
    };
    public static readonly AppError OfferEducationLevelRequired = new()
    {
        ErrorCode = "NOT-010",
        ErrorMessage = "Education required."
    };
    public static readonly AppError OfferEducationLevelNotInEnum = new()
    {
        ErrorCode = "NOT-011",
        ErrorMessage = "Education level does not exist."
    };
    
    public static readonly AppError NoticeOwnerRequired = new()
    {
        ErrorCode = "NOT-012",
        ErrorMessage = "Notice owner is required."
    };
}