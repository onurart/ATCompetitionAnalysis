﻿using CompetitionAnalysis.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
public sealed record CreateMainRoleCommand(string Title) : ICommand<CreateMainRoleCommandResponse>;