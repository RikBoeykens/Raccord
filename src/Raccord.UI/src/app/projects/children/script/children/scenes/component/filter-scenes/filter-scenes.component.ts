import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { SceneFilterRequest, SelectedBreakdown } from '../../../../../..';
import { PageLengthHelpers } from '../../../../../../../shared/helpers/page-length.helpers';
import { SearchEntity } from '../../../../../../../shared/children/search';
import { EntityType } from '../../../../../../../shared';

@Component({
  selector: 'filter-scenes',
  templateUrl: 'filter-scenes.component.html'
})
export class FilterScenesComponent implements OnChanges {

  @Output() public filterScenes = new EventEmitter();
  @Input() public sceneFilter: SceneFilterRequest;
  @Input() public projectId: number;
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

  public getSceneIntroType() {
    return EntityType.sceneIntro;
  }

  public filterSceneIntros(entities: SearchEntity[]) {
    this.sceneFilter.sceneIntroIDs = entities.map((entity: SearchEntity) => entity.id as number);
    this.doFilter();
  }

  public getTimeOfDayType() {
    return EntityType.timeOfDay;
  }

  public filterTimeOfDays(entities: SearchEntity[]) {
    this.sceneFilter.timeOfDayIDs =
      entities.map((entity: SearchEntity) => entity.id as number);
    this.doFilter();
  }

  public getScriptLocationType() {
    return EntityType.scriptLocation;
  }

  public filterScriptLocations(entities: SearchEntity[]) {
    this.sceneFilter.scriptLocationIDs =
      entities.map((entity: SearchEntity) => entity.id as number);
    this.doFilter();
  }

  public getLocationType() {
    return EntityType.location;
  }

  public filterLocations(entities: SearchEntity[]) {
    this.sceneFilter.locationIDs =
      entities.map((entity: SearchEntity) => entity.id as number);
    this.doFilter();
  }

  public getCharacterType() {
    return EntityType.character;
  }

  public filterCharacters(entities: SearchEntity[]) {
    this.sceneFilter.characterIDs =
      entities.map((entity: SearchEntity) => entity.id as number);
    this.doFilter();
  }

  public getCastType() {
    return EntityType.castMember;
  }

  public filterCast(entities: SearchEntity[]) {
    this.sceneFilter.castMemberIDs =
      entities.map((entity: SearchEntity) => entity.id as number);
    this.doFilter();
  }

  private setPageLengthStrings() {
    this.minPageLengthString =
          PageLengthHelpers.getPageLengthString(this.sceneFilter.minPageLength);
    this.maxPageLengthString =
          PageLengthHelpers.getPageLengthString(this.sceneFilter.maxPageLength);
  }

  private setPageLengthNumbers() {
    if (this.minPageLengthString !== '') {
      this.sceneFilter.minPageLength =
        PageLengthHelpers.getPageLengthNumber(this.minPageLengthString);
    } else {
      this.sceneFilter.minPageLength = null;
    }

    if (this.maxPageLengthString !== '') {
      this.sceneFilter.maxPageLength =
        PageLengthHelpers.getPageLengthNumber(this.maxPageLengthString);
    } else {
      this.sceneFilter.maxPageLength = null;
    }
  }
}
