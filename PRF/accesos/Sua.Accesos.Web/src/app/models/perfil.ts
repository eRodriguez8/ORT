import { Region } from './region';
import { Aplicacion } from './aplicacion';

export class Perfil {

    public estado: string;
    public region: Region;
    public descripcion: string;
    public id: number;
    public idAplicacion: string;
    public idRegion: number;
    public aplicacion: Aplicacion;


    constructor() {

    }

}
