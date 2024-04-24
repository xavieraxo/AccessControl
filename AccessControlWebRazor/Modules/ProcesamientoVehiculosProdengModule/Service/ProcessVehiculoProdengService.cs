using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Data;
using OfficeOpenXml;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service
{
    public class ProcessVehiculoProdengService : IProcessVehiculoProdengService
    {
        private readonly IProcesamientoVehiculoProdengRepository _repository;

        public ProcessVehiculoProdengService(IProcesamientoVehiculoProdengRepository procesamientoVehiculoProdengRepository)
        {
            _repository = procesamientoVehiculoProdengRepository;
        }

        public List<ProcesamientoVehiculoProdeng> GetAllVehiculoProdengProcesado()
        {
            return _repository.GetAll().ToList();
        }

        public ProcesamientoVehiculoProdeng GetProcesamientoByVehiculoProdengId(int VehiculoProdengID)
        {
            return _repository.GetAsync(x=> x.VehiculoProdengId == VehiculoProdengID).Result.LastOrDefault();
        }

        public ProcesamientoVehiculoProdeng InsertProcess(ProcesamientoVehiculoProdeng procesamiento)
        {
            return _repository.Insert(procesamiento);
        }

        public ProcesamientoVehiculoProdeng UpdateProcess(ProcesamientoVehiculoProdeng procesamiento)
        {
            return _repository.Update(procesamiento);
        }
        public List<ProcesamientoVehiculoProdeng> GetAllByCentroCostoNoCZero()
        {
            return _repository.GetAsync(x => x.CentroCostoId != 0).Result.ToList();
        }
        public List<ProcesamientoVehiculoProdeng> GetAllByCentroCosto(int centroCosto)
        {
            return _repository.GetAsync(x => x.CentroCostoId == centroCosto).Result.ToList();
        }
        public byte[] ExportToExcel(List<ProcesamientoVehiculoProdeng> procesamientos)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Procesamientos Vehiculos Prodeng");

                // Encabezados
                worksheet.Cells["A1"].Value = "Dominio";
                worksheet.Cells["B1"].Value = "Hora Ingreso";
                worksheet.Cells["C1"].Value = "Hora Egreso";
                worksheet.Cells["D1"].Value = "Total Horas";
                worksheet.Cells["E1"].Value = "Procesado";
                worksheet.Cells["F1"].Value = "Centro Costo Desc";
                worksheet.Cells["G1"].Value = "Estado Fichada";                
                worksheet.Cells["H1"].Value = "Fecha";

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

                    worksheet.Cells[row, 1].Value = procesamiento.Dominio;
                    worksheet.Cells[row, 2].Value = procesamiento.HoraIngreso;
                    worksheet.Cells[row, 3].Value = procesamiento.HoraEgreso;
                    worksheet.Cells[row, 4].Value = procesamiento.TotalHoras;
                    if (procesamiento.Procesado== 1)
                    {
                        worksheet.Cells[row, 5].Value = "Verdadero";
                    }
                    else
                    {
                        worksheet.Cells[row, 5].Value = "Falso";
                    }
                    worksheet.Cells[row, 6].Value = procesamiento.CentroCostoDesc;
                    worksheet.Cells[row, 7].Value = procesamiento.EstadoFichado;
                    worksheet.Cells[row, 8].Value = procesamiento.Fecha;
                }

                // Autoajustar columnas
                worksheet.Cells.AutoFitColumns();

                // Convertir a array de bytes
                return package.GetAsByteArray();
            }
        }

        public ProcesamientoVehiculoProdeng GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
