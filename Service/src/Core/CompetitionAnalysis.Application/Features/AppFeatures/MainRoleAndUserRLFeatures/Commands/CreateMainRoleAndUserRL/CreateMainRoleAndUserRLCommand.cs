﻿using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;
public sealed record CreateMainRoleAndUserRLCommand(string UserId, string MainRoleId) : ICommand<CreateMainRoleAndUserRLCommandResponse>;