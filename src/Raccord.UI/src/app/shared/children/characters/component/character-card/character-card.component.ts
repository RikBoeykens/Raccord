import { Input, Component } from '@angular/core';
import { CharacterSummary } from '../../model/character-summary.model';

@Component({
  selector: 'character-card',
  templateUrl: 'character-card.component.html'
})
export class CharacterCardComponent {
  @Input() public character: CharacterSummary;
}
