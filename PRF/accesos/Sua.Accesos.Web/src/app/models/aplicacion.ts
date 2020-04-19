import { Accion } from './accion';

export class Aplicacion {
  constructor(  public id: string,
    public descripcion: string,
    public accesos: string,
    public estado: string,
    public acciones: Accion[]) {
  }

}
