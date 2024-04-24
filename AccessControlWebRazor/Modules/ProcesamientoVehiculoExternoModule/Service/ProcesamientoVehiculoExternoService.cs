using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Data;
using OfficeOpenXml;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service
{
    public class ProcesamientoVehiculoExternoService : IProcesamientoVehiculoExternoService
    {
        private readonly IProcesamientoVehiculoExternoRepository _repository;
        public ProcesamientoVehiculoExternoService(IProcesamientoVehiculoExternoRepository procesamientoVehiculoExternoRepository)
        {
            _repository = procesamientoVehiculoExternoRepository;
        }
        public List<ProcesamientoVehiculoExterno> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public List<ProcesamientoVehiculoExterno> GetAllByCentroCosto(int centroCosto)
        {
            return _repository.GetAsync(x => x.CentroCostoID == centroCosto).Result.ToList();
        }

        public ProcesamientoVehiculoExterno GetByDominio(string dominio)
        {
            return _repository.GetAsync(x=> x.Dominio == dominio).Result.FirstOrDefault();
        }

        public ProcesamientoVehiculoExterno GetById(int id)
        {
            return _repository.GetById(id);
        }
        public ProcesamientoVehiculoExterno GetByVehicleId(int vehiculoID)
        {
            return _repository.GetAsync(x=> x.VehiculoId == vehiculoID).Result.LastOrDefault();
        }

        public ProcesamientoVehiculoExterno InsertProcess(ProcesamientoVehiculoExterno procesamiento)
        {
            return _repository.Insert(procesamiento);
        }
        public ProcesamientoVehiculoExterno UpdateProcesamiento(ProcesamientoVehiculoExterno procesamientoVehiculoExterno)
        {
            return _repository.Update(procesamientoVehiculoExterno);
        }
        public byte[] ExportToExcel(List<ProcesamientoVehiculoExterno> procesamientos)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Procesamientos Vehiculos Externos");

                // Encabezados
                worksheet.Cells["A1"].Value = "Dominio";
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

        public List<ProcesamientoVehiculoExterno> GetAllByCentroCostoNoCZero()
        {
            var coso = _repository.GetAsync(x => x.CentroCostoID > 0).Result.ToList();
            return coso;
        }
    }
}
