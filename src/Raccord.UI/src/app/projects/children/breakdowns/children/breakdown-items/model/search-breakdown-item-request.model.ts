export class SearchBreakdownItemRequest {
    public searchText: string;
    public typeID: number;
    public excludeIDs: number[];

    constructor(obj?: {
                        searchText: string,
                        typeID: number,
                        excludeIDs: number[]
                    }) {
        if (obj) {
            this.searchText = obj.searchText;
            this.typeID = obj.typeID;
            this.excludeIDs = obj.excludeIDs;
        }
    }
}