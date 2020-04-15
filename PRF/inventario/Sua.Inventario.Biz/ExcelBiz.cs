using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Interfaces;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Corp.Cencosud.Supermercados.Sua_Inventario.Dal;
using System.IO;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz
{
    public class ExcelBiz: BaseBiz, IExcelBiz
    {
        protected IUOW_CDsDB _unitOfWorkOfCDsDB { get; }

        public ExcelBiz(IUOW_CDsDB unitOfWorkOfCDsDB) : base(unitOfWorkOfCDsDB)
        {
            _unitOfWorkOfCDsDB = unitOfWorkOfCDsDB;
        }

        private Cell ArmarCelda(string value, UInt32Value formato)
        {
            var cell = new Cell();
            cell.DataType = CellValues.String;
            cell.CellValue = new CellValue(value);
            cell.StyleIndex = !string.IsNullOrEmpty(value) ? formato : (UInt32Value)3U;

            return cell;
        }

        private Stylesheet EstilosExcel()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(
                        new Italic(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "FFFFFF" } },
                        new FontName() { Val = "Calibri" })
                ),
                new Fills(
                    new Fill(new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }),
                    new Fill(
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "C4BD97" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "008000" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "000000" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "92D050" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFF00" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FF0000" } }
                        )
                        { PatternType = PatternValues.Solid })
                ),
                new Borders(
                    new Border(
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                    new Border(
                        new LeftBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new RightBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new TopBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new BottomBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FontId = 3, FillId = 1, BorderId = 0 },
                    new CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFont = true }, //1U
                    new CellFormat() { FontId = 3, FillId = 3, BorderId = 0, ApplyFont = true }, //2U
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0, ApplyFont = true }, //3U
                    new CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },
                    new CellFormat(
                        new Alignment()
                        {
                            Horizontal = HorizontalAlignmentValues.Center
                            ,
                            Vertical = VerticalAlignmentValues.Center
                        }
                    )
                    { FontId = 0, FillId = 0, BorderId = 0, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true },
                    new CellFormat() { FontId = 0, FillId = 5, BorderId = 0, ApplyFont = true },//7U
                    new CellFormat() { FontId = 0, FillId = 6, BorderId = 0, ApplyFont = true },//8
                    new CellFormat() { FontId = 0, FillId = 7, BorderId = 0, ApplyFont = true } //9
                )
            );
        }

        public byte[] DescargarEstadoActual(int idInventario)
        {
            return ArmarExcel(idInventario, "EstadoActual");
        }

        public byte[] DescargarPosicionesExcel(int idDocumento)
        {
            return ArmarExcel(idDocumento, "Posiciones");
        }

        public byte[] DescargarPosicionexInventario(int idInventario)
        {
            return ArmarExcel(idInventario, "PosicionesxInvetario");
        }

        private byte[] ArmarExcel(int id, string tipoReporte)
        {
            using (MemoryStream mem = new MemoryStream())
            {
                var workbook = SpreadsheetDocument.Create(mem, SpreadsheetDocumentType.Workbook);

                #region Armado de archivo Excel

                workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new Sheets();

                var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                sheetPart.Worksheet = new Worksheet(sheetData);

                var sheets = workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();

                var stylesPart = workbook.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = EstilosExcel();
                stylesPart.Stylesheet.Save();

                #endregion

                #region Nueva Hoja

                var sheet = new Sheet()
                {
                    Id = workbook.WorkbookPart.GetIdOfPart(sheetPart),
                    SheetId = 1,
                    Name = tipoReporte == "EstadoActual" ? "EstadoActual" : "Posiciones"
                };

                sheets.Append(sheet);

                #endregion

                switch (tipoReporte)
                {
                    case "PosicionesxInvetario":
                        sheetData = cargarExcelPosxInv(sheetData, id);
                        break;
                    case "Posiciones":
                        sheetData = cargarExcelPosiciones(sheetData, id);
                        break;
                    case "EstadoActual":
                        sheetData = cargarExcelEstadoActual(sheetData, id);
                        break;
                }
                

                workbook.WorkbookPart.Workbook.Save();
                workbook.Close();

                return mem.ToArray();
            }
        }

        private SheetData cargarExcelPosxInv(SheetData sheetData, int id)
        {
            sheetData.AppendChild(new Row(
                ArmarCelda("Sector", 2U),
                ArmarCelda("Pasillo", 2U),
                ArmarCelda("Columna", 2U),
                ArmarCelda("Nivel", 2U),
                ArmarCelda("Compart", 2U),
                ArmarCelda("Etiqueta", 2U),
                ArmarCelda("Ean13", 2U),
                ArmarCelda("Desc.", 2U),
                ArmarCelda("Proveedor", 2U),
                ArmarCelda("Id OC", 2U),
                ArmarCelda("Fec. Recep", 2U),
                ArmarCelda("Vencimiento", 2U),
                ArmarCelda("Vida Util", 2U),
                ArmarCelda("Dias a Vencer", 2U),
                ArmarCelda("Cxh", 2U),
                ArmarCelda("Hxp", 2U),
                ArmarCelda("Uxb", 2U),
                ArmarCelda("Uxpack", 2U),
                ArmarCelda("Bultos", 2U),
                ArmarCelda("Packs", 2U),
                ArmarCelda("Unidades", 2U),
                ArmarCelda("Recepcionista", 2U),
                ArmarCelda("Almacenador", 2U),
                ArmarCelda("Estado Calidad", 2U),
                ArmarCelda("Cara", 2U),
                ArmarCelda("Metodo", 2U),
                ArmarCelda("Usuario", 2U),
                ArmarCelda("Digito", 2U),
                ArmarCelda("Bultos Inv", 2U),
                ArmarCelda("Fecha Act", 2U),
                ArmarCelda("Usuario Inv", 2U),
                ArmarCelda("Tipo Inv", 2U),
                ArmarCelda("Hxp Inv", 2U),
                ArmarCelda("Cajas Sueltas", 2U),
                ArmarCelda("Estado", 2U),
                ArmarCelda("Obs", 2U),
                ArmarCelda("Dun14", 2U),
                ArmarCelda("Codigo Art", 2U),
                ArmarCelda("Tipo Lectura", 2U),
                ArmarCelda("Doc Asociado", 2U),
                ArmarCelda("Documento", 2U),
                ArmarCelda("Fase", 2U)));


            #region ObtenerDatos

            Entities.Inventario Inventario;
            try
            {
                Inventario = _unitOfWorkOfCDsDB.INV_dInventarioRepository.Get(x => x.id == id).FirstOrDefault()
                    .ToModel();
            }
            catch (Exception)
            {
                Inventario = new Entities.Inventario();
                Inventario.documento = new List<Documento>();
            }

            #endregion

            foreach (var docu in Inventario.documento)
            {
                foreach (var posicion in docu.posiciones)
                {
                    sheetData.AppendChild(new Row(
                        ArmarCelda(posicion.sector, 3U),
                        ArmarCelda(posicion.pasillo, 3U),
                        ArmarCelda(posicion.columna, 3U),
                        ArmarCelda(posicion.nivel, 3U),
                        ArmarCelda(posicion.compart, 3U),
                        ArmarCelda(posicion.etiqueta, 3U),
                        ArmarCelda(posicion.ean13, 3U),
                        ArmarCelda(posicion.descripcion, 3U),
                        ArmarCelda(posicion.proveedor, 3U),
                        ArmarCelda(posicion.id_orden_compra, 3U),
                        ArmarCelda(posicion.fecha_hora_recepcion, 3U),
                        ArmarCelda(posicion.vencimiento, 3U),
                        ArmarCelda(posicion.vidautil, 3U),
                        ArmarCelda(posicion.diasvencer, 3U),
                        ArmarCelda(posicion.cxh, 3U),
                        ArmarCelda(posicion.hxp, 3U),
                        ArmarCelda(posicion.uxb, 3U),
                        ArmarCelda(posicion.uxpack, 3U),
                        ArmarCelda(posicion.bultos, 3U),
                        ArmarCelda(posicion.packs, 3U),
                        ArmarCelda(posicion.unidades, 3U),
                        ArmarCelda(posicion.recepcionista, 3U),
                        ArmarCelda(posicion.almacenador, 3U),
                        ArmarCelda(posicion.estadocalidad, 3U),
                        ArmarCelda(posicion.cara, 3U),
                        ArmarCelda(posicion.metodo, 3U),
                        ArmarCelda(posicion.usuario, 3U),
                        ArmarCelda(posicion.digito, 3U),
                        ArmarCelda(posicion.bultosinv.HasValue == true ? posicion.bultosinv.Value.ToString() : string.Empty, 3U),
                        ArmarCelda(posicion.fechaact, 3U),
                        ArmarCelda(posicion.usuarioinventario, 3U),
                        ArmarCelda(posicion.tipoinventario, 3U),
                        ArmarCelda(posicion.hxpinv.HasValue == true ? posicion.hxpinv.Value.ToString() : string.Empty, 3U),
                        ArmarCelda(posicion.cajassueltasinv.HasValue == true ? posicion.cajassueltasinv.Value.ToString() : string.Empty, 3U),
                        ArmarCelda(posicion.estado, 3U),
                        ArmarCelda(posicion.observaciones, 3U),
                        ArmarCelda(posicion.dun14, 3U),
                        ArmarCelda(posicion.codigoarticulo, 3U),
                        ArmarCelda(posicion.tipolectura, 3U),
                        ArmarCelda(posicion.documentoasociado, 3U),
                        ArmarCelda(docu.documento, 3U),
                        ArmarCelda(docu.fase.ToString(), 3U)));
                }
            }

            return sheetData;
        }

        private SheetData cargarExcelPosiciones(SheetData sheetData, int id)
        {
            sheetData.AppendChild(new Row(
                ArmarCelda("Sector", 2U),
                ArmarCelda("Pasillo", 2U),
                ArmarCelda("Columna", 2U),
                ArmarCelda("Nivel", 2U),
                ArmarCelda("Compart", 2U),
                ArmarCelda("Etiqueta", 2U),
                ArmarCelda("Ean13", 2U),
                ArmarCelda("Desc.", 2U),
                ArmarCelda("Proveedor", 2U),
                ArmarCelda("Id OC", 2U),
                ArmarCelda("Fec. Recep", 2U),
                ArmarCelda("Vencimiento", 2U),
                ArmarCelda("Vida Util", 2U),
                ArmarCelda("Dias a Vencer", 2U),
                ArmarCelda("Cxh", 2U),
                ArmarCelda("Hxp", 2U),
                ArmarCelda("Uxb", 2U),
                ArmarCelda("Uxpack", 2U),
                ArmarCelda("Bultos", 2U),
                ArmarCelda("Packs", 2U),
                ArmarCelda("Unidades", 2U),
                ArmarCelda("Recepcionista", 2U),
                ArmarCelda("Almacenador", 2U),
                ArmarCelda("Estado Calidad", 2U),
                ArmarCelda("Cara", 2U),
                ArmarCelda("Metodo", 2U),
                ArmarCelda("Usuario", 2U),
                ArmarCelda("Digito", 2U),
                ArmarCelda("Bultos Inv", 2U),
                ArmarCelda("Fecha Act", 2U),
                ArmarCelda("Usuario Inv", 2U),
                ArmarCelda("Tipo Inv", 2U),
                ArmarCelda("Hxp Inv", 2U),
                ArmarCelda("Cajas Sueltas", 2U),
                ArmarCelda("Estado", 2U),
                ArmarCelda("Obs", 2U),
                ArmarCelda("Dun14", 2U),
                ArmarCelda("Codigo Art", 2U),
                ArmarCelda("Tipo Lectura", 2U),
                ArmarCelda("Doc Asociado", 2U)));


            #region ObtenerDatos

            List<Posicion> posiciones;
            try
            {
                posiciones = _unitOfWorkOfCDsDB.INV_dPosicionesRepository.Get(x => x.idDocumento == id)
                    .ToList().ToModel();
            }
            catch (Exception)
            {
                posiciones = new List<Posicion>();
            }

            #endregion

            foreach (var posicion in posiciones)
            {
                sheetData.AppendChild(new Row(
                    ArmarCelda(posicion.sector, 3U),
                    ArmarCelda(posicion.pasillo, 3U),
                    ArmarCelda(posicion.columna, 3U),
                    ArmarCelda(posicion.nivel, 3U),
                    ArmarCelda(posicion.compart, 3U),
                    ArmarCelda(posicion.etiqueta, 3U),
                    ArmarCelda(posicion.ean13, 3U),
                    ArmarCelda(posicion.descripcion, 3U),
                    ArmarCelda(posicion.proveedor, 3U),
                    ArmarCelda(posicion.id_orden_compra, 3U),
                    ArmarCelda(posicion.fecha_hora_recepcion, 3U),
                    ArmarCelda(posicion.vencimiento, 3U),
                    ArmarCelda(posicion.vidautil, 3U),
                    ArmarCelda(posicion.diasvencer, 3U),
                    ArmarCelda(posicion.cxh, 3U),
                    ArmarCelda(posicion.hxp, 3U),
                    ArmarCelda(posicion.uxb, 3U),
                    ArmarCelda(posicion.uxpack, 3U),
                    ArmarCelda(posicion.bultos, 3U),
                    ArmarCelda(posicion.packs, 3U),
                    ArmarCelda(posicion.unidades, 3U),
                    ArmarCelda(posicion.recepcionista, 3U),
                    ArmarCelda(posicion.almacenador, 3U),
                    ArmarCelda(posicion.estadocalidad, 3U),
                    ArmarCelda(posicion.cara, 3U),
                    ArmarCelda(posicion.metodo, 3U),
                    ArmarCelda(posicion.usuario, 3U),
                    ArmarCelda(posicion.digito, 3U),
                    ArmarCelda(posicion.bultosinv.HasValue == true ? posicion.bultosinv.Value.ToString() : string.Empty, 3U),
                    ArmarCelda(posicion.fechaact, 3U),
                    ArmarCelda(posicion.usuarioinventario, 3U),
                    ArmarCelda(posicion.tipoinventario, 3U),
                    ArmarCelda(posicion.hxpinv.HasValue == true ? posicion.hxpinv.Value.ToString() : string.Empty, 3U),
                    ArmarCelda(posicion.cajassueltasinv.HasValue == true ? posicion.cajassueltasinv.Value.ToString() : string.Empty, 3U),
                    ArmarCelda(posicion.estado, 3U),
                    ArmarCelda(posicion.observaciones, 3U),
                    ArmarCelda(posicion.dun14, 3U),
                    ArmarCelda(posicion.codigoarticulo, 3U),
                    ArmarCelda(posicion.tipolectura, 3U),
                    ArmarCelda(posicion.documentoasociado, 3U)));
            }

            return sheetData;
        }

        private SheetData cargarExcelEstadoActual(SheetData sheetData, int id)
        {
            sheetData.AppendChild(new Row(
                  ArmarCelda("Documento", 2U),
                  ArmarCelda("Legajo", 2U),
                  ArmarCelda("L.Totales", 2U),
                  ArmarCelda("L.Contadas", 2U),
                  ArmarCelda("Porcentaje", 2U),
                  ArmarCelda("Estado",2U),
                  ArmarCelda("P.Lectura", 2U),
                  ArmarCelda("U.Lectura", 2U),
                  ArmarCelda("T.OpeXMin", 2U),
                  ArmarCelda("T.UltLecturaxMin", 2U),
                  ArmarCelda("Prom.LineasXMin", 2U),
                  ArmarCelda("Prom.Descuadre", 2U),
                  ArmarCelda("T.Sin Descuadre", 2U),
                  ArmarCelda("T. Dif Etiqueta", 2U),
                  ArmarCelda("T. Dif Bulto", 2U),
                  ArmarCelda("T. Con Descuadre", 2U),
                  ArmarCelda("T. Descuadre Art", 2U)));


            #region ObtenerDatos

            var reportes = _unitOfWorkOfCDsDB.Sp_ReporteInventario(id, null);

            #endregion

            foreach (var repo in reportes)
            {
                sheetData.AppendChild(new Row(
                    ArmarCelda(repo.Documento, 3U),
                    ArmarCelda(repo.UltimoLegajoAsignado, 3U),
                    ArmarCelda(repo.LineasTotales.ToString(), 3U),
                    ArmarCelda(repo.LineasContadas.ToString(), 3U),
                    ArmarCelda(repo.Porcentaje.ToString("0.##"), 3U),
                    ArmarCelda(ObtenerEstado(repo.Estado), 3U),
                    ArmarCelda(repo.PrimerLectura.ToString(), 3U),
                    ArmarCelda(repo.UltimaLectura.ToString(), 3U),
                    ArmarCelda(repo.TiempoOperacionMinutos.ToString(), 3U),
                    ArmarCelda(repo.TiempoUltimaLecturaMinutos.ToString(), 3U),
                    ArmarCelda(repo.PromedioLineasXMinuto.ToString("0.##"), 3U),
                    ArmarCelda(repo.PromedioDescuadre.ToString("0.##"), 3U),
                    ArmarCelda(repo.TotalSinDescuadre.ToString(), 3U),
                    ArmarCelda(repo.TotalDiferenciaEtiqueta.ToString(), 3U),
                    ArmarCelda(repo.TotalDiferenciaBulto.ToString(), 3U),
                    ArmarCelda(repo.TotalConDescuadre.ToString(), 3U),
                    ArmarCelda(repo.totalDescuadreArticulo.ToString(), 3U)));
            }

            return sheetData;
        }

        private string ObtenerEstado(int id)
        {
            switch (id)
            {
                case 0:
                    return EstadoDocumento.Creado.ToString();
                case 1:
                    return EstadoDocumento.Asignado.ToString();
                case 2:
                    return EstadoDocumento.Finalizado.ToString();
                case 3:
                    return EstadoDocumento.Cancelado.ToString();
                default:
                    return string.Empty;
            }
        }



    }
}

     