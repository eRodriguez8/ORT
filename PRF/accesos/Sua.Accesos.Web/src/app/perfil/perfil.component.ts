import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppContextService } from '../services/appContext.service';
import { Perfil } from '../models/perfil';
import { Menu } from '../models/menu';
import { Region } from '../models/region';
import { Accion } from '../models/accion';
import { Usuario } from '../models/usuario';
import { Aplicacion } from '../models/aplicacion';
import { PerfilRequestVM } from '../models/perfilRequestVM';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { HttpManagerService } from '../services/manager.service';
import { IMultiSelectOption, IMultiSelectTexts, IMultiSelectSettings } from 'angular-2-dropdown-multiselect';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})

export class PerfilComponent implements OnInit {
  formulario: FormGroup;
  regiones: Region[];
  aplicaciones: Aplicacion[];
  legajo_descripcion: string;
  subMenu: Menu[];
  accion: string;
  titulo: string;
  perfiles: Perfil[];
  optionsModelAcciones: string[];
  acciones: IMultiSelectOption[];
  myTextsAcciones: IMultiSelectTexts = {
    checkAll: 'Todas',
    uncheckAll: 'Ninguna',
    searchEmptyResult: 'No existen acciones...',
    defaultTitle: 'Seleccione uno o mas items',
    allSelected: 'Todas las acciones'
};

mySettings: IMultiSelectSettings = {
  enableSearch: false,
  checkedStyle: 'fontawesome',
  buttonClasses: 'btn btn-default  margin-right-10',
  dynamicTitleMaxItems: 3,
  displayAllSelectedText: true,
  itemClasses: 'dropdownmulti',
};
    constructor(private route: ActivatedRoute, private context: AppContextService, private http: HttpManagerService,
        private router: Router) {
      this.accion = 'Alta de perfil';
      this.optionsModelAcciones = [];
      this.changeRoute();
    }

    ngOnInit() {
      this.http.get<Region[]>(`Regiones`)
        .subscribe(data => this.regiones = data
        );
      this.http.get<Aplicacion[]>(`Aplicaciones`)
        .subscribe(data => {
                    this.aplicaciones = data;
        });
      const submenus = this.context.getActualContext().menu.find(x => x.nombre === 'ACC_Perfil').subMenu;
      console.log(submenus);
      this.subMenu = submenus;
    }

    changeRoute() {
      this.route.params.subscribe(params => {
        this.accion = params['accion'];
        if (this.accion === 'alta') {
            this.formulario = new FormGroup({
              regionesOp: new FormControl('', [Validators.required]),
              aplicacionesOp:  new FormControl('', [Validators.required]),
              accionOp:   new FormControl('', [Validators.required]),
              legajo_descripcion: new FormControl('', [Validators.required]),
              perfilesOp :  new FormControl(''),
              legajoDestino :   new FormControl(''),
            });
          this.titulo = 'Alta de perfil';
          this.legajo_descripcion = 'Descripción';
        } else if (this.accion === 'baja') {
          this.formulario =  new FormGroup({
            regionesOp : new FormControl('', [Validators.required]),
            aplicacionesOp: new FormControl('', [Validators.required]),
            accionOp:  new FormControl(''),
            legajo_descripcion:  new FormControl(''),
            perfilesOp : new FormControl('', [Validators.required]),
            legajoDestino :  new FormControl('')
          });
          this.titulo = 'Baja de perfil';
          this.legajo_descripcion = 'Descripción';
        } else if (this.accion === 'asociar') {
          this.formulario = new FormGroup({
            regionesOp : new FormControl('', [Validators.required]),
            aplicacionesOp: new FormControl('', [Validators.required]),
            accionOp:  new FormControl(''),
            legajo_descripcion: new FormControl('', [Validators.required]),
            perfilesOp : new FormControl('', [Validators.required]),
            legajoDestino :  new FormControl('')
          });
          this.titulo = 'Asociar Perfil';
          this.legajo_descripcion = 'Legajo';
        } else {
          this.formulario = new FormGroup({
            regionesOp :  new FormControl(''),
            aplicacionesOp:  new FormControl(''),
            accionOp: new FormControl(''),
            legajo_descripcion: new FormControl('', [Validators.required]),
            perfilesOp : new FormControl(''),
            legajoDestino : new FormControl('', [Validators.required])
          });
          this.titulo = 'Copiar Perfil de Usuario';
          this.legajo_descripcion = 'Legajo origen';
        }
      });
    }

    onSelectApp($event: any) {
      switch (this.accion) {
        case 'alta': {
          const acciones = this.aplicaciones.find(x => x.id === $event).acciones;
          this.getAcciones(acciones);
        } break;
        case 'baja': {
          this.getPerfiles();
        } break;
      }
    }

    getAcciones(acciones: Accion[]): void {
        const valores: IMultiSelectOption[] = [];
        for (const acc of acciones) {
            valores.push({ id: acc.id, name: acc.descripcion });
        }
        this.acciones = valores;
    }

    getPerfiles(): void {
      const region = this.formulario.controls['regionesOp'].value;
      const app = this.formulario.controls['aplicacionesOp'].value;
      if (region !== '' && app !== '') {
      this.http.get<Perfil[]>(`Perfiles/xRegionApp/` + region + `/` + app)
        .subscribe(data => {
                    this.perfiles = data;
        }
        );
      }
    }

    onSubmit() {

      if (this.formulario.invalid) {
          return;
      }


      switch (this.accion) {
        case 'alta': {
          const _perfil: PerfilRequestVM = new PerfilRequestVM(
            0,
            this.formulario.controls['regionesOp'].value,
            this.formulario.controls['aplicacionesOp'].value,
            this.formulario.controls['accionOp'].value,
            this.formulario.controls['legajo_descripcion'].value
          );

          this.http.post<Perfil>(`Perfiles/`, _perfil)
            .subscribe(data => {
              const response = data;
              if (response !== undefined) {
                alert('Se genero el perfil ' + data.descripcion + ' correctamente.');
                this.router.navigateByUrl('/Perfil');
              }
            });

        }
        break;
        case 'baja': {
          const perfilId = this.formulario.controls['perfilesOp'].value;
          if (perfilId != null) {
            this.http.delete<string>(`Perfiles/`, perfilId)
            .subscribe(data => {
              const response = data;
              if (response !== undefined) {
                alert('Se elimino el perfil correctamente.');
                this.router.navigateByUrl('/Perfil');
              }
            });
          }
        } break;
        case 'asociar': {
          const legajoId = this.formulario.controls['legajo_descripcion'].value;
          const perfilId = this.formulario.controls['perfilesOp'].value;
          console.log(perfilId);
          console.log(legajoId);
          if (perfilId !== '' && legajoId !== '') {
            this.http.put<Usuario>(`Usuarios/AsociarPerfil/` + perfilId + `/` + legajoId, null)
            .subscribe(data => {
              const response = data;
              if (response !== undefined) {
                alert('Se asocio el perfil al usuario ' + data.legajo + ' correctamente.');
                this.router.navigateByUrl('/Perfil');
              }
            });
          }
        } break;
        default: {
          const legajoOrigen = this.formulario.controls['legajo_descripcion'].value;
          const legajoDestino = this.formulario.controls['legajoDestino'].value;
          if (legajoOrigen !== '' && legajoDestino !== '') {
            this.http.put<Usuario>(`Usuarios/Copiar/` + legajoOrigen + `/` + legajoDestino, null)
            .subscribe(data => {
              const response = data;
              if (response !== undefined) {
                alert('Se asocio el perfil al usuario ' + data.legajo + ' correctamente.');
                this.router.navigateByUrl('/Perfil');
              }
            });
          }
        } break;
      }
  }
}
