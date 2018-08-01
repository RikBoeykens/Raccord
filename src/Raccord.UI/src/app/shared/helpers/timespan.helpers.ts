export class TimespanHelpers {
    public static getTimespanString(value: number): string {
        if (typeof(value) === 'undefined') {
            return '00:00:00';
        }

        const hours = Math.floor(value / 3600);
        const minutesAndSeconds = value % 3600;
        const minutes = Math.floor(minutesAndSeconds / 60);
        const seconds = Math.floor(minutesAndSeconds % 60);
        // tslint:disable-next-line:max-line-length
        return `${this.toPaddedString(hours)}:${this.toPaddedString(minutes)}:${this.toPaddedString(seconds)}`;
    }

    public static getTimespanNumber(stringValue: string): number {
        let resultNumber = 0;
        const arr = stringValue.split(':');
        if (arr.length === 3) {
            resultNumber += parseInt(arr[0], 10) * 3600;
            resultNumber += parseInt(arr[1], 10) * 60;
            resultNumber += parseInt(arr[2], 10);
        }
        return resultNumber;
    }

    private static toPaddedString(value: number): string {
        return value < 10 ? `0${value}` : value.toString();
    }
}
