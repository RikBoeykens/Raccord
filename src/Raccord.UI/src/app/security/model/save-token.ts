export class SaveToken {
    public accessToken: string;
    public expiryDate: number;
    public refreshToken: string;

    constructor(obj?: {
        accessToken: string,
        expiryDate: number,
        refreshToken: string
    }) {
        if (obj) {
            this.accessToken = obj.accessToken;
            this.expiryDate = obj.expiryDate;
            this.refreshToken = obj.refreshToken;
        }
    }
}
