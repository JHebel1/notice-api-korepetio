namespace Notices.Application.Queries;

public sealed class AppError
{
    public string ErrorCode { get; init; }
    public string ErrorMessage { get; init; }
}

internal static class NoticeQueryErrors
{
    public static readonly AppError IdRequired = new()
    {
        ErrorCode = "NOT-101",
        ErrorMessage = "Notice ID is required."
    };

    public static readonly AppError PageRequired = new()
    {
        ErrorCode = "NOT-102",
        ErrorMessage = "Page number is required."
    };

    public static readonly AppError PageSizeRequired = new()
    {
        ErrorCode = "NOT-103",
        ErrorMessage = "Page size is required."
    };

}