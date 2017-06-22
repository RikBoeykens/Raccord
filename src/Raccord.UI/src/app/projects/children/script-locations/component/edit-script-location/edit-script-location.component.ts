import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { ScriptLocation } from '../../model/script-location.model';

@Component({
    selector: 'edit-script-location',
    templateUrl: 'edit-script-location.component.html'
})
export class EditScriptLocationComponent{

    @Output() submitScriptLocation = new EventEmitter();
    @Input() scriptLocation: ScriptLocation;

    constructor(
    ){
    }

    doScriptLocationSubmit(){
        this.submitScriptLocation.emit();
    }
}