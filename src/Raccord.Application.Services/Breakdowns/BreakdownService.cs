using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Breakdowns;
using Raccord.Application.Core.Services.Breakdowns;
using Raccord.Data.EntityFramework.Repositories.Breakdowns;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Raccord.Data.EntityFramework.Repositories.Users.Projects;

namespace Raccord.Application.Services.Breakdowns
{
  // Service used for breakdown functionality
  public class BreakdownService : IBreakdownService
  {
    private readonly IBreakdownRepository _breakdownRepository;
    private readonly IBreakdownTypeDefinitionRepository _breakdownTypeDefinitionRepository;
    private readonly IProjectUserRepository _projectUserRepository;

    // Initialises a new BreakdownService
    public BreakdownService(
      IBreakdownRepository breakdownRepository,
      IBreakdownTypeDefinitionRepository breakdownTypeDefinitionRepository,
      IProjectUserRepository projectUserRepository
      )
    {
      if(breakdownRepository == null)
        throw new ArgumentNullException(nameof(breakdownRepository));
      if(breakdownTypeDefinitionRepository == null)
        throw new ArgumentNullException(nameof(breakdownTypeDefinitionRepository));
      if(projectUserRepository == null)
        throw new ArgumentNullException(nameof(projectUserRepository));
      
      _breakdownRepository = breakdownRepository;
      _breakdownTypeDefinitionRepository = breakdownTypeDefinitionRepository;
      _projectUserRepository = projectUserRepository;
    }

    // Gets all breakdowns for a project
    public IEnumerable<BreakdownSummaryDto> GetAllForParent(long projectID, string userID)
    {
      var breakdowns = _breakdownRepository.GetAllForParent(projectID, userID);

      var dtos = breakdowns.Select(l => l.TranslateSummary(userID));

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

    // Gets a single breakdown by id
    public SelectedBreakdownDto GetForProjectUser(long projectID, string userID)
    {
      var breakdown = _breakdownRepository.GetForProjectUser(projectID, userID);

      var dto = breakdown.TranslateSelected();

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

    public void SelectBreakdown(long projectID, string userID, long breakdownID)
    {
      var projectUser = _projectUserRepository.Get(projectID, userID);

      if(projectUser != null)
      {
        projectUser.SelectedBreakdownID = breakdownID;

        _projectUserRepository.Edit(projectUser);
        _projectUserRepository.Commit();
      }
    }

    // Updates a breakdown
    public void TogglePublishBreakdown(PublishBreakdownDto dto)
    {
      var breakdown = _breakdownRepository.GetSingle(dto.BreakdownID);

      breakdown.IsPublished = dto.Publish;

      _breakdownRepository.Edit(breakdown);
      _breakdownRepository.Commit();
    }

    // Updates a breakdown
    public void SetDefaultProjectBreakdown(long projectID, long breakdownID)
    {
      var breakdowns = _breakdownRepository.GetAllForParent(projectID);

      foreach(var bd in breakdowns)
      {
        bd.IsDefaultProjectBreakdown = false;
        _breakdownRepository.Edit(bd);
      }

      _breakdownRepository.Commit();

      var breakdown = _breakdownRepository.GetSingle(breakdownID);

      breakdown.IsDefaultProjectBreakdown = true;

      _breakdownRepository.Edit(breakdown);
      _breakdownRepository.Commit();
    }
  }
}