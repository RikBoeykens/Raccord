import { Component, Input } from '@angular/core';
import { Image } from '../../model/image.model';
import { ImageUrlHelpers } from '../../helpers/image-url.helpers';

@Component({
    selector: 'show-card-image',
    templateUrl: 'show-card-image.component.html'
})
export class ShowCardImageComponent{

    @Input() image: Image;

    constructor(
    ){
    }

    getImageUrl(image: Image): string{
        return ImageUrlHelpers.getUrl(image);
    }
}