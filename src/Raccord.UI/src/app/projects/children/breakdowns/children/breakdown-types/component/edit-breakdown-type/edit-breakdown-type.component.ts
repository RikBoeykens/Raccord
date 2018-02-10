import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { BreakdownType } from '../../model/breakdown-type.model';

@Component({
    selector: 'edit-breakdown-type',
    templateUrl: 'edit-breakdown-type.component.html'
})
export class EditBreakdownTypeComponent{

    @Output() submitType = new EventEmitter();
    @Input() breakdownType: BreakdownType;

    constructor(
    ){
    }

    doTypeSubmit(){
        this.submitType.emit();
    }
}