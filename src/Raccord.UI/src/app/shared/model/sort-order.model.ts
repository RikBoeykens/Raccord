export class SortOrder{
    parentId: number;
    sortIds: number[];

    constructor(obj?: {parentId: number, sortIds: number[]}){
        if(obj){
            this.parentId = obj.parentId;
            this.sortIds = obj.sortIds;
        }
    }
}