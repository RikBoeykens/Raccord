import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CharacterHttpService } from '../../service/character-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { FullCharacter } from '../../model/full-character.model';
import { Character } from '../../model/character.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from '../../../../../shared/children/users/project-roles/enums/project-permission.enum';

@Component({
    templateUrl: 'character-landing.component.html',
})
export class CharacterLandingComponent {

    character: FullCharacter;
    viewCharacter: Character;
    project: ProjectSummary;

    constructor(
        private _characterHttpService: CharacterHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { character: FullCharacter, project: ProjectSummary }) => {
            this.character = data.character;
            this.viewCharacter = new Character(data.character);
            this.project = data.project;
        });
    }

    getCharacter(){
        let loadingId = this._loadingService.startLoading();

        this._characterHttpService.get(this.character.id).then(data => {
            this.character = data;
            this.viewCharacter = new Character(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateCharacter(){
        let loadingId = this._loadingService.startLoading();

        this._characterHttpService.post(this.viewCharacter).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getCharacter();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }
}