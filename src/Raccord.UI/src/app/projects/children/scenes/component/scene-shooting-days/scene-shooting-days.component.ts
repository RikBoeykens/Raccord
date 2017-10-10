import { Component, Input } from '@angular/core';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ShootingDayInfo } from '../../../shooting-days/model/shooting-day-info';
import { ShootingDayType } from '../../../../../shared/enums/shooting-day-type.enum';

@Component({
    selector: 'scene-shooting-days',
    templateUrl: 'scene-shooting-days.component.html'
})
export class SceneShootingDaysComponent{

    @Input() projectId: number;
    @Input() sceneId: number;
    @Input() shootingDays: ShootingDayInfo[];


    constructor(
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
    ){
    }

    filterShootingDays(type: ShootingDayType){
        return this.shootingDays.filter(shootingDay => shootingDay.type === type);
    }

    getScheduledAvailable(){
        return this.getScheduledShootingDays().length;
    }

    getScheduledShootingDays(){
        return this.filterShootingDays(ShootingDayType.scheduled);
    }
    
    getScheduledNotCallsheetAvailable(){
        return this.getScheduledNotCallsheetShootingDays().length;
    }

    getScheduledNotCallsheetShootingDays(){
        return this.filterShootingDays(ShootingDayType.scheduledNotOnCallsheet);
    }
    
    getCallsheetAvailable(){
        return this.getCallsheetShootingDays().length;
    }

    getCallsheetShootingDays(){
        return this.filterShootingDays(ShootingDayType.callsheet);
    }
    
    getCallsheetNotShotAvailable(){
        return this.getCallsheetNotShotShootingDays().length;
    }

    getCallsheetNotShotShootingDays(){
        return this.filterShootingDays(ShootingDayType.callsheetNotShot);
    }
    
    getShotAvailable(){
        return this.getShotShootingDays().length;
    }

    getShotShootingDays(){
        return this.filterShootingDays(ShootingDayType.shot);
    }
}