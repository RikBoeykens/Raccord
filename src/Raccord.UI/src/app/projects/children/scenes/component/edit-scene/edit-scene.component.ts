import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { Scene } from '../../model/scene.model';
import { PageLengthHelpers } from '../../../../../shared/helpers/page-length.helpers';

@Component({
    selector: 'edit-scene',
    templateUrl: 'edit-scene.component.html'
})
export class EditSceneComponent implements OnChanges{

    @Output() submitScene = new EventEmitter();
    @Input() scene: Scene;

    public stringPageLength: string;

    constructor(
    ){
    }

    doSceneSubmit(){
        this.scene.pageLength = PageLengthHelpers.getPageLengthNumber(this.stringPageLength);
        this.submitScene.emit();
    }

    ngOnChanges(){
        this.stringPageLength = PageLengthHelpers.getPageLengthString(this.scene.pageLength);
    }

}