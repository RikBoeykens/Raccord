import { Image } from './image.model';
import { LinkedScene } from '../../scenes/model/linked-scene.model';
import { LinkedLocation } from '../../locations/model/linked-location.model';
import { LinkedCharacter } from '../../characters/model/linked-character.model';

export class FullImage extends Image{
    isPrimary: boolean;
    scenes: LinkedScene[];
    locations: LinkedLocation[];
    characters: LinkedCharacter[];

    constructor(obj?: {
                        id: number, 
                        title: string, 
                        description: string,
                        fileName: string,
                        projectId: number,
                        isPrimary: boolean,
                        scenes: LinkedScene[],
                        locations: LinkedLocation[],
                        characters: LinkedCharacter[],
                    }){
        super(obj);
        if(obj){
            this.isPrimary = obj.isPrimary;
            this.scenes = obj.scenes;
            this.locations = obj.locations;
            this.characters = obj.characters;
        }
    }
}