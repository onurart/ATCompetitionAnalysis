﻿using CompetitionAnalysis.Domain.AppEntities.Identity;
namespace CompetitionAnalysis.Application.Features.AppFeatures.UserRoleFeatures.Queries.GetAllUserRoles;
public sealed record GetAllUserRolesQueryResponse(IList<AppUserRole> AppUserRoles);