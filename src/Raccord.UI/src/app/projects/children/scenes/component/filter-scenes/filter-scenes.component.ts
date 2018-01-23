import { Component, Input, Output, EventEmitter, OnChanges } from "@angular/core";
import { SceneFilterRequest } from "../../model/scene-filter-request.model";
import { PageLengthHelpers } from "../../../../../shared/helpers/page-length.helpers";
import { Character } from "../../../characters/model/character.model";
import { IntExt } from "../../../scene-properties/model/int-ext.model";

@Component({
  selector: 'filter-scenes',
  templateUrl: 'filter-scenes.component.html'
})
export class FilterScenesComponent implements OnChanges {

  @Output() public filterScenes = new EventEmitter();
  @Input() public sceneFilter: SceneFilterRequest;
  @Input() public projectID: number;
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

  public filterCharacters(characters: Character[]) {
    this.sceneFilter.characterIDs = characters.map((character: Character) => character.id);
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