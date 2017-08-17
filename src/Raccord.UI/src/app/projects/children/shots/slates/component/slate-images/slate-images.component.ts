import { Component, Input, OnInit } from '@angular/core';
import { LinkedImage } from "../../../../images/model/linked-image.model";
import { SelectedEntity } from "../../../../../../shared/model/selected-entity.model";
import { ImageSlateHttpService } from "../../service/image-slate-http.service";
import { LoadingService } from "../../../../../../loading/service/loading.service";
import { DialogService } from "../../../../../../shared/service/dialog.service";
import { EntityType } from "../../../../../../shared/enums/entity-type.enum";

@Component({
    selector: 'slate-images',
    templateUrl: 'slate-images.component.html'
})
export class SlateImagesComponent implements OnInit{

    @Input() projectId: number;
    @Input() slateId: number;
    @Input() images: LinkedImage[];

    selectedEntity: SelectedEntity;

    constructor(
        private _imageSlateHttpService: ImageSlateHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    ngOnInit(){
        this.selectedEntity = new SelectedEntity({entityId: this.slateId, type: EntityType.slate});
    }

    getImages(){
        let loadingId = this._loadingService.startLoading();

        this._imageSlateHttpService.getImages(this.slateId).then(data => {
            this.images = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    setAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageSlateHttpService.setImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully set as primary for slate.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeAsPrimary(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageSlateHttpService.removeImageAsPrimary(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed as primary for slate.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeLink(image: LinkedImage){
        let loadingId = this._loadingService.startLoading();

        this._imageSlateHttpService.removeLink(image.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImages();
                this._dialogService.success("Successfully removed link between image and slate.");
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