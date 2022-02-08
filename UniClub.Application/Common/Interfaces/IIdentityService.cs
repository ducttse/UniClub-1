﻿using System.Threading.Tasks;
using UniClub.Application.Models;
using UniClub.Domain.Entities;

namespace UniClub.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
        Task<(Result Result, string UserId)> CreateUserAsync(Person user, string password);
        Task<Result> UpdateUserAsync(string userId);
        Task<Result> UpdateUserAsync(Person user);

    }

}