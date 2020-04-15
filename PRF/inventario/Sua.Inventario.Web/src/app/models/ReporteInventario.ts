export class ReporteInventario {
  totalLineas: number;
  totalContadas: number;
  totalPorcentaje: number;
  totalConDescuadre: number;
  totalDescuadreArticulo: number;
  totalSinDescuadre: number;
  totalDiferenciaEtiqueta: number;
  totalDiferenciaBulto: number;
  totalDescuadresGeneral: number;
  constructor(
  ) {
    this.totalLineas = 0;
    this.totalContadas = 0;
    this.totalPorcentaje = 0;
    this.totalConDescuadre = 0;
    this.totalDescuadreArticulo = 0;
    this.totalSinDescuadre = 0;
    this.totalDiferenciaEtiqueta = 0;
    this.totalDiferenciaBulto = 0;
    this.totalDescuadresGeneral = 0;
  }
}
