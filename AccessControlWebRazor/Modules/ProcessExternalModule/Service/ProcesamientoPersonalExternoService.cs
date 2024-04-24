using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcessExternalModule.Data;
using OfficeOpenXml;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Service
{
    public class ProcesamientoPersonalExternoService : IProcesamientoPersonalExternoService
    {
        private readonly IProcesamientoPersonalExternoRepository _procesamientoRepository;

        public ProcesamientoPersonalExternoService(IProcesamientoPersonalExternoRepository procesamientoRepository)
        {
            _procesamientoRepository = procesamientoRepository;
        }
        public byte[] ExportToExcel(List<ProcesamientoPersonalExterno> procesamientos)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Procesamientos Vehiculos Prodeng");

                // Encabezados
                worksheet.Cells["A1"].Value = "DNI";
                worksheet.Cells["B1"].Value = "Hora Ingreso";
                worksheet.Cells["C1"].Value = "Hora Egreso";
                worksheet.Cells["D1"].Value = "Total Horas";
                worksheet.Cells["E1"].Value = "Procesado";
                worksheet.Cells["F1"].Value = "Centro Costo";
                worksheet.Cells["G1"].Value = "Estado Fichada";
                worksheet.Cells["H1"].Value = "Centro Costo Desc";
                worksheet.Cells["I1"].Value = "Fecha";

                // Estilo de encabezados
                using (var range = worksheet.Cells["A1:L1"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                // Datos
                for (int i = 0; i < procesamientos.Count; i++)
                {
                    var procesamiento = procesamientos[i];
                    int row = i + 2; // Empieza desde la segunda fila

                    worksheet.Cells[row, 1].Value = procesamiento.DNI;
                    worksheet.Cells[row, 2].Value = procesamiento.HoraIngreso;
                    worksheet.Cells[row, 3].Value = procesamiento.HoraEgreso;
                    worksheet.Cells[row, 4].Value = procesamiento.TotalHoras;
                    if (procesamiento.Procesado == 1)
                    {
                        worksheet.Cells[row, 5].Value = "Verdadero";
                    }
                    else
                    {
                        worksheet.Cells[row, 5].Value = "Falso";
                    }
                    worksheet.Cells[row, 6].Value = procesamiento.CentroCostoDesc;
                    worksheet.Cells[row, 7].Value = procesamiento.EstadoFichada;
                    worksheet.Cells[row, 8].Value = procesamiento.Fecha;
                }

                // Autoajustar columnas
                worksheet.Cells.AutoFitColumns();

                // Convertir a array de bytes
                return package.GetAsByteArray();
            }
        }

        public List<ProcesamientoPersonalExterno> GetAll()
        {
            return _procesamientoRepository.GetAll().ToList();
        }

        public List<ProcesamientoPersonalExterno> GetAllByCentroCosto(int centroCosto)
        {
            return _procesamientoRepository.GetAsync(x => x.CentroCostoId == centroCosto).Result.ToList();
        }

        public List<ProcesamientoPersonalExterno> GetAllProcessPersExtByCentroCostoDisctinctZero()
        {
            return _procesamientoRepository.GetAsync(x => x.CentroCostoId != 0).Result.ToList();
        }

        public List<ProcesamientoPersonalExterno> GetByDate(DateTime desde, DateTime hasta)
        {
            return _procesamientoRepository.GetAsync(x => Convert.ToDateTime(x.Fecha) >= desde && Convert.ToDateTime(x.Fecha) <= hasta).Result.ToList();
        }

        public List<ProcesamientoPersonalExterno> GetByFilter(string filter, bool cCosto)
        {
            List<ProcesamientoPersonalExterno> respuesta;
            var ccosto = cCosto ? 0 : 1;
            if (cCosto)
            {
                respuesta = _procesamientoRepository.GetAsync(x => x.DNI.ToUpper().Trim().Contains(filter.ToLower()) && x.CentroCostoId == 0).Result.ToList();
            }
            else
            {
                respuesta = _procesamientoRepository.GetAsync(x => x.DNI.ToUpper().Trim().Contains(filter.ToLower()) && x.CentroCostoId != 0).Result.ToList();
            }
            List<ProcesamientoPersonalExterno> processExt = respuesta;
            return processExt;
        }

        public ProcesamientoPersonalExterno GetProcesamientoByPersonalId(int personalExternoID)
        {
            return _procesamientoRepository.GetAsync(x => x.PersonalExternoId == personalExternoID && x.Procesado == 0).Result.FirstOrDefault();
        }

        public ProcesamientoPersonalExterno GetProcesamientoExternoById(int procesamientoID)
        {
            return _procesamientoRepository.GetAsync(x => x.Id == procesamientoID).Result.FirstOrDefault();
        }

        public ProcesamientoPersonalExterno InsertProcess(ProcesamientoPersonalExterno procesamiento)
        {
            return _procesamientoRepository.Insert(procesamiento);
        }

        public ProcesamientoPersonalExterno UpdateProcess(ProcesamientoPersonalExterno procesamiento)
        {
            
            return _procesamientoRepository.Update(procesamiento);
        }
    }
}
