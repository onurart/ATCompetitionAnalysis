﻿using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Domain.AppEntities;
namespace CompetitionAnalysis.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;
public sealed record CreateStaticMainRolesCommand(List<MainRole> MainRoles) : ICommand<CreateStaticMainRolesCommandResponse>;