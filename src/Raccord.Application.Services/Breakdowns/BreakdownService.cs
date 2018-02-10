using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Breakdowns;
using Raccord.Application.Core.Services.Breakdowns;
using Raccord.Data.EntityFramework.Repositories.Breakdowns;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;

namespace Raccord.Application.Services.Breakdowns
{
  // Service used for breakdown functionality
  public class BreakdownService : IBreakdownService
  {
    private readonly IBreakdownRepository _breakdownRepository;
    private readonly IBreakdownTypeDefinitionRepository _breakdownTypeDefinitionRepository;

    // Initialises a new BreakdownService
    public BreakdownService(
      IBreakdownRepository breakdownRepository,
      IBreakdownTypeDefinitionRepository breakdownTypeDefinitionRepository
      )
    {
      if(breakdownRepository == null)
        throw new ArgumentNullException(nameof(breakdownRepository));
      if(breakdownTypeDefinitionRepository == null)
        throw new ArgumentNullException(nameof(breakdownTypeDefinitionRepository));
      
      _breakdownRepository = breakdownRepository;
      _breakdownTypeDefinitionRepository = breakdownTypeDefinitionRepository;
    }

    // Gets all breakdowns for a project
    public IEnumerable<BreakdownSummaryDto> GetAllForParent(long projectID, string userID)
    {
      var breakdowns = _breakdownRepository.GetAllForParent(projectID, userID);

      var dtos = breakdowns.Select(l => l.TranslateSummary());

      return dtos;
    }

    // Gets a single breakdown by id
    public FullBreakdownDto Get(Int64 ID)
    {
      var breakdown = _breakdownRepository.GetFull(ID);

      var dto = breakdown.TranslateFull();

      return dto;
    }

    // Gets a summary of a single breakdown
    public BreakdownSummaryDto GetSummary(Int64 ID)
    {
      var breakdown = _breakdownRepository.GetSummary(ID);

      var dto = breakdown.TranslateSummary();

      return dto;
    }

    // Adds a breakdown
    public long Add(BreakdownDto dto)
    {
      var typeDefinitions = _breakdownTypeDefinitionRepository.GetAll().ToList();

      var breakdown = new Breakdown
      {
        Name = dto.Name,
        Description = dto.Description,
        ProjectID = dto.ProjectID,
        UserID = dto.UserID,
        Types = typeDefinitions.Select(td => new BreakdownType
        {
          Name = td.Name,
          Description = td.Description
        }).ToList()
      };

      _breakdownRepository.Add(breakdown);
      _breakdownRepository.Commit();

      return breakdown.ID;
    }

    // Updates a breakdown
    public long Update(BreakdownDto dto)
    {
      var breakdown = _breakdownRepository.GetSingle(dto.ID);

      breakdown.Name = dto.Name;
      breakdown.Description = dto.Description;

      _breakdownRepository.Edit(breakdown);
      _breakdownRepository.Commit();

      return breakdown.ID;
    }

    // Deletes a breakdown
    public void Delete(long ID)
    {
      var breakdown = _breakdownRepository.GetSingle(ID);

      _breakdownRepository.Delete(breakdown);

      _breakdownRepository.Commit();
    }
  }
}