import { Component, Input } from '@angular/core';
import { WeatherInfo } from '../..';

@Component({
    selector: 'weather-info',
    templateUrl: 'weather-info.component.html'
})
export class WeatherInfoComponent {
    @Input() public weatherInfo: WeatherInfo;
}
