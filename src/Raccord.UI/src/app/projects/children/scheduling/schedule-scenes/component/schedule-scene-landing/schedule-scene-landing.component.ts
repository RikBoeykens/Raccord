import { Component, OnInit, OnChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FullScheduleScene } from '../../model/full-schedule-scene.model';
import { ScheduleScene } from '../../model/schedule-scene.model';
import { LinkedCharacter } from '../../../../../children/characters/model/linked-character.model';
import { LocationSetSummary } from '../../../../locations';
import { ScheduleSceneHttpService } from '../../service/schedule-scene-http.service';
import { ScheduleCharacterHttpService }
    from '../../../schedule-characters/service/schedule-character-http.service';
import { LoadingService } from '../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../shared/service/dialog.service';
import { ProjectSummary } from '../../../../../model/project-summary.model';
import { PageLengthHelpers } from '../../../../../../shared/helpers/page-length.helpers';
import { LoadingWrapperService } from '../../../../../../shared/service/loading-wrapper.service';
import { CrewUnitNavEnum } from '../../../../crew/crew-units/enum/crew-unit-nav.enum';
import { CrewUnit } from '../../../../crew/crew-units/model/crew-unit.model';

@Component({
    templateUrl: 'schedule-scene-landing.component.html',
})
export class ScheduleSceneLandingComponent implements OnInit, OnChanges {

    public scheduleScene: FullScheduleScene;
    public project: ProjectSummary;
    public crewUnit: CrewUnit;
    public stringPageLength: string;
    public characters: LinkedCharacter[] = [];
    public scheduleCharacters: ScheduleCharacterWrapper[] = [];
    public locationSets: LocationSetSummary[] = [];

    constructor(
        private _scheduleSceneHttpService: ScheduleSceneHttpService,
        private _scheduleCharacterHttpService: ScheduleCharacterHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _loadingWrapperService: LoadingWrapperService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: {
            scheduleScene: FullScheduleScene,
            project: ProjectSummary,
            crewUnit: CrewUnit,
            characters: LinkedCharacter[],
            locationSets: LocationSetSummary[]
        }) => {
            this.scheduleScene = data.scheduleScene;
            this.setStringPageLength();
            this.project = data.project;
            this.crewUnit = data.crewUnit;
            this.characters = data.characters;
            this.locationSets = data.locationSets;
            this.setScheduleCharacterWrappers();
        });
    }

    public ngOnChanges() {
        this.setStringPageLength();
    }

    public setStringPageLength() {
        this.stringPageLength =
            PageLengthHelpers.getPageLengthString(this.scheduleScene.pageLength);
    }

    public getScheduleScene() {
        this._loadingWrapperService.Load(
            this._scheduleSceneHttpService.get(this.project.id, this.scheduleScene.id),
            (data) => {
                this.scheduleScene = data;
                this.setScheduleCharacterWrappers();
            }
        );
    }

    public updateScheduleScene() {
        let updatedScheduleScene = new ScheduleScene({
            id: this.scheduleScene.id,
            pageLength: PageLengthHelpers.getPageLengthNumber(this.stringPageLength),
            sceneId: this.scheduleScene.scene.id,
            scheduleDayId: this.scheduleScene.scheduleDay.id
        });
        if (this.scheduleScene.locationSet.id !== 0) {
            updatedScheduleScene.locationSetId = this.scheduleScene.locationSet.id;
        }

        this._loadingWrapperService.Load(
            this._scheduleSceneHttpService.post(this.project.id, updatedScheduleScene),
            () => {
                this.getScheduleScene();
            },
            () => {
                this.updateScheduleCharacters();
            }
        );
    }

    public updateScheduleCharacters() {
        let linksToRemove =
            this.scheduleCharacters.filter((character) =>
                !character.isLinked && character.scheduleCharacterId);
        let linksToAdd =
            this.scheduleCharacters.filter((character) =>
            character.isLinked && !character.scheduleCharacterId);

        linksToRemove.forEach((character) => this.removeScheduleCharacterLink(character));
        linksToAdd.forEach((character) => this.addScheduleCharacterLink(character));
    }

    public removeScheduleCharacterLink(character: ScheduleCharacterWrapper) {
        this._loadingWrapperService.Load(
            this._scheduleCharacterHttpService.removeLink(
                this.project.id,
                character.scheduleCharacterId
            ),
            () => { this.getScheduleScene(); }
        );
    }

    public addScheduleCharacterLink(character: ScheduleCharacterWrapper) {
        this._loadingWrapperService.Load(
            this._scheduleCharacterHttpService.addLink(
                this.project.id,
                this.scheduleScene.id,
                character.linkID),
            () => { this.getScheduleScene(); }
        );
    }

    public setScheduleCharacterWrappers() {
        let characters = [];
        for (let sceneCharacter of this.characters){
            let newCharacter = new ScheduleCharacterWrapper(sceneCharacter);
            let existingScheduleCharacters =
                this.scheduleScene.characters
                    .filter((scheduleCharacter) => scheduleCharacter.id === sceneCharacter.id);
            if (existingScheduleCharacters.length > 0) {
                newCharacter.isLinked = true;
                newCharacter.scheduleCharacterId = existingScheduleCharacters[0].linkID;
            }
            characters.push(newCharacter);
        }
        this.scheduleCharacters = characters;
    }

    public getScheduleEditNavType() {
        return CrewUnitNavEnum.scheduleEdit;
    }
}

// tslint:disable-next-line:max-classes-per-file
export class ScheduleCharacterWrapper extends LinkedCharacter {
    public isLinked: boolean;
    public scheduleCharacterId: number;

    constructor(obj) {
        super(obj);
    }
}
