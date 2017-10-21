import { LatLng } from "../index";

export class MapsHelpers {
    public static getBounds(markers: LatLng[]){
        let north = markers[0].latitude + 0.01;
        let west = markers[0].longitude + 0.01;
        let south = markers[0].latitude - 0.01;
        let east = markers[0].longitude - 0.01;
        markers.forEach(marker=>{
            if(north > marker.latitude) north = marker.latitude;
            if(west > marker.longitude) west = marker.longitude;
            if(south < marker.latitude) south = marker.latitude;
            if(east < marker.longitude) east = marker.longitude;
        });
        return {
            east: east,
            north: north,
            south: south,
            west: west
        };
    }
    
    public static getTime(time: string): Date{
        let timeParts = time.split(":");
        let hours = parseInt(timeParts[0]);
        let minutes = parseInt(timeParts[1]);
        return new Date(0, 0, 0, hours, minutes);
    }
}