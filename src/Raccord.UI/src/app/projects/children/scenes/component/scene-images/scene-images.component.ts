import { Component, Input, OnInit } from '@angular/core';
import { LinkedImage } from '../../../images/model/linked-image.model';
import { ImageSceneHttpService } from '../../service/image-scene-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';

@Component({
    selector: 'scene-images',
    templateUrl: 'scene-images.component.html'
})
export class SceneImagesComponent implements OnInit{

    @Input() projectId: number;
    @Input() sceneId: number;
    @Input() images: LinkedImage[];

    selectedEntity: SelectedEntity;

    constructor(
        private _imageSceneHttpService: ImageSceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    ngOnInit(){
        this.selectedEntity = new SelectedEntity({entityId: this.sceneId, type: EntityType.scene});
    }

    getImages(){
        let loadingId = this._loadingService.startLoading();

        this._imageSceneHttpService.getImages(this.sceneId).then(data => {
            this.images = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    setAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageSceneHttpService.setImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully set as primary for scene.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageSceneHttpService.removeImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed as primary for scene.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeLink(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageSceneHttpService.removeLink(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed link between image and scene.");
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