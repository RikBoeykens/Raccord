import { Component, Input } from '@angular/core';
import { ScheduleDaySceneCollection } from '../../../../scheduling/schedule-days/model/schedule-day-scene-collection.model';

@Component({
    selector: 'location-schedule',
    templateUrl: 'location-schedule.component.html'
})
export class LocationScheduleComponent{

    @Input() projectId: number;
    @Input() locationId: number;
    @Input() scheduleDays: ScheduleDaySceneCollection[];


    constructor(
    ){
    }
}