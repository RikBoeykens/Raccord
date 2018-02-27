import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { MdDialog } from '@angular/material';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { CrewUnitSummary } from '../../model/crew-unit-summary.model';
import { EditCrewUnitDialogComponent } from '../../..';
import { CrewUnitNavEnum } from '../../enum/crew-unit-nav.enum';

@Component({
    templateUrl: 'crew-units-nav-list.component.html',
})
export class CrewUnitsNavListComponent implements OnInit {

  public project: ProjectSummary;
  public crewUnits: CrewUnitSummary[] = [];
  public crewUnitNav: number;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _dialog: MdDialog
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
    this._route.params.subscribe((params: Params) => {
      console.log(params['navType']);
      this.crewUnitNav = params['navType'];
    });
  }

  public getUrlType() {
    switch (CrewUnitNavEnum[this.crewUnitNav]) {
      case(CrewUnitNavEnum[CrewUnitNavEnum.unitLists]):
        return 'unitlists';
      default:
        return '';
    }
  }

  public getType() {
    switch (CrewUnitNavEnum[this.crewUnitNav]) {
      case(CrewUnitNavEnum[CrewUnitNavEnum.unitLists]):
        return 'Unit Lists';
      default:
        return 'Not found';
    }
  }
}
