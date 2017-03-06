import { Component, Input } from '@angular/core';
import { LinkedImage } from '../../../images/model/linked-image.model';
import { ImageLocationHttpService } from '../../service/image-location-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    selector: 'location-images',
    templateUrl: 'location-images.component.html'
})
export class LocationImagesComponent{

    @Input() locationId: number;
    @Input() images: LinkedImage[];

    constructor(
        private _imageLocationHttpService: ImageLocationHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    getImages(){
        let loadingId = this._loadingService.startLoading();

        this._imageLocationHttpService.getImages(this.locationId).then(data => {
            this.images = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    setAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageLocationHttpService.setImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully set as primary for location.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageLocationHttpService.removeImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed as primary for location.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}