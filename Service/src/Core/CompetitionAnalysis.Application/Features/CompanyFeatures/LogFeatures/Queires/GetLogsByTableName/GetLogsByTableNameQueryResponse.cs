﻿using CompetitionAnalysis.Domain.Dtos;
using EntityFrameworkCorePagination.Nuget.Pagination;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;
public sealed record GetLogsByTableNameQueryResponse(PaginationResult<LogDto> Data);