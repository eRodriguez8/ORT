export class ReporteDocumento {
  documento: string;
  ultimoLegajoAsignado: string;
  lineasTotales: number;
  lineasContadas: number;
  porcentaje: number;
  estado: number;
  primerLectura: Date;
  ultimaLectura: Date;
  tiempoOperacionMinutos: number;
  tiempoUltimaLecturaMinutos: number;
  promedioLineasXMinuto: number;
  promedioDescuadre: number;
  totalSinDescuadre: number;
  totalDiferenciaEtiqueta: number;
  totalDiferenciaBulto: number;
  totalConDescuadre: number;
  totalDescuadreArticulo: number;
  estadoString: string;
  constructor(
  ) {
  }
}
