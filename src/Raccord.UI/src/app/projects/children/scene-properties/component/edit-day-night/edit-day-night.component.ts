import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { DayNight } from '../../model/day-night.model';

@Component({
    selector: 'edit-day-night',
    templateUrl: 'edit-day-night.component.html'
})
export class EditDayNightComponent{

    @Output() submitDayNight = new EventEmitter();
    @Input() daynight: DayNight;

    constructor(
    ){
    }

    doDayNightSubmit(){
        this.submitDayNight.emit();
    }
}