export class LatLng{
    latitude?: number;
    longitude?: number;

    constructor(obj?: {
        latitude?: number,
        longitude?: number,
    }){
        if(obj){
            this.latitude = obj.latitude;
            this.longitude = obj.longitude;
        }
    }
}