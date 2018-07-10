import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedData } from '../../../shared/children/paging';
import { AdminProjectSummary } from '../../children/projects/model/admin-project-summary.model';
import { AdminDashboard } from '../../model/admin-dashboard.model';

@Component({
  selector: 'admin-landing',
  templateUrl: 'admin-landing.component.html'
})
export class AdminLandingComponent implements OnInit {
  public projects: PagedData<AdminProjectSummary>;
  constructor(
    private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this._route.data.subscribe((data: {dashboardInfo: AdminDashboard}) => {
      console.log(data);
      this.projects = data.dashboardInfo.projects;
    });
  }
}
