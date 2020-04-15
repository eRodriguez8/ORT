import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from '../inicio/inicio.component';
import { UnauthorizedComponent } from '../unauthorized/unauthorized.component';
import { ImportarComponent } from '../importar/importar.component';
import { EstadoComponent } from '../estado/estado.component';
import { ConsultarComponent } from '../consultar/consultar.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'Inicio', pathMatch: 'full' },
    { path: 'Inicio', component: InicioComponent },
    { path: 'Consulta', component: ConsultarComponent },
    { path: 'Importar', component: ImportarComponent },
    { path: 'Estado', component: EstadoComponent },
    { path: 'Unauthorized', component: UnauthorizedComponent },
    { path: '**', component: InicioComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}
