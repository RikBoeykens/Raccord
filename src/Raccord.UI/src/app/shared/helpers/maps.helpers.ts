import { LatLng } from '../index';

export class MapsHelpers {

    public static getBounds(markers: LatLng[]) {
        let north = markers[0].latitude + this._buffer;
        let west = markers[0].longitude + this._buffer;
        let south = markers[0].latitude - this._buffer;
        let east = markers[0].longitude - this._buffer;
        markers.forEach((marker) => {
            if (north < marker.latitude) {
                north = marker.latitude;
            }
            if (west > marker.longitude) {
                west = marker.longitude;
            }
            if (south > marker.latitude) {
                south = marker.latitude;
            }
            if (east < marker.longitude) {
                east = marker.longitude;
            }
        });
        return {
            east,
            north,
            south,
            west
        };
    }

    public static getTime(time: string): Date {
        let timeParts = time.split(':');
        let hours = parseInt(timeParts[0], 10);
        let minutes = parseInt(timeParts[1], 10);
        return new Date(0, 0, 0, hours, minutes);
    }

    private static _buffer = 0.01;
}
