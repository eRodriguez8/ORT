import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { AppContext } from './models/appContext';
import { Router } from '@angular/router';

import { SecurityService } from './services/security.service';
import { Subscription } from 'rxjs';
import { AppContextService } from './services/appContext.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    providers: [SecurityService]
})
export class AppComponent implements OnInit {

    public appContext: AppContext;
    public busy: Subscription;

    constructor(
        public securityService: SecurityService,
        public context: AppContextService,
        private router: Router) {
    }

    ngOnInit() {
      this.getUsuario();
    }

    public getUsuario(): void {
      this.securityService.getAppContext()
          .subscribe(data => {
            if (data !== undefined) {
              this.appContext = data;
              this.context.setActualContext(data);
            } else {
              this.router.navigateByUrl('Unauthorized');
            }
          });
      //setTimeout(() => this.busy.unsubscribe(), 20000);
    }

  //   public getUsuario(): void {
  //     this.appContext = this.securityService.getAppContext();
  //     this.context.setActualContext(this.appContext);
  // }
}
