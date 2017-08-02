export class AppSettings {
    public static get API_ENDPOINT(): string { return 'http://localhost:5001/api'; }
    public static get API_ADMIN_ENDPOINT(): string { return `${this.API_ENDPOINT}/admin`; }
}