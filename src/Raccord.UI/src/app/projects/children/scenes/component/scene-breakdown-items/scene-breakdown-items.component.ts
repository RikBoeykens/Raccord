import { Component, Input, OnInit } from '@angular/core';
import { LinkedBreakdownItem } from '../../../breakdowns/breakdown-items/model/linked-breakdown-item.model';
import { BreakdownItem } from '../../../breakdowns/breakdown-items/model/breakdown-item.model';
import { BreakdownType } from '../../../breakdowns/breakdown-types/model/breakdown-type.model';
import { BreakdownItemSceneHttpService } from '../../service/breakdown-item-scene-http.service';
import { BreakdownItemHttpService } from '../../../breakdowns/breakdown-items/service/breakdown-item-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { SelectedEntity } from '../../../../../shared/model/selected-entity.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';

@Component({
    selector: 'scene-breakdown-items',
    templateUrl: 'scene-breakdown-items.component.html'
})
export class SceneBreakdownItemsComponent implements OnInit{

    @Input() sceneId: number;
    @Input() breakdownItems: LinkedBreakdownItem[];
    @Input() breakdownTypes: BreakdownType[];

    viewNewBreakdownItem: BreakdownItem;
    newBreakdownItem: BreakdownItem;
    selectedTypeId: number;


    constructor(
        private _breakdownItemSceneHttpService: BreakdownItemSceneHttpService,
        private _breakdownItemHttpService: BreakdownItemHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
        this.viewNewBreakdownItem = new BreakdownItem();
    }

    ngOnInit(){
        this.selectedTypeId = this.breakdownTypes[0].id;
        this.resetNewBreakdownItem();
    }

    getBreakdownItems(){
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemSceneHttpService.getBreakdownItems(this.sceneId).then(data => {
            this.breakdownItems = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    resetNewBreakdownItem(){
        this.viewNewBreakdownItem = new BreakdownItem();
        this.viewNewBreakdownItem.type = new BreakdownType();
        this.viewNewBreakdownItem.type.id = this.selectedTypeId;
        this.newBreakdownItem = null;
    }

    addLink(){
        if(this.viewNewBreakdownItem.id!==0){
            this.addBreakdownItemLink(this.viewNewBreakdownItem.id);
        }
        else{
            // first create breakdown item, then link it
            let loadingId = this._loadingService.startLoading();

            this.newBreakdownItem = this.viewNewBreakdownItem;

            this._breakdownItemHttpService.post(this.newBreakdownItem).then(data=>{
                if(typeof(data)=='string'){
                    this._dialogService.error(data);
                }else{
                    this.addBreakdownItemLink(data);
                }
            }).catch()
            .then(()=>
                this._loadingService.endLoading(loadingId)
            );
        }
    }

    addBreakdownItemLink(breakdownItemId: number){
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemSceneHttpService.addLink(breakdownItemId, this.sceneId).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getBreakdownItems();
                this.resetNewBreakdownItem();
                this._dialogService.success("Successfully added link between breakdown item and scene.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    removeLink(breakdownItem: LinkedBreakdownItem){
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemSceneHttpService.removeLink(breakdownItem.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getBreakdownItems();
                this._dialogService.success("Successfully removed link between breakdown item and scene.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}