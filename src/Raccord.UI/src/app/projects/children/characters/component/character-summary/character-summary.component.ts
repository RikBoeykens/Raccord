import { Component, Input } from "@angular/core";
import { Character } from "../../model/character.model";

@Component({
  selector: 'character-summary',
  templateUrl: 'character-summary.component.html'
})
export class CharacterSummaryComponent{

  @Input() character: Character;

  constructor(
  ){
  }
}