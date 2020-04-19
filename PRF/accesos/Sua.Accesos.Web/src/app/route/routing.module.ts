import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { InicioComponent } from '../inicio/inicio.component';
import { UsuarioComponent } from '../usuario/usuario.component';
import { UnauthorizedComponent } from '../unauthorized/unauthorized.component';
import { PerfilComponent } from '../perfil/perfil.component';


const appRoutes: Routes = [
    { path: '', redirectTo: 'Inicio', pathMatch: 'full' },
    { path: 'Inicio', component: InicioComponent },
    { path: 'Usuario/:accion', component: UsuarioComponent },
    { path: 'Usuario', component: UsuarioComponent },
    { path: 'Perfil', component: PerfilComponent },
    { path: 'Perfil/:accion', component: PerfilComponent },
    { path: 'Unauthorized', component: UnauthorizedComponent },
    { path: '**', component: InicioComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}
