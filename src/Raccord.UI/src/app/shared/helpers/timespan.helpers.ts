export class TimespanHelpers {
    public static getTimespanString(value: number): string {
        if(typeof(value)==="undefined")
            return "00:00:00";
        let hours = Math.floor(value / 3600);
        let minutesAndSeconds = value % 3600;
        let minutes = Math.floor(minutesAndSeconds / 60);
        let seconds = Math.floor(minutesAndSeconds % 60);
        return `${this.toPaddedString(hours)}:${this.toPaddedString(minutes)}:${this.toPaddedString(seconds)}`;
    }

    public static getTimespanNumber(string: string): number {
        var resultNumber = 0;
        var arr = string.split(':');
        if(arr.length===3){
            resultNumber += parseInt(arr[0]) * 3600;
            resultNumber += parseInt(arr[1]) * 60;
            resultNumber += parseInt(arr[2]);
        }
        return resultNumber;
    }

    private static toPaddedString(value: number): string{
        return value < 10 ? `0${value}` : value.toString();
    }
}