import { Component, Input } from '@angular/core';
import { ScheduleSceneDay } from '../../../scheduling/schedule-scenes/model/schedule-scene-day.model';
import { ScheduleSceneHttpService } from '../../../scheduling/schedule-scenes/service/schedule-scene-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    selector: 'scene-scheduling',
    templateUrl: 'scene-scheduling.component.html'
})
export class SceneSchedulingComponent{

    @Input() projectId: number;
    @Input() sceneId: number;
    @Input() scheduleDays: ScheduleSceneDay[];


    constructor(
        private _scheduleSceneHttpService: ScheduleSceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    getScheduledPageLength(){
        let sum = 0;
        this.scheduleDays.map((scheduleScene: ScheduleSceneDay)=> sum+=scheduleScene.pageLength);
        return sum;
    }
}