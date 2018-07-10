using Raccord.API.ViewModels.Common.Paging;
using Raccord.API.ViewModels.Projects;

namespace Raccord.API.ViewModels.Dashboards.Admin
{
  public class AdminDashboardViewModel
  {
    private PagedDataViewModel<AdminProjectSummaryViewModel> _projects;

    public PagedDataViewModel<AdminProjectSummaryViewModel> Projects
    {
      get
      {
        return _projects ?? new PagedDataViewModel<AdminProjectSummaryViewModel>();
      }
      set
      {
        _projects = value;
      }
    }
  }
}