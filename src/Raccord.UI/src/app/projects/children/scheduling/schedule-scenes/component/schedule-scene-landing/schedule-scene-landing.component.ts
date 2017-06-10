import { Component, OnInit, OnChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ScheduleScene } from '../../model/schedule-scene.model';
import { ScheduleSceneHttpService } from '../../service/schedule-scene-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { PageLengthHelpers } from '../../../../../../shared/helpers/page-length.helpers';

@Component({
    templateUrl: 'schedule-scene-landing.component.html',
})
export class ScheduleSceneLandingComponent extends OnInit  implements OnChanges{

    scheduleScene: ScheduleScene;
    project: ProjectSummary;
    stringPageLength: string;

    constructor(
        private _scheduleSceneHttpService: ScheduleSceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
        super();
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scheduleScene: ScheduleScene, project: ProjectSummary }) => {
            this.scheduleScene = data.scheduleScene;
            this.setStringPageLength();
            this.project = data.project;
        });
    }

    ngOnChanges(){
        this.setStringPageLength();
    }

    setStringPageLength(){
        this.stringPageLength = PageLengthHelpers.getPageLengthString(this.scheduleScene.pageLength);
    }

    getScheduleScene(){
        
        let loadingId = this._loadingService.startLoading();

        this._scheduleSceneHttpService.get(this.scheduleScene.id).then(data => {
            this.scheduleScene = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    updateScheduleScene(){
        let loadingId = this._loadingService.startLoading();

        this.scheduleScene.pageLength = PageLengthHelpers.getPageLengthNumber(this.stringPageLength);
        this._scheduleSceneHttpService.post(this.scheduleScene).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScheduleScene();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}