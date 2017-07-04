import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { LocationSet } from '../../model/location-set.model';

@Component({
    selector: 'edit-location-set',
    templateUrl: 'edit-location-set.component.html'
})
export class EditLocationSetComponent{

    @Output() submitLocationSet = new EventEmitter();
    @Input() locationSet: LocationSet;

    constructor(
    ){
    }

    doLocationSubmit(){
        this.submitLocationSet.emit();
    }
}