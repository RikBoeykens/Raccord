export class PageLengthHelpers {
    public static getPageLengthString(value: number): string {
        if (typeof(value) === 'undefined') {
            return '';
        }
        let resultString = '';
        const pages = Math.floor(value / 8);
        const eights = value % 8;
        if (pages >= 1) {
            resultString = `${pages.toString()}`;
        }
        if (pages >= 1 && eights >= 1) {
            resultString += ' ';
        }
        if (pages < 1 || eights >= 1) {
            resultString += `${eights.toString()}/8`;
        }
        return resultString;
    }

    public static getPageLengthNumber(stringValue: string): number {
        let resultNumber = 0;
        const newPageLength = stringValue.split(' ').filter((el) => el.length !== 0 );
        newPageLength.forEach((np) => resultNumber += this.parseEights(np));
        return resultNumber;
    }

    private static parseEights(value: string): number {

        if (value === '') {
            return;
        }
        if (value.indexOf('/') === -1) {
            return parseInt(value, 10) * 8;
        }
        return parseInt(value.split('/')[0], 10) * 8 /
            parseInt(value.split('/')[1], 10);
    }
}
