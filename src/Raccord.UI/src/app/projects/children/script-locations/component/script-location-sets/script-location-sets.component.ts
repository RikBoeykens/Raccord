import { Component, Input, OnInit } from '@angular/core';
import { LocationSetLocation } from '../../../locations';

@Component({
    selector: 'screenplay-location-sets',
    templateUrl: 'script-location-sets.component.html'
})
export class ScriptLocationSetsComponent implements OnInit{

    @Input() projectId: number;
    @Input() scriptLocationId: number;
    @Input() locationSets: LocationSetLocation[];

    constructor(
    ){
    }

    ngOnInit(){
    }
}