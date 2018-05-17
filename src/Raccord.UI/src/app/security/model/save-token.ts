export class SaveToken {
    public accessToken: string;
    public expiryDate: Date;
    public refreshToken: string;

    constructor(obj?: {
        accessToken: string,
        expiryDate: Date,
        refreshToken: string
    }) {
        if (obj) {
            this.accessToken = obj.accessToken;
            this.expiryDate = obj.expiryDate;
            this.refreshToken = obj.refreshToken;
        }
    }
}
