export class AppSettings {
    public static get API_ENDPOINT(): string { return 'http://raccord-api-poc.herokuapp.com/api'; }
    public static get API_ADMIN_ENDPOINT(): string { return `${this.API_ENDPOINT}/admin`; }
    public static get MAP_DEFAULT_ZOOM(): number { return 13; }
}