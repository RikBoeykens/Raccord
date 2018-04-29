import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Element } from '@angular/compiler';
import { ScheduleDay } from '../../schedule-days/model/schedule-day.model';
import { FullScheduleDay } from '../../schedule-days/model/full-schedule-day.model';
import { ScheduleScene } from '../../schedule-scenes/model/schedule-scene.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';
import { Callsheet } from '../../../callsheets';
import { ShootingDay } from '../../../shooting-days';
import { ScheduleDayHttpService } from '../../schedule-days/service/schedule-day-http.service';
import { ScheduleDayNoteHttpService } from
    '../../schedule-day-notes/service/schedule-day-note-http.service';
import { ScheduleSceneHttpService } from
    '../../schedule-scenes/service/schedule-scene-http.service';
import { CallsheetHttpService } from '../../../callsheets/service/callsheet-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { SceneFilterRequest } from '../../../scenes/model/scene-filter-request.model';
import { BreakdownTypeSummary } from
    '../../../breakdowns/breakdown-types/model/breakdown-type-summary.model';
import { SceneHttpService } from '../../../scenes/service/scene-http.service';
import { PageRequest } from '../../../../../shared/children/paging/model/page-request.model';
import { AppSettings } from '../../../../../app.settings';
import { SceneSummary } from '../../../scenes/model/scene-summary.model';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from
    '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { CrewUnitNavEnum } from '../../../crew/crew-units/enum/crew-unit-nav.enum';
import { CrewUnitSummary } from '../../../crew/crew-units/model/crew-unit-summary.model';
import { FullScheduleDayCrewUnit }
    from '../../schedule-days/model/full-schedule-day-crew-unit.model';

@Component({
    templateUrl: 'my-schedule-landing.component.html',
})
export class MyScheduleLandingComponent implements OnInit {

    public scheduleDays: FullScheduleDayCrewUnit[] = [];
    public project: ProjectSummary;

    constructor(
        private _callsheetHttpService: CallsheetHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            scheduleDays: FullScheduleDayCrewUnit[],
            project: ProjectSummary,
        }) => {
            this.scheduleDays = data.scheduleDays;
            this.project = data.project;
        });
    }

    public getScheduledPageLength(scheduleDay: FullScheduleDay) {
        let sum = 0;
        scheduleDay.scenes.map((scheduleScene: ScheduleSceneScene) =>
            sum += scheduleScene.pageLength);
        return sum;
    }

    public getScheduleReadNavType() {
        return CrewUnitNavEnum.scheduleRead;
    }
}