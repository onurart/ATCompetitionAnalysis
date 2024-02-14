using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Domain.AppEntities.Identity;
using CompetitionAnalysis.Domain.Dtos;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.AppFeatures.AuthFeatures.Queries.GetAllUser
{
    public sealed class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, GetAllUserQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<GetAllUserQueryHandler> _logger;
        public GetAllUserQueryHandler(UserManager<AppUser> userManager, ILogger<GetAllUserQueryHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var result = _userManager.Users;
            return new GetAllUserQueryResponse(result.Adapt<List<UsersDto>>());
        }
    }
}
