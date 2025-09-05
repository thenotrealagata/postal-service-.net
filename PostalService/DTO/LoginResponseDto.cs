namespace PostalService.DTO
{
    public class LoginResponseDto
    {
        public string UserId { get; init; }
        public required string AuthToken { get; init; }
        public string RefreshToken { get; init; }
    }
}
