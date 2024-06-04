namespace RestApiExample.Web.Dto;

public record OrderDto(int Id, int ProductId, string? Name, string? Address, string? Phone);
