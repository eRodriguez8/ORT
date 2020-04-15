import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation';
import { ImportarComponent } from './importar/importar.component';
import { HttpManagerService } from './services/manager.service';

import { AppRoutingModule } from './routes/routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { InicioComponent } from './inicio/inicio.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { MenuComponent } from './menu/menu.component';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HelperProvider } from './providers/helper.provider';
import { AppContextService } from './services/appContext.service';
import { NgBusyModule } from 'ng-busy';
import { ToastrModule } from 'ngx-toastr';
import { MultiselectDropdownModule } from 'angular-2-dropdown-multiselect';
import { HandleErrorComponent } from './handle-error/handle-error.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UiSwitchModule } from 'ngx-ui-switch';
import { reduce } from 'rxjs/operators';
import { EstadoComponent } from './estado/estado.component';
import { ConsultarComponent } from './consultar/consultar.component';
import { FiltrosConsultarComponent } from './consultar/filtrosConsultar/filtrosConsultar.component';
import { DataTablesModule } from 'angular-datatables';
import { Daterangepicker } from 'ng2-daterangepicker';
import { DocumentoComponent } from './consultar/documento/documento.component';
import { FiltrosDocumentosComponent } from './consultar/documento/filtrosDocumentos/filtrosDocumentos.component';
import { PosicionesComponent } from './consultar/documento/posicion/posiciones.component';
import { AsignarComponent } from './consultar/documento/asignar/asignar.component';
import { CancelarComponent } from './consultar/documento/cancelar/cancelar.component';
import { DetalleComponent } from './estado/detalle/detalle.component';
import { FiltroEstadoComponent } from './estado/filtro-estado/filtro-estado.component';


@NgModule({
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        UiSwitchModule,
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
        NgBootstrapFormValidationModule,
        DataTablesModule.forRoot(),
        Daterangepicker
    ],
    declarations: [AppComponent, HeaderComponent,
        InicioComponent, UnauthorizedComponent,
        MenuComponent, HandleErrorComponent, ImportarComponent, EstadoComponent, ConsultarComponent,
        FiltrosConsultarComponent, DocumentoComponent, FiltrosDocumentosComponent,
        PosicionesComponent, AsignarComponent, DetalleComponent, FiltroEstadoComponent, CancelarComponent],
    bootstrap: [AppComponent],
    providers: [
        HttpManagerService,
        HelperProvider,
        AppContextService,
        NgbActiveModal,
        { provide: LocationStrategy, useClass: HashLocationStrategy }
    ],
    entryComponents: [HandleErrorComponent, AsignarComponent, CancelarComponent]
})
export class AppModule { }
