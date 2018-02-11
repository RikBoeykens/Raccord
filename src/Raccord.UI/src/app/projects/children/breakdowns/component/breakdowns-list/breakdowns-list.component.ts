import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from
  '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { BreakdownSummary } from '../../model/breakdown-summary.model';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { BreakdownHttpService } from '../../service/breakdown-http.service';
import { Breakdown } from '../../model/breakdown.model';

@Component({
    templateUrl: 'breakdowns-list.component.html',
})
export class BreakdownsListComponent implements OnInit {

  public project: ProjectSummary;
  public breakdowns: BreakdownSummary[] = [];

  constructor(
    private _breakdownService: BreakdownHttpService,
    private _loadingWrapperService: LoadingWrapperService,
    private _route: ActivatedRoute,
    private _router: Router,
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      project: ProjectSummary,
      breakdowns: BreakdownSummary[]
    }) => {
      this.project = data.project;
      this.breakdowns = data.breakdowns;
    });
  }

  public addBreakdown() {
    this._loadingWrapperService.Load(
      this._breakdownService.post(
        this.project.id,
        new Breakdown({
          id: 0,
          name: `Breakdown by ${AccountHelpers.getName()}`,
          description: '',
          projectID: this.project.id
        })
      ),
      () => this.getBreakdowns()
    );
  }

  public removeBreakdown(breakdown: BreakdownSummary) {
    this._loadingWrapperService.Load(
      this._breakdownService.delete(this.project.id, breakdown.id),
      () => this.getBreakdowns()
    );
  }

  public select(breakdown: BreakdownSummary) {
    this._loadingWrapperService.Load(
      this._breakdownService.select(this.project.id, breakdown.id),
      () => this.getBreakdowns()
    );
  }

  public userCreated(breakdown: BreakdownSummary) {
    return breakdown.createdBy.id === AccountHelpers.getUserId();
  }

  public getCanEdit() {
    return AccountHelpers.hasProjectPermission(
      this.project.id,
      ProjectPermissionEnum.canEditGeneral
    );
  }

  private getBreakdowns() {
    this._loadingWrapperService.Load(
      this._breakdownService.getAll(this.project.id),
      (data) => this.breakdowns = data
    );
    this._breakdownService.getAll(this.project.id).then((data)=> this.breakdowns = data);
  }
}
