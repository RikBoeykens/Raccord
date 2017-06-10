import { Component, OnInit, OnChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FullScheduleScene } from '../../model/full-schedule-scene.model';
import { ScheduleScene } from '../../model/schedule-scene.model';
import { ScheduleSceneHttpService } from '../../service/schedule-scene-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { PageLengthHelpers } from '../../../../../../shared/helpers/page-length.helpers';

@Component({
    templateUrl: 'schedule-scene-landing.component.html',
})
export class ScheduleSceneLandingComponent extends OnInit  implements OnChanges{

    scheduleScene: FullScheduleScene;
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
        this._route.data.subscribe((data: { scheduleScene: FullScheduleScene, project: ProjectSummary }) => {
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

        let updatedScheduleScene = new ScheduleScene({
            id: this.scheduleScene.id, 
            pageLength: PageLengthHelpers.getPageLengthNumber(this.stringPageLength),
            sceneId: this.scheduleScene.scene.id,
            scheduleDayId: this.scheduleScene.scheduleDay.id
        });
        this._scheduleSceneHttpService.post(updatedScheduleScene).then(data=>{
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