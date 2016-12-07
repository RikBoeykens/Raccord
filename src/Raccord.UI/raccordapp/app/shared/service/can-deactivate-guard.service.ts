import { Injectable }    from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { CanComponentDeactivate } from '../interface/can-component-deactivate.interface';

@Injectable()
export class CanDeactivateGuard implements CanDeactivate<CanComponentDeactivate> {

  canDeactivate(component: CanComponentDeactivate) {
    return component.canDeactivate ? component.canDeactivate() : true;
  }
  
}