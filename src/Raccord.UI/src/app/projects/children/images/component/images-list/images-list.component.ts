import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ImageHttpService } from '../../service/image-http.service';
import { ImageSummary } from '../../model/image-summary.model';
import { Image } from '../../model/image.model';
import { ProjectSummary } from '../../../../model/project-summary.model';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { DragulaService } from 'ng2-dragula';
import { HtmlClassHelpers } from '../../../../../shared/helpers/html-class.helpers';

@Component({
    templateUrl: 'images-list.component.html',
})
export class ImagesListComponent implements OnInit {

    images: ImageSummary[];
    project: ProjectSummary;

    constructor(
        private _imageHttpService: ImageHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private dragulaService: DragulaService
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { images: ImageSummary[], project: ProjectSummary }) => {
            this.images = data.images;
            this.project = data.project;
        });
    }

    getImages(){
        
        let loadingId = this._loadingService.startLoading();

        this._imageHttpService.getAll(this.project.id).then(images => {
            this.images = images;
            this._loadingService.endLoading(loadingId);
        });
    }

    imagesUploaded(){
        this.getImages();
    }

    remove(image: ImageSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove image ${image.title}?`)){

            let loadingId = this._loadingService.startLoading();

            this._imageHttpService.delete(image.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                    this.getImages();
                }else{
                    this._dialogService.success('The image was successfully removed');
                    this.getImages();
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }

    }
}