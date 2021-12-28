﻿namespace DomainPrimitive.EntityFrameworkCore.Entities;

public class BaseIdentityUser<TKey>
{
    public TKey Id { get; set; }
}

public class IdentityUser : BaseIdentityUser<string>
{
    public string Name { get; set; }

    public string Email { get; set; }
}