import { Component, Input } from '@angular/core';
import { AppContext } from '../models/appContext';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent {

    @Input()
    context: AppContext;

    constructor() { }
}
