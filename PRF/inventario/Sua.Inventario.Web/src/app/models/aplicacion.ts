import { Accion } from './accion';

export class Aplicacion {
  constructor(
    public id: string,
    public descripcion: string,
    public Inventario: string,
    public estado: string,
    public acciones: Accion[]) {
  }

}
