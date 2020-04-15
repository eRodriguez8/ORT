import { Perfil } from './perfil';
import { Aplicacion } from './aplicacion';

export class Usuario {

    public id: number;
    public apellido: string;
    public nombre: string;
    public fhAlta: Date;
    public legajo: string;
    public usuarioAD: string;
    public perfiles: Perfil[];
    public aplicaciones: Aplicacion[];

    constructor() {

    }
}
