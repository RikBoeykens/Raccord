import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { Breakdown } from '../../model/breakdown.model';

@Component({
    selector: 'edit-breakdown',
    templateUrl: 'edit-breakdown.component.html'
})
export class EditBreakdownComponent {

    @Output() public submitBreakdown = new EventEmitter();
    @Input() public breakdown: Breakdown;

    public doSubmit() {
        this.submitBreakdown.emit();
    }
}
