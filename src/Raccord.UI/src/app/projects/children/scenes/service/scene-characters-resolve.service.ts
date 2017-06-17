import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CharacterSceneHttpService } from './character-scene-http.service';
import { LinkedCharacter } from '../../characters/model/linked-character.model';
@Injectable()
export class SceneCharactersResolve implements Resolve<LinkedCharacter[]> {

  constructor(
    private characterSceneHttpService: CharacterSceneHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let sceneId = route.params['sceneId'];
        return this.characterSceneHttpService.getCharacters(sceneId).then(characters => {
            if(characters){
                return characters;
            }else{
                let projectId = route.params['projectId'];
                this.router.navigate(['/projects', projectId]);
                return false;
            }
        });
    }
}