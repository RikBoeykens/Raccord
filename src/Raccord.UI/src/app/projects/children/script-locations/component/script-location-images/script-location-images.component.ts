import { Component, Input, OnInit } from '@angular/core';
import { LinkedImage } from '../../../images/model/linked-image.model';
import { ImageScriptLocationHttpService } from '../../service/image-script-location-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';

@Component({
    selector: 'screenplay-location-images',
    templateUrl: 'script-location-images.component.html'
})
export class ScriptLocationImagesComponent implements OnInit{

    @Input() projectId: number;
    @Input() scriptLocationId: number;
    @Input() images: LinkedImage[];

    selectedEntity: SelectedEntity;

    constructor(
        private _imageScriptLocationHttpService: ImageScriptLocationHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _loadingWrapperService: LoadingWrapperService
    ){
    }

    ngOnInit(){
        this.selectedEntity = new SelectedEntity({entityId: this.scriptLocationId, type: EntityType.scriptLocation});
    }

    getImages(){
        this._loadingWrapperService.Load(
            this._imageScriptLocationHttpService.getImages(this.scriptLocationId),
            (data) => this.images = data
        );
    }

    setAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageScriptLocationHttpService.setImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully set as primary for script location.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageScriptLocationHttpService.removeImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed as primary for script location.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeLink(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageScriptLocationHttpService.removeLink(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed link between image and script location.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    imagesUploaded(){
        this.getImages();
    }
}