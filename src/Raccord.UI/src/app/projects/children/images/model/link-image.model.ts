import { SelectedEntity } from '../../../../shared/model/selected-entity.model';

export class LinkImage{
    imageId: number;
    selectedEntity: SelectedEntity;

    constructor(obj?: {
                        imageId: number, 
                        selectedEntity: SelectedEntity
                    }){
        if(obj){
            this.imageId = obj.imageId;
            this.selectedEntity = obj.selectedEntity;
        }
        else{
            this.selectedEntity = new SelectedEntity();
        }
    }
}