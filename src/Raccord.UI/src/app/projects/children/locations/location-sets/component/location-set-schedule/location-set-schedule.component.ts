import { Component, Input } from '@angular/core';
import { ScheduleDaySceneCollection } from '../../../../scheduling/schedule-days/model/schedule-day-scene-collection.model';

@Component({
    selector: 'location-set-schedule',
    templateUrl: 'location-set-schedule.component.html'
})
export class LocationSetScheduleComponent{

    @Input() projectId: number;
    @Input() locationSetId: number;
    @Input() scheduleDays: ScheduleDaySceneCollection[];


    constructor(
    ){
    }
}