import { Component, Input } from '@angular/core';
import { LinkedImage } from '../../../images/model/linked-image.model';
import { SceneHttpService } from '../../service/scene-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    selector: 'scene-images',
    templateUrl: 'scene-images.component.html'
})
export class SceneImagesComponent{

    @Input() sceneId: number;
    @Input() images: LinkedImage[];

    constructor(
        private _sceneHttpService: SceneHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    getImages(){
        let loadingId = this._loadingService.startLoading();

        this._sceneHttpService.getImages(this.sceneId).then(data => {
            this.images = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    setAsPrimary(image: LinkedImage){
        alert('set as primary');
    }

    removeAsPrimary(image: LinkedImage){
        alert('remove as primary');
    }
}