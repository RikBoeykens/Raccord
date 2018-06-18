import { Component, Input } from '@angular/core';
import { Character } from '../..';

@Component({
  selector: 'character-summary',
  templateUrl: 'character-summary.component.html'
})
export class CharacterSummaryComponent {
  @Input() public character: Character;
}
