import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ImageHttpService } from '../../service/image-http.service';
import { ImageSceneHttpService } from '../../../scenes/service/image-scene-http.service';
import { ImageScriptLocationHttpService } from '../../../script-locations/service/image-script-location-http.service';
import { ImageCharacterHttpService } from '../../../characters/service/image-character-http.service';
import { ImageBreakdownItemHttpService } from '../../../breakdowns/breakdown-items/service/image-breakdown-item-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { Image } from '../../model/image.model';
import { LinkImage } from '../../model/link-image.model';
import { FullImage } from '../../model/full-image.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LinkedScene } from '../../../scenes/model/linked-scene.model';
import { LinkedScriptLocation } from '../../../script-locations/model/linked-script-location.model';
import { LinkedCharacter } from '../../../characters/model/linked-character.model';
import { LinkedBreakdownItem } from '../../../breakdowns/breakdown-items/model/linked-breakdown-item.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';

@Component({
    templateUrl: 'image-landing.component.html',
})
export class ImageLandingComponent {

    image: FullImage;
    viewImage: Image;
    project: ProjectSummary;
    imageLinkTypes: EntityType[] = [EntityType.scriptLocation, EntityType.scene, EntityType.character, EntityType.breakdownItem];

    constructor(
        private _imageHttpService: ImageHttpService,
        private _imageSceneHttpService: ImageSceneHttpService,
        private _imageScriptLocationHttpService: ImageScriptLocationHttpService,
        private _imageCharacterHttpService: ImageCharacterHttpService,
        private _imageBreakdownItemHttpService: ImageBreakdownItemHttpService,
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
        switch(selectedEntity.type){
            case EntityType.scene:
                this.linkSceneImage(selectedEntity.entityId);
                break;
            case EntityType.scriptLocation:
                this.linkScriptLocationImage(selectedEntity.entityId);
                break;
            case EntityType.character:
                this.linkCharacterImage(selectedEntity.entityId);
                break;
            case EntityType.breakdownItem:
                this.linkBreakdownItemImage(selectedEntity.entityId);
                break;
        }
    }

    linkSceneImage(sceneId: number){
        let loadingId = this._loadingService.startLoading();

        this._imageSceneHttpService.addLink(this.image.id, sceneId).then(data=>{
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

    linkScriptLocationImage(locationId: number){
        let loadingId = this._loadingService.startLoading();

        this._imageScriptLocationHttpService.addLink(this.image.id, locationId).then(data=>{
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

    linkCharacterImage(characterId: number){
        let loadingId = this._loadingService.startLoading();

        this._imageCharacterHttpService.addLink(this.image.id, characterId).then(data=>{
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

    linkBreakdownItemImage(breakdownItemId: number){
        let loadingId = this._loadingService.startLoading();

        this._imageBreakdownItemHttpService.addLink(this.image.id, breakdownItemId).then(data=>{
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
        let loadingId = this._loadingService.startLoading();

        this._imageSceneHttpService.removeLink(scene.linkID).then(data=>{
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

    removeScriptLocationLink(location: LinkedScriptLocation){
        let loadingId = this._loadingService.startLoading();

        this._imageScriptLocationHttpService.removeLink(location.linkID).then(data=>{
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

    removeCharacterLink(character: LinkedCharacter){
        let loadingId = this._loadingService.startLoading();

        this._imageCharacterHttpService.removeLink(character.linkID).then(data=>{
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

    removeBreakdownItemLink(breakdownItem: LinkedBreakdownItem){
        let loadingId = this._loadingService.startLoading();

        this._imageBreakdownItemHttpService.removeLink(breakdownItem.linkID).then(data=>{
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