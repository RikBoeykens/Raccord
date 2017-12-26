import { Component, Input } from '@angular/core';
import { Image } from '../../model/image.model';
import { ImageUrlHelpers } from '../../helpers/image-url.helpers';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { ImageHttpService } from '../../service/image-http.service';
import { DomSanitizer } from '@angular/platform-browser';
import { ImageExtensionHelpers } from '../../helpers/image-extension.helpers';

@Component({
    selector: 'show-image',
    templateUrl: 'show-image.component.html'
})
export class ShowImageComponent implements OnInit{

    @Input() image: Image;
    @Input() cardImage;
    @Input() listAvatar;

    base64Image: string;
    hasImage: boolean;
    loadingImage: boolean = true;

    constructor(
        private _imageHttpService: ImageHttpService,
        private _sanitizer: DomSanitizer
    ){
    }

    ngOnInit(){
        this._imageHttpService.getBase64(this.image.id).then(data => {
            this.loadingImage = false;
            this.hasImage = data.hasContent;
            if(data.hasContent){
                this.base64Image = data.content;
            }
        });
    }

    getImageUrl(){
        let extension = ImageExtensionHelpers.getExtension(this.image);

        return this._sanitizer.bypassSecurityTrustUrl(`data:image/${extension};base64,${this.base64Image}`);
    }
}