import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation';

import { HttpManagerService } from './services/manager.service';

import { AppRoutingModule } from './route/routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { InicioComponent } from './inicio/inicio.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { PerfilComponent } from './perfil/perfil.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { MenuComponent } from './menu/menu.component';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HelperProvider } from './providers/helper.provider';
import { AppContextService } from './services/appContext.service';
import { NgBusyModule } from 'ng-busy';
import { ToastrModule } from 'ngx-toastr';
import { MultiselectDropdownModule } from 'angular-2-dropdown-multiselect';
import { HandleErrorComponent } from './handle-error/handle-error.component';


@NgModule({
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,
        NgBusyModule,
        ToastrModule.forRoot({
            positionClass: 'toast-bottom-right'
        }),
        HttpClientModule,
        NgMultiSelectDropDownModule.forRoot(),
        NgbModule.forRoot(),
        MultiselectDropdownModule,
        NgBootstrapFormValidationModule.forRoot(),
        NgBootstrapFormValidationModule
    ],
    declarations: [AppComponent, HeaderComponent,
        InicioComponent, UnauthorizedComponent,
        MenuComponent, HandleErrorComponent,
        UsuarioComponent, PerfilComponent],
    bootstrap: [AppComponent],
    providers: [
        HttpManagerService,
        HelperProvider,
        AppContextService,
        NgbActiveModal,
        { provide: LocationStrategy, useClass: HashLocationStrategy }
    ],
    entryComponents: [HandleErrorComponent]
})
export class AppModule { }
