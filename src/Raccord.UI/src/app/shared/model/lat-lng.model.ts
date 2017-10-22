export class LatLng {
    public latitude?: number;
    public longitude?: number;
    public hasLatLng: boolean;

    constructor(obj?: {
        latitude?: number,
        longitude?: number,
        hasLatLng: boolean
    }) {
        if (obj) {
            this.latitude = obj.latitude;
            this.longitude = obj.longitude;
            this.hasLatLng = obj.hasLatLng;
        }
    }
}
