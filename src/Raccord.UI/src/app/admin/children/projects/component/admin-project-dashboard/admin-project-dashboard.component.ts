import { AdminFullProject } from '../../model/admin-full-project.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  templateUrl: 'admin-project-dashboard.component.html',
})
export class AdminProjectDashboardComponent implements OnInit {
  public project: AdminFullProject;

  constructor(
    private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { project: AdminFullProject }) => {
      this.project = data.project;
    });
  }
}
