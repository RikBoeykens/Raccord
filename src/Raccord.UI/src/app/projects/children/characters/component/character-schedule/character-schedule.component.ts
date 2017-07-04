import { Component, Input } from '@angular/core';
import { ScheduleDaySceneCollection } from '../../../scheduling/schedule-days/model/schedule-day-scene-collection.model';

@Component({
    selector: 'character-schedule',
    templateUrl: 'character-schedule.component.html'
})
export class CharacterScheduleComponent{

    @Input() projectId: number;
    @Input() characterId: number;
    @Input() scheduleDays: ScheduleDaySceneCollection[];


    constructor(
    ){
    }
}