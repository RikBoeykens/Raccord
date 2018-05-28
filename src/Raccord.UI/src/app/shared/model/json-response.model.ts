export class JsonResponse {
    public ok: boolean;
    public message: string;
    public data: any;

    constructor(obj?: {
        ok: boolean,
        message: string,
        data: any
    }) {
        this.ok = obj.ok;
        this.message = obj.message;
        this.data = obj.data;
    }
}
