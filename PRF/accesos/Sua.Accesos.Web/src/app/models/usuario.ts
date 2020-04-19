import { Perfil } from './perfil';

export class Usuario {

  public id: number;
  public apellido: string;
  public nombre: string;
  public fhAlta: Date;
  public legajo: string;
  public usuarioAD: string;
  public perfiles: Perfil[];
  public email: string;

  constructor() {

  }
}
