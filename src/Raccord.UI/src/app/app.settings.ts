export class AppSettings {
    public static get API_ENDPOINT(): string { return 'http://localhost:5001/api'; }
    public static get API_ADMIN_ENDPOINT(): string { return `${this.API_ENDPOINT}/admin`; }
    public static get API_PROJECT_ENDPOINT(): string { return `${this.API_ENDPOINT}/projects`; }
    public static get MAP_DEFAULT_ZOOM(): number { return 13; }
    public static get MAP_DEFAULT_PAGE_SIZE(): number { return 10; }
}