import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { IntExt } from '../../model/int-ext.model';

@Component({
    selector: 'edit-int-ext',
    templateUrl: 'edit-int-ext.component.html'
})
export class EditIntExtComponent{

    @Output() submitIntExt = new EventEmitter();
    @Input() intext: IntExt;

    constructor(
    ){
    }

    doDayNightSubmit(){
        this.submitIntExt.emit();
    }
}