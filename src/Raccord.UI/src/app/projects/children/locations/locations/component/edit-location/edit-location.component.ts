import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { Location } from '../../model/location.model';

@Component({
    selector: 'edit-location',
    templateUrl: 'edit-location.component.html'
})
export class EditLocationComponent{

    @Output() submitLocation = new EventEmitter();
    @Input() location: Location;

    constructor(
    ){
    }

    doLocationSubmit(){
        this.submitLocation.emit();
    }
}