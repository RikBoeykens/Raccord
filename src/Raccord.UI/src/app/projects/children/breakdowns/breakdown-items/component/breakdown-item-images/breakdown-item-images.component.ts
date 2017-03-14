import { Component, Input, OnInit } from '@angular/core';
import { LinkedImage } from '../../../../images/model/linked-image.model';
import { ImageBreakdownItemHttpService } from '../../service/image-breakdown-item-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { SelectedEntity } from '../../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';

@Component({
    selector: 'breakdown-item-images',
    templateUrl: 'breakdown-item-images.component.html'
})
export class BreakdownItemImagesComponent implements OnInit{

    @Input() projectId: number;
    @Input() breakdownItemId: number;
    @Input() images: LinkedImage[];

    selectedEntity: SelectedEntity;

    constructor(
        private _imageBreakdownItemHttpService: ImageBreakdownItemHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    ngOnInit(){
        this.selectedEntity = new SelectedEntity({entityId: this.breakdownItemId, type: EntityType.breakdownItem});
    }

    getImages(){
        let loadingId = this._loadingService.startLoading();

        this._imageBreakdownItemHttpService.getImages(this.breakdownItemId).then(data => {
            this.images = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    setAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageBreakdownItemHttpService.setImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully set as primary for breakdown item.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageBreakdownItemHttpService.removeImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed as primary for breakdown item.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeLink(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageBreakdownItemHttpService.removeLink(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed link between image and breakdown item.");
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