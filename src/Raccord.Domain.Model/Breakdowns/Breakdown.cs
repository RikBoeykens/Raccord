using System.Collections.Generic;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Breakdowns
{
  public class Breakdown : Entity
  {
    private ICollection<BreakdownType> _types;
    private ICollection<BreakdownItem> _items;
    private ICollection<ProjectUser> _selectedByUsers;

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsDefaultProjectBreakdown { get; set; }

    public bool IsPublished { get; set; }

    // ID of the linked project
    public long ProjectID { get; set; }

    // Linked project
    public virtual Project Project { get; set; }

    /// <summary>
    /// ID of the user making the comment
    /// </summary>
    /// <returns></returns>
    public string UserID { get; set; }

    /// <summary>
    /// User making the comment
    /// </summary>
    /// <returns></returns>
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<BreakdownType> Types
    {
      get
      {
        return _types ?? (_types = new List<BreakdownType>());
      }
      set
      {
        _types = value;
      }
    }

    public virtual ICollection<BreakdownItem> Items
    {
      get
      {
        return _items ?? (_items = new List<BreakdownItem>());
      }
      set
      {
        _items = value;
      }
    }

    public virtual ICollection<ProjectUser> SelectedByUsers
    {
      get
      {
        return _selectedByUsers ?? (_selectedByUsers = new List<ProjectUser>());
      }
      set
      {
        _selectedByUsers = value;
      }
    }
  }
}