import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { SecurityService } from './services/security.service';
import { SecurityServiceMock } from './mocks/security.service.mock';
import { MenuComponent } from './menu/menu.component';
import { HeaderComponent } from './header/header.component';
import { InicioComponent } from './inicio/inicio.component';
import { RouterModule, Routes } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { HttpManagerService } from './services/manager.service';
import { HttManagerServiceMock } from './mocks/httpManager.service.mock';
import { AppContextService } from './services/appContext.service';
import { AppContextServiceMock } from './mocks/appContext.service.mock';

describe('AppComponent', () => {
  const appRoutes: Routes = [
    { path: '', redirectTo: 'Inicio', pathMatch: 'full' },
    { path: 'Inicio', component: InicioComponent }
];

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        MenuComponent,
        HeaderComponent,
        InicioComponent
      ],
      imports: [ RouterModule.forRoot(appRoutes)],
      providers: [
        {provide: SecurityService, useClass: SecurityServiceMock},
        {provide: HttpManagerService, useClass: HttManagerServiceMock },
        {provide: AppContextService, useClass: AppContextServiceMock },
        { provide: APP_BASE_HREF, useValue: '/' }
      ]
    }).compileComponents();
  }));

  it('should create the app', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));
});
