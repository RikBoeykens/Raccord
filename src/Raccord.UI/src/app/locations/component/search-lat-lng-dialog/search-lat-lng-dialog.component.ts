import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { AgmMap } from '@agm/core';
import { GeocodingHttpService } from '../../service/geocoding-http.service';
import { GeocodingResponse } from '../../model/geocoding-response.model';
import { LoadingWrapperService } from '../../../shared/service/loading-wrapper.service';
import { Address, LatLng } from '../../../shared';
import { AppSettings } from '../../../app.settings';

@Component({
    selector: 'search-lat-lng-dialog',
    templateUrl: 'search-lat-lng-dialog.component.html',
})

export class SearchLatLngDialogComponent implements OnInit {
    public static width: string = '600px';
    public zoom: number = AppSettings.MAP_DEFAULT_ZOOM;

    public searchText: string;
    public results: GeocodingResponse[] = [];
    public performedSearch: boolean = false;
    public loading: Boolean = false;
    public viewLatLng: LatLng = new LatLng();
    public selectedLatLng: LatLng = new LatLng();

    constructor(
        private _dialogRef: MdDialogRef<SearchLatLngDialogComponent>,
        private _geocodingHttpService: GeocodingHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        @Inject(MD_DIALOG_DATA) private data: {
            searchText: string,
            latLng?: LatLng
        }
    ) {
        this.searchText = data.searchText;
        if (data.latLng) {
            this.setLatLng(data.latLng);
        }
    }

    public ngOnInit() {
        this.getLatLng();
    }

    public getLatLng() {
        if (this.searchText && this.searchText !== '') {
            this.loading = true;
            this._geocodingHttpService.getLatLng(this.searchText)
            .then((data: GeocodingResponse[]) => {
                this.performedSearch = true;
                this.results = data;
                if (data && !this.selectedLatLng) {
                    this.setLatLng(data[0].latLng);
                }
                this.loading = false;
            });
        }
    }

    public setLatLng(latLng) {
        this.selectedLatLng = latLng;
        this.viewLatLng = latLng;
    }

    public markerDragEnd(m: any, $event: any) {
      this.selectedLatLng = new LatLng({
          latitude: $event.coords.lat,
          longitude: $event.coords.lng,
          hasLatLng: true
      });
    }

    public selectLatLng() {
        this.viewLatLng = this.selectedLatLng;
    }

    public submit() {
        this._dialogRef.close(this.selectedLatLng);
    }
}
