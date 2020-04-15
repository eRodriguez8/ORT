import { EstadoDocumento } from './estadoDocumento';

export class Documento {

  constructor(
    public id: number,
    public documento: string,
    public estado: EstadoDocumento,
    public legajoAsignado: string,
    public lTotales: number,
    public lContadas: number,
    public porcentaje: number,
    public pLectura: Date,
    public uLectura: Date,
    public tOperacionMin: number,
    public tUltimaLectura: number,
    public promLineasxMin: number,
    public promLineasDescuadre: number,
    public fase: string,
    public documentoPadre: Documento,
    public impactadoSega: boolean) {
    }
}
