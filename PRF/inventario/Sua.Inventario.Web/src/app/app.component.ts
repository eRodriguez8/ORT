import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { AppContext } from './models/appContext';
import { Router } from '@angular/router';

import { SecurityService } from './services/security.service';
import { Subscription } from 'rxjs';
import { AppContextService } from './services/appContext.service';
import { HttpManagerService } from './services/manager.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    providers: [SecurityService]
})
export class AppComponent implements OnInit {

    public appContext: AppContext;
    public busy: boolean;

    constructor(
        public securityService: SecurityService,
        public context: AppContextService,
        private router: Router) {
          this.busy = true;
    }

    ngOnInit() {
      this.getUsuario();
      this.getRegiones();
    }

    public getUsuario(): void {
      this.securityService.getAppContext()
          .subscribe(data => {
            this.busy = false;
            if (data !== undefined) {
              this.appContext = data;
              this.context.setActualContext(data);
            } else {
              this.router.navigateByUrl('Unauthorized');
            }
          });
    }

    public getRegiones(): void {
      this.securityService.getRegiones()
      .subscribe(data => {
        if (data !== undefined) {
          this.context.setRegiones(data);
        }
      });
    }
}
