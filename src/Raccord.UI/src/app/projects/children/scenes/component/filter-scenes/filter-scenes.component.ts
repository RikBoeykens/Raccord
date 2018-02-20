import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { SceneFilterRequest } from '../../model/scene-filter-request.model';
import { PageLengthHelpers } from '../../../../../shared/helpers/page-length.helpers';
import { Character } from '../../../characters/model/character.model';
import { IntExt } from '../../../scene-properties/model/int-ext.model';
import { DayNight } from '../../../scene-properties/model/day-night.model';
import { ScriptLocation } from '../../../script-locations/model/script-location.model';
import { BreakdownItem } from
  '../../../breakdowns/children/breakdown-items/model/breakdown-item.model';
import { Location } from '../../../locations/locations/model/location.model';
import { SelectedBreakdown } from '../../../breakdowns/model/selected-breakdown.model';
import { EntityType } from '../../../../../shared/enums/entity-type.enum';
import { SearchEntity } from '../../../../../search/model/search-entity.model';

@Component({
  selector: 'filter-scenes',
  templateUrl: 'filter-scenes.component.html'
})
export class FilterScenesComponent implements OnChanges {

  @Output() public filterScenes = new EventEmitter();
  @Input() public sceneFilter: SceneFilterRequest;
  @Input() public projectID: number;
  @Input() public breakdown: SelectedBreakdown;
  public minPageLengthString: string;
  public maxPageLengthString: string;

  public doFilter() {
    this.filterScenes.emit();
  }

  public ngOnChanges() {
    this.setPageLengthStrings();
  }

  public filterPagelengths() {
    this.setPageLengthNumbers();
    this.doFilter();
  }

  public filterIntExts(intExts: IntExt[]) {
    this.sceneFilter.intExtIDs = intExts.map((intExt: IntExt) => intExt.id);
    this.doFilter();
  }

  public filterScriptLocations(scriptLocations: ScriptLocation[]) {
    this.sceneFilter.scriptLocationIDs =
      scriptLocations.map((scriptLocation: ScriptLocation) => scriptLocation.id);
    this.doFilter();
  }

  public filterDayNights(dayNights: DayNight[]) {
    this.sceneFilter.dayNightIDs = dayNights.map((dayNight: DayNight) => dayNight.id);
    this.doFilter();
  }

  public filterLocations(characters: Location[]) {
    this.sceneFilter.locationIDs = characters.map((location: Location) => location.id);
    this.doFilter();
  }

  public filterCharacters(characters: Character[]) {
    this.sceneFilter.characterIDs = characters.map((character: Character) => character.id);
    this.doFilter();
  }

  public getCastMemberType() {
    return EntityType.castMember;
  }

  public filterCastMembers(entities: SearchEntity[]) {
    // this.sceneFilter.characterIDs = characters.map((character: Character) => character.id);
    console.log(entities);
    this.doFilter();
  }

  public filterBreakdowns(items: BreakdownItem[]) {
    this.sceneFilter.breakdownItemIDs = items.map((item: BreakdownItem) => item.id);
    this.doFilter();
  }

  private setPageLengthStrings() {
    this.minPageLengthString =
          PageLengthHelpers.getPageLengthString(this.sceneFilter.minPageLength);
    this.maxPageLengthString =
          PageLengthHelpers.getPageLengthString(this.sceneFilter.maxPageLength);
  }

  private setPageLengthNumbers() {
    console.log(this.minPageLengthString);
    if (this.minPageLengthString !== '') {
      this.sceneFilter.minPageLength =
        PageLengthHelpers.getPageLengthNumber(this.minPageLengthString);
    }

    if (this.maxPageLengthString !== '') {
      this.sceneFilter.maxPageLength =
        PageLengthHelpers.getPageLengthNumber(this.maxPageLengthString);
    }
  }
}
