import { Component, Input, OnInit } from '@angular/core';
import { LinkedImage } from "../../../../images/model/linked-image.model";
import { SelectedEntity } from "../../../../../../shared/model/selected-entity.model";
import { ImageSlateHttpService } from "../../service/image-slate-http.service";
import { DialogService } from "../../../../../../shared/service/dialog.service";
import { EntityType } from "../../../../../../shared/enums/entity-type.enum";
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';

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
        private _loadingWrapperService: LoadingWrapperService,
        private _dialogService: DialogService
    ){
    }

    ngOnInit(){
        this.selectedEntity = new SelectedEntity({entityId: this.slateId, type: EntityType.slate});
    }

    getImages(){
        this._loadingWrapperService.Load(
            this._imageSlateHttpService.getImages(this.slateId),
            (data) => this.images = data
        );
    }

    setAsPrimary(image: LinkedImage) {
        this._loadingWrapperService.Load(
            this._imageSlateHttpService.setImageAsPrimary(image.linkID),
            () => {
                this.getImages();
                this._dialogService.success('Successfully set as primary for slate.');
            }
        );
    }

    removeAsPrimary(image: LinkedImage) {
        this._loadingWrapperService.Load(
            this._imageSlateHttpService.removeImageAsPrimary(image.linkID),
            () => {
                this.getImages();
                this._dialogService.success('Successfully removed as primary for slate.');
            }
        );
    }

    removeLink(image: LinkedImage){
        this._loadingWrapperService.Load(
            this._imageSlateHttpService.removeLink(image.linkID),
            () => {
                this.getImages();
                this._dialogService.success('Successfully removed link between image and slate.');
            }
        );
    }

    public imagesUploaded() {
        this.getImages();
    }
}