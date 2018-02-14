export class SearchBreakdownItemRequest {
    public searchText: string;
    public typeID: number;
    public breakdownID: number;
    public excludeIDs: number[];

    constructor(obj?: {
                        searchText: string,
                        typeID: number,
                        breakdownID: number,
                        excludeIDs: number[]
                    }) {
        if (obj) {
            this.searchText = obj.searchText;
            this.typeID = obj.typeID;
            this.breakdownID = obj.breakdownID;
            this.excludeIDs = obj.excludeIDs;
        }
    }
}
