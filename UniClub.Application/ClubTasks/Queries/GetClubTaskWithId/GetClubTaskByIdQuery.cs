﻿using MediatR;
using UniClub.Application.ClubTasks.Dtos;

namespace UniClub.Application.ClubTasks.Queries.GetClubTaskWithId
{
    public class GetClubTaskByIdQuery : IRequest<ClubTaskDto>
    {
        public int Id { get; set; }
        public GetClubTaskByIdQuery(int id)
        {
            Id = id;
        }
    }
}
