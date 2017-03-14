import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { BreakdownItem } from '../../model/breakdown-item.model';

@Component({
    selector: 'edit-breakdown-item',
    templateUrl: 'edit-breakdown-item.component.html'
})
export class EditBreakdownItemComponent{

    @Output() submitBreakdownItem = new EventEmitter();
    @Input() breakdownItem: BreakdownItem;

    constructor(
    ){
    }

    doBreakdownItemSubmit(){
        this.submitBreakdownItem.emit();
    }
}