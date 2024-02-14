﻿using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.AppServices;
using CompetitionAnalysis.Domain.AppEntities.Identity;
namespace CompetitionAnalysis.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
public sealed class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, DeleteRoleCommandResponse>
{
    private readonly IRoleService _roleService;
    public DeleteRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        AppRole role = await _roleService.GetById(request.Id);
        if (role == null) throw new Exception("Role bulunamadı!");

        await _roleService.DeleteAsync(role);

        return new();
    }
}