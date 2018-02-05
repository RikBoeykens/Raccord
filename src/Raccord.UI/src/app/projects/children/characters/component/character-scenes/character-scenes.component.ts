import { Component, Input } from '@angular/core';
import { LinkedScene } from '../../../scenes/model/linked-scene.model';
import { CharacterSceneHttpService } from '../../../scenes/service/character-scene-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from '../../../../../shared/children/users/project-roles/enums/project-permission.enum';

@Component({
    selector: 'character-scenes',
    templateUrl: 'character-scenes.component.html'
})
export class CharacterScenesComponent{

    @Input() projectId: number;
    @Input() characterId: number;
    @Input() scenes: LinkedScene[];


    constructor(
        private _characterSceneHttpService: CharacterSceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    getScenes(){
        let loadingId = this._loadingService.startLoading();

        this._characterSceneHttpService.getScenes(this.characterId).then(data => {
            this.scenes = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    removeLink(scene: LinkedScene){
        event.stopPropagation();
        let loadingId = this._loadingService.startLoading();

        this._characterSceneHttpService.removeLink(scene.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScenes();
                this._dialogService.success("Successfully removed link between character and scene.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.projectId,
            ProjectPermissionEnum.canEditGeneral
        );
    }
}