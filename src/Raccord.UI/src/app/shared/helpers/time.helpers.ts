export class TimeHelpers {
    public static getTimeString(time: Date){
        let timeString = "00:00";
        if(time){
            time = new Date(time);
            let h = time.getHours();
            let hourString = h.toString();
            if(h<10) hourString = `0${h}`;
            let m = time.getMinutes();
            let minuteString = m.toString();
            if(m<10) minuteString = `0${m}`;
            timeString = `${hourString}:${minuteString}`;
        }
        return timeString;
    }
    
    public static getTime(time: string): Date{
        let timeParts = time.split(":");
        let hours = parseInt(timeParts[0]);
        let minutes = parseInt(timeParts[1]);
        return new Date(0, 0, 0, hours, minutes);
    }
}