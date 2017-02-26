import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ImageHttpService } from '../../service/image-http.service';

@Component({
    selector: 'upload-image',
    templateUrl: 'upload-image.component.html'
})
export class UploadImageComponent{

    @Output() uploaded = new EventEmitter();
    @Input() projectId: number;

    constructor(
        private _imageHttpService: ImageHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    upload(fileInput: any){
        let loadingId = this._loadingService.startLoading();

        let files = <Array<File>>fileInput.target.files;

        this._imageHttpService.upload(files, this.projectId).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                fileInput.target.value = "";
                this.uploaded.emit();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}