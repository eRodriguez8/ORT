export class Inventario {

  constructor(public nombre: string,
    public estado: string,
    public cc: number,
    public fechaCreacion: Date,
    public fechaFinalizacion: Date,
    public usuario: string,
    public id: number,
    public acciones: string[]) {
    }
}
