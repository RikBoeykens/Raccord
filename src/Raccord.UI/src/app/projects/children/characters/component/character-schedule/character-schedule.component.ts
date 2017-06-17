import { Component, Input } from '@angular/core';
import { CharacterScheduleDay } from '../../../scheduling/schedule-days/model/character-schedule-day.model';

@Component({
    selector: 'character-schedule',
    templateUrl: 'character-schedule.component.html'
})
export class CharacterScheduleComponent{

    @Input() projectId: number;
    @Input() characterId: number;
    @Input() scheduleDays: CharacterScheduleDay[];


    constructor(
    ){
    }
}