import { Component, Input } from '@angular/core';
import { LinkedScene } from '../../../../../scenes/model/linked-scene.model';
import { BreakdownItemSceneHttpService } from '../../../../../scenes/service/breakdown-item-scene-http.service';
import { LoadingService } from '../../../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../../../shared/service/dialog.service';

@Component({
    selector: 'breakdown-item-scenes',
    templateUrl: 'breakdown-item-scenes.component.html'
})
export class BreakdownItemScenesComponent{

    @Input() projectId: number;
    @Input() breakdownItemId: number;
    @Input() scenes: LinkedScene[];


    constructor(
        private _breakdownItemSceneHttpService: BreakdownItemSceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    getScenes(){
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemSceneHttpService.getScenes(this.breakdownItemId).then(data => {
            this.scenes = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    removeLink(scene: LinkedScene){
        let loadingId = this._loadingService.startLoading();

        this._breakdownItemSceneHttpService.removeLink(scene.linkID).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getScenes();
                this._dialogService.success("Successfully removed link between breakdown item and scene.");
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}