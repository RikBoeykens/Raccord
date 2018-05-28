import { Component, Input, OnInit } from '@angular/core';
import { BreakdownItemSceneHttpService } from '../../service/breakdown-item-scene-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { BreakdownItemHttpService } from
    '../../../breakdowns/children/breakdown-items/service/breakdown-item-http.service';
import { BreakdownType } from
    '../../../breakdowns/children/breakdown-types/model/breakdown-type.model';
import { BreakdownItem } from
    '../../../breakdowns/children/breakdown-items/model/breakdown-item.model';
import { SceneBreakdown } from '../../../breakdowns/model/scene-breakdown.model';
import { SceneBreakdownItem } from
    '../../../breakdowns/children/breakdown-items/model/scene-breakdown-item.model';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';

@Component({
    selector: 'scene-breakdown-items',
    templateUrl: 'scene-breakdown-items.component.html'
})
export class SceneBreakdownItemsComponent implements OnInit {

    @Input() public sceneId: number;
    @Input() public projectId: number;
    @Input() public breakdown: SceneBreakdown;

    public viewNewBreakdownItem: BreakdownItem;
    public newBreakdownItem: BreakdownItem;
    public selectedTypeId: number;

    constructor(
        private _breakdownItemSceneHttpService: BreakdownItemSceneHttpService,
        private _breakdownItemHttpService: BreakdownItemHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ) {
        this.viewNewBreakdownItem = new BreakdownItem();
    }

    public ngOnInit() {
        this.resetNewBreakdownItem();
    }

    public getBreakdownItems() {
        this._loadingWrapperService.Load(
            this._breakdownItemSceneHttpService.getBreakdownItems(
                this.sceneId,
                this.breakdown.id
            ),
            (data) => this.breakdown.items = data
        );
    }

    public resetNewBreakdownItem() {
        this.viewNewBreakdownItem = new BreakdownItem();
        this.newBreakdownItem = null;
    }

    public addLink() {
        if (this.viewNewBreakdownItem.id !== 0) {
            this.addBreakdownItemLink(this.viewNewBreakdownItem.id);
        } else {
            // first create breakdown item, then link it
            let loadingId = this._loadingService.startLoading();

            this.viewNewBreakdownItem.breakdownTypeID = this.selectedTypeId;
            this.newBreakdownItem = this.viewNewBreakdownItem;

            this._breakdownItemHttpService.post(this.newBreakdownItem).then((data) => {
                if (typeof(data) === 'string') {
                    this._dialogService.error(data);
                }else {
                    this.addBreakdownItemLink(data);
                }
            }).catch()
            .then(() =>
                this._loadingService.endLoading(loadingId)
            );
        }
    }

    public addBreakdownItemLink(breakdownItemId: number) {
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemSceneHttpService.addLink(breakdownItemId, this.sceneId).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getBreakdownItems();
                this.resetNewBreakdownItem();
                this._dialogService.success(
                    'Successfully added link between breakdown item and scene.'
                );
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }

    public removeLink(breakdownItem: SceneBreakdownItem) {
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemSceneHttpService.removeLink(breakdownItem.linkID).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getBreakdownItems();
                this._dialogService.success(
                    'Successfully removed link between breakdown item and scene.'
                );
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }

    public getCanEdit() {
        return this.breakdown.userID === AccountHelpers.getUserId();
    }
}
