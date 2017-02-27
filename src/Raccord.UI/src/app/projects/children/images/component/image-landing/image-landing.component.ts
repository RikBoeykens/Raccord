import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ImageHttpService } from '../../service/image-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { Image } from '../../model/image.model';
import { FullImage } from '../../model/full-image.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { ImageUrlHelpers } from '../../helpers/image-url.helpers';

@Component({
    templateUrl: 'image-landing.component.html',
})
export class ImageLandingComponent {

    image: FullImage;
    viewImage: Image;
    project: ProjectSummary;

    constructor(
        private _imageHttpService: ImageHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { image: FullImage, project: ProjectSummary }) => {
            this.image = data.image;
            this.viewImage = new Image(data.image);
            this.project = data.project;
        });
    }

    getImageUrl(image: FullImage): string{
        return ImageUrlHelpers.getUrl(image);
    }

    getImage(){
        let loadingId = this._loadingService.startLoading();

        this._imageHttpService.get(this.image.id).then(data => {
            this.image = data;
            this.viewImage = new Image(data);
            this._loadingService.endLoading(loadingId);
        });
    }

    updateImage(){
        let loadingId = this._loadingService.startLoading();

        this._imageHttpService.post(this.viewImage).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.getImage();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }
}