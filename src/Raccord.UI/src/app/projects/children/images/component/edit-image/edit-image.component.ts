import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { Image } from '../../model/image.model';

@Component({
    selector: 'edit-image',
    templateUrl: 'edit-image.component.html'
})
export class EditImageComponent{

    @Output() submitImage = new EventEmitter();
    @Input() image: Image;

    constructor(
    ){
    }

    doImageSubmit(){
        this.submitImage.emit();
    }
}