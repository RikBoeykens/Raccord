import { Component, Input, OnInit } from '@angular/core';
import { LinkedImage } from '../../../images/model/linked-image.model';
import { ImageCharacterHttpService } from '../../service/image-character-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';

@Component({
    selector: 'character-images',
    templateUrl: 'character-images.component.html'
})
export class CharacterImagesComponent implements OnInit{

    @Input() projectId: number;
    @Input() characterId: number;
    @Input() images: LinkedImage[];

    selectedEntity: SelectedEntity;

    constructor(
        private _imageCharacterHttpService: ImageCharacterHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    ngOnInit(){
        this.selectedEntity = new SelectedEntity({entityId: this.characterId, type: EntityType.character});
    }

    getImages(){
        let loadingId = this._loadingService.startLoading();

        this._imageCharacterHttpService.getImages(this.characterId).then(data => {
            this.images = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    setAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageCharacterHttpService.setImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully set as primary for character.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageCharacterHttpService.removeImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed as primary for character.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeLink(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageCharacterHttpService.removeLink(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed link between image and character.");
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