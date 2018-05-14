import { Component, Input } from '@angular/core';
import { LinkedScene } from '../../../../../scenes/model/linked-scene.model';
import { BreakdownItemSceneHttpService } from
    '../../../../../scenes/service/breakdown-item-scene-http.service';
import { LoadingService } from '../../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../../shared/service/dialog.service';
import { AccountHelpers } from '../../../../../../../account/helpers/account.helper';
import { EntityType } from '../../../../../../../shared/enums/entity-type.enum';
import { SelectedEntity } from '../../../../../../../shared/model/selected-entity.model';
import { LoadingWrapperService } from '../../../../../../../shared/service/loading-wrapper.service';

@Component({
    selector: 'breakdown-item-scenes',
    templateUrl: 'breakdown-item-scenes.component.html'
})
export class BreakdownItemScenesComponent {

    @Input() public projectId: number;
    @Input() public breakdownItemId: number;
    @Input() public scenes: LinkedScene[];
    @Input() public createdById: string;
    public sceneType: EntityType[] = [EntityType.scene];

    constructor(
        private _breakdownItemSceneHttpService: BreakdownItemSceneHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ) {
    }

    public getScenes() {
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemSceneHttpService.getScenes(this.breakdownItemId).then((data) => {
            this.scenes = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    public addLink(scene: SelectedEntity) {
        this._loadingWrapperService.Load(
            this._breakdownItemSceneHttpService.addLink(this.breakdownItemId, scene.entityId),
            () => this.getScenes()
        );
    }

    public removeLink(scene: LinkedScene) {
        this._loadingWrapperService.Load(
            this._breakdownItemSceneHttpService.removeLink(scene.linkID),
            () => {
                this.getScenes();
                this._dialogService.success(
                    'Successfully removed link between breakdown item and scene.');
            }
        );
    }

    public userCanEdit() {
        return this.createdById === AccountHelpers.getUserId();
    }
}
