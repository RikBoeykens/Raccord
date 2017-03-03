import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ImageHttpService } from '../../service/image-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { Image } from '../../model/image.model';
import { LinkImage } from '../../model/link-image.model';
import { FullImage } from '../../model/full-image.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LinkedScene } from '../../../scenes/model/linked-scene.model';
import { LinkedLocation } from '../../../locations/model/linked-location.model';
import { ImageUrlHelpers } from '../../helpers/image-url.helpers';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';

@Component({
    templateUrl: 'image-landing.component.html',
})
export class ImageLandingComponent {

    image: FullImage;
    viewImage: Image;
    project: ProjectSummary;
    imageLinkTypes: EntityType[] = [EntityType.location, EntityType.scene];

    constructor(
        private _imageHttpService: ImageHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { image: FullImage, project: ProjectSummary }) => {
            this.image = data.image;
            this.viewImage = new Image(data.image);
            this.project = data.project;
        });
    }

    getImageUrl(image: FullImage): string{
        return ImageUrlHelpers.getUrl(image);
    }

    getImage(){
        let loadingId = this._loadingService.startLoading();

        this._imageHttpService.get(this.image.id).then(data => {
            this.image = data;
            this.viewImage = new Image(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateImage(){
        let loadingId = this._loadingService.startLoading();

        this._imageHttpService.post(this.viewImage).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImage();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    linkImage(selectedEntity: SelectedEntity){
        let loadingId = this._loadingService.startLoading();

        this._imageHttpService.addImageLink(new LinkImage({imageId: this.image.id, selectedEntity: selectedEntity})).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImage();
                this._dialogService.success("Successfully linked image.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeSceneLink(scene: LinkedScene){
        let selectedEntity = new SelectedEntity({entityId: scene.linkID, type: EntityType.scene});
        this.removeImageLink(selectedEntity);
    }

    removeLocationLink(location: LinkedLocation){
        let selectedEntity = new SelectedEntity({entityId: location.linkID, type: EntityType.location});
        this.removeImageLink(selectedEntity);
    }

    private removeImageLink(selectedEntity: SelectedEntity){
        let loadingId = this._loadingService.startLoading();

        this._imageHttpService.removeImageLink(new LinkImage({imageId: this.image.id, selectedEntity: selectedEntity})).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImage();
                this._dialogService.success("Successfully removed link.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    public setAsPrimary(image: FullImage){
        let loadingId = this._loadingService.startLoading();

        this._imageHttpService.setAsPrimary(image.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImage();
                this._dialogService.success("Successfully set as primary for project.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    public removeAsPrimary(image: FullImage){
        let loadingId = this._loadingService.startLoading();

        this._imageHttpService.removeAsPrimary(image.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImage();
                this._dialogService.success("Successfully removed as primary for project.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}