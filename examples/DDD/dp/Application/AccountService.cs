﻿using DomainPrimitive.Application.Command;
using DomainPrimitive.Application.Dto;
using DomainPrimitive.Domain.Model.User;
using DomainPrimitive.Domain.Services;
using Mapster;

namespace DomainPrimitive.Services;

public class AccountService : IAccountService
{
    private readonly IUserRepository accountRepository;
    private readonly IUserFactory userFactory;

    public AccountService(IUserRepository accountRepository, IUserFactory userFactory)
    {
        this.accountRepository = accountRepository;
        this.userFactory = userFactory;
    }

    public async Task<UserDto> Register(CreateUserCommand createUserCommand)
    {
        var user = await userFactory.CreateUser(createUserCommand.Name, createUserCommand.Email);

        var createdUser = await accountRepository.Register(user);

        return createdUser.Adapt<UserDto>();
    }
}