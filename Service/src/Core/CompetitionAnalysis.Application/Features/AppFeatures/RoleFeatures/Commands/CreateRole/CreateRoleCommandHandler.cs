﻿using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.AppServices;
using CompetitionAnalysis.Domain.AppEntities.Identity;
namespace CompetitionAnalysis.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
public sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, CreateRoleCommandResponse>
{
    private readonly IRoleService _roleService;
    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        AppRole role = await _roleService.GetByCode(request.Code);
        if (role != null) throw new Exception("Bu rol daha önce kayıt edilmiş!");

        await _roleService.AddAsync(request);
        return new();
    }
}