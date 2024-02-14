﻿using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.AppServices;
using CompetitionAnalysis.Domain.AppEntities.Identity;
namespace CompetitionAnalysis.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
public sealed class GetAllRolesQueryHandler : IQueryHandler<GetAllRolesQuery, GetAllRolesQueryResponse>
{
    private readonly IRoleService _roleService;
    public GetAllRolesQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        IList<AppRole> roles = await _roleService.GetAllRolesAsync();
        return new(roles);
    }
}