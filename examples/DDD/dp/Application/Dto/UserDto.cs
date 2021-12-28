namespace DomainPrimitive.Application.Dto;

public class BaseUserDto<TKey>
{
    public TKey Id { get; set; }
}

public class UserDto : BaseUserDto<string>
{
    public string Name { get; set; }

    public string Email { get; set; }
}