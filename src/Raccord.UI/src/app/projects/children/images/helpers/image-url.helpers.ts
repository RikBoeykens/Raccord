import { Image } from '../model/image.model';
import { AppSettings } from '../../../../app.settings';

export class ImageUrlHelpers {

    public static getUrl(image: Image) {
        return `${AppSettings.API_ENDPOINT}/images/${image.id}/download/${image.fileName}`;
    }
}