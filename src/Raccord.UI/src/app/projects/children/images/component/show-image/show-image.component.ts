import { Component, Input } from '@angular/core';
import { Image } from '../../model/image.model';
import { ImageUrlHelpers } from '../../helpers/image-url.helpers';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { ImageHttpService } from '../../service/image-http.service';
import { DomSanitizer } from '@angular/platform-browser';
import { ImageExtensionHelpers } from '../../helpers/image-extension.helpers';
import { ImageHelpers } from '../../../../../shared/helpers/image.helpers';
import { Base64Image } from '../../../../../shared/model/base-64-image.model';

@Component({
    selector: 'show-image',
    templateUrl: 'show-image.component.html'
})
export class ShowImageComponent implements OnInit{

    @Input() image: Image;
    @Input() cardImage;
    @Input() listAvatar;
    @Input() cardAvatar;

    base64Image: Base64Image = new Base64Image();
    loadingImage: boolean = true;

    constructor(
        private _imageHttpService: ImageHttpService,
        private _sanitizer: DomSanitizer
    ){
    }

    ngOnInit(){
        this._imageHttpService.getBase64(this.image.id).then(data => {
            this.loadingImage = false;
            data = <Base64Image> data;
            if(data.hasContent){
                this.base64Image = data;
            }
        });
    }

    getImageUrl(){
        return this._sanitizer.bypassSecurityTrustUrl(ImageHelpers.getBase64Url(this.base64Image));
    }
}