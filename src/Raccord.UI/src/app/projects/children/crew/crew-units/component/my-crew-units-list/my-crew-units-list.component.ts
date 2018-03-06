import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { CrewUnitSummary } from '../../model/crew-unit-summary.model';

@Component({
    templateUrl: 'my-crew-units-list.component.html',
})
export class MyCrewUnitsListComponent implements OnInit {

  public project: ProjectSummary;
  public crewUnits: CrewUnitSummary[] = [];

  constructor(
    private _route: ActivatedRoute,
    private _router: Router
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      project: ProjectSummary,
      crewUnits: CrewUnitSummary[]
    }) => {
      this.project = data.project;
      this.crewUnits = data.crewUnits;
    });
  }
}
