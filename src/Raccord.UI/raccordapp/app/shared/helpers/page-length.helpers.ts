export class PageLengthHelpers {
    public static getPageLengthString(value: number): string {
        if(!value)
            return "";
        var resultString = "";
        var pages = Math.floor(value / 8);
        var eights = value % 8;
        if (pages >= 1) resultString = `${pages.toString()}`;
        if (pages >= 1 && eights >= 1) resultString += " ";
        if (pages < 1 || eights >= 1) resultString += `${eights.toString()}/8`;
        return resultString;
    }

    public static getPageLengthNumber(string: string): number {
        var resultNumber = 0;
        var newPageLength = string.split(' ').filter(function (el) { return el.length != 0 });;
        newPageLength.forEach(np => resultNumber += this.parseEights(np));
        return resultNumber;
    }

    private static parseEights(value: string): number {

        if (value == "") return

        if (value.indexOf("/") === -1) return parseInt(value) * 8;

        return parseInt(value.split("/")[0]) * 8 / parseInt(value.split("/")[1]);
    }
}