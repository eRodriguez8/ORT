import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppContextService } from '../services/appContext.service';
import { Menu } from '../models/menu';
import { Usuario } from '../models/usuario';
import { UsuarioRequestVM } from '../models/usuarioRequestVM';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { HttpManagerService } from '../services/manager.service';
import { Subscription } from 'rxjs/internal/Subscription';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css'],
})

export class UsuarioComponent implements OnInit {
  formulario: FormGroup;
  public subMenu: Menu[];
  public accion: string;
  public titulo: string;
  public usuario: Usuario;
  public busy: Subscription;

  constructor(private route: ActivatedRoute, private context: AppContextService, private http: HttpManagerService,
    private router: Router) {
    this.accion = 'alta';
  }

  ngOnInit() {
    this.usuario = new Usuario();
    this.subMenu = this.context.getActualContext().menu[0].subMenu;
    this.chargeForm();
  }

  chargeForm() {
    this.route.params.subscribe(params => {
      this.accion = params['accion'];
      switch (this.accion) {
        case 'alta': {
          this.titulo = 'Alta de usuario';
          this.formulario = new FormGroup({
            usuarioAD: new FormControl('Cencosud\\'),
            legajo: new FormControl('', [Validators.required]),
            apellido: new FormControl('', [Validators.required]),
            nombre: new FormControl('', [Validators.required]),
            email: new FormControl('', [Validators.required])
          });
          break;
        }
        case 'baja': {
          this.titulo = 'Baja de usuario';
          this.formulario = new FormGroup({
            usuarioAD: new FormControl(),
            legajo: new FormControl('', [Validators.required]),
            apellido: new FormControl(),
            nombre: new FormControl()
          });
          break;
        }
        case 'modif': {
          this.titulo = 'Modificación de usuario';
          this.formulario = new FormGroup({
            usuarioAD: new FormControl('', [Validators.required]),
            legajo: new FormControl('', [Validators.required]),
            apellido: new FormControl('', [Validators.required]),
            nombre: new FormControl('', [Validators.required]),
            email: new FormControl('', [Validators.required])
          });
          break;
        }
        default: {
          this.titulo = 'Consulta de Usuario';
          this.formulario = new FormGroup({
            usuarioAD: new FormControl(),
            legajo: new FormControl(),
            apellido: new FormControl(),
            nombre: new FormControl(),
            email: new FormControl()
          });
          break;
        }
      }
    });
  }

  getUsuarioxLegajo(): void {
    if (this.accion === 'modif') {
      this.busy = this.http.getWithoutNotification<Usuario>(`Usuarios/xLegajo/` + this.formulario.controls['legajo'].value)
        .subscribe(data => {
          if (data != null) {
            this.usuario = data;
            this.formulario = new FormGroup({
              usuarioAD: new FormControl(data.usuarioAD, [Validators.required]),
              legajo: new FormControl(data.legajo, [Validators.required]),
              apellido: new FormControl(data.apellido, [Validators.required]),
              nombre: new FormControl(data.nombre, [Validators.required]),
              email: new FormControl(data.email, [Validators.required])
            });
          } else {
            alert('No se encontro el legajo solicitado');
          }
        });
      setTimeout(() => this.busy.unsubscribe(), 20000);
    }
  }

  onSubmit() {
    if (this.formulario.invalid) {
      return;
    }

    const legajo = this.formulario.controls['legajo'].value;

    switch (this.accion) {
      case 'alta': {
        const _usuario: UsuarioRequestVM = new UsuarioRequestVM();
        _usuario.apellido = this.formulario.controls['apellido'].value;
        _usuario.nombre = this.formulario.controls['nombre'].value;
        _usuario.legajo = legajo;
        _usuario.usuarioAD = this.formulario.controls['usuarioAD'].value;
        _usuario.email = this.formulario.controls['email'].value;

        this.http.post<Usuario>(`Usuarios`, _usuario)
          .subscribe(data => {
            const response = data;
            if (response !== undefined) {
              alert('Se generó el usuario con éxito');
              this.router.navigateByUrl('/Inicio');
            }
          }
          );
      }
        break;
      case 'baja': {
        this.http.delete<string>(`Usuarios/`, legajo)
          .subscribe(data => {
            const response = data;
            if (response !== undefined) {
              alert('El usuario ha sido eliminado con éxito');
              this.router.navigateByUrl('/Inicio');
            }
          });
      } break;
      case 'modif': {
        const ape = this.formulario.controls['apellido'].value;
        const nom = this.formulario.controls['nombre'].value;
        const user = this.formulario.controls['usuarioAD'].value;
        const mail = this.formulario.controls['email'].value;
        if (this.usuario.legajo !== legajo) {
          alert('Se modifico el legajo que se intentaba actualizar.');
          this.router.navigateByUrl('/Inicio');
        } else {
          if (user === this.usuario.usuarioAD && nom === this.usuario.nombre &&
            ape === this.usuario.apellido) {
            alert('No se modificó ningún dato.');
          } else {
            this.usuario.apellido = ape;
            this.usuario.nombre = nom;
            this.usuario.usuarioAD = user;
            this.usuario.email = mail;

            this.http.put<Usuario>(`Usuarios`, this.usuario)
              .subscribe(data => {
                const response = data;
                if (response !== undefined) {
                  alert('Se actualizo el legajo ' + data.legajo + ' correctamente.');
                  this.router.navigateByUrl('/Inicio');
                }
              });
          }
        }
      } break;
      default: {
        this.http.getWithoutNotification<Usuario>(`Usuarios/xLegajo/` + legajo)
          .pipe()
          .subscribe(
            result => {
              this.usuario = result;
            },
            error => {
              alert('No se encontró el legajo solicitado');
            }
          );
        break;
      }
    }
  }
}
