import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SceneHttpService } from '../../service/scene-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { FullScene } from '../../model/full-scene.model';
import { Scene } from '../../model/scene.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { BreakdownTypeSummary } from
    '../../../breakdowns/children/breakdown-types/model/breakdown-type-summary.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { ProjectPermissionEnum } from
    '../../../../../shared/children/users/project-roles/enums/project-permission.enum';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { ParentCommentType } from '../../../../../shared/enums/parent-comment-type.enum';

@Component({
    templateUrl: 'scene-landing.component.html',
})
export class SceneLandingComponent implements OnInit {

    public scene: FullScene;
    public viewScene: Scene;
    public project: ProjectSummary;

    constructor(
        private _sceneHttpService: SceneHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: { scene: FullScene, project: ProjectSummary }) => {
            this.scene = data.scene;
            this.viewScene = new Scene(data.scene);
            this.project = data.project;
        });
    }

    public getScene() {
        this._loadingWrapperService.Load(
            this._sceneHttpService.get(this.scene.id),
            (data) => {
                this.scene = data;
                this.viewScene = new Scene(data);
            }
        );
    }

    public updateScene() {
        let loadingId = this._loadingService.startLoading();

        this._sceneHttpService.post(this.viewScene).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getScene();
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }

    public getCanEdit() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.canEditGeneral
        );
    }

    public getCanComment() {
        return AccountHelpers.hasProjectPermission(
            this.project.id,
            ProjectPermissionEnum.CanComment
        );
    }

    public getParentCommentType() {
        return ParentCommentType.scene;
    }
}
