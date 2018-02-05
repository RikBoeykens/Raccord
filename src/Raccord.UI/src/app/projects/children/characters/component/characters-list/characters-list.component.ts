import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CharacterHttpService } from '../../service/character-http.service';
import { CharacterSummary } from '../../model/character-summary.model';
import { Character } from '../../model/character.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';

@Component({
    templateUrl: 'characters-list.component.html',
})
export class CharactersListComponent implements OnInit {

    characters: CharacterSummary[] = [];
    project: ProjectSummary;

    constructor(
        private _characterHttpService: CharacterHttpService,
        private _loadingService: LoadingService,
        private _route: ActivatedRoute,
        private _router: Router,
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { characters: CharacterSummary[], project: ProjectSummary }) => {
            this.characters = data.characters;
            this.project = data.project;
        });
    }
}