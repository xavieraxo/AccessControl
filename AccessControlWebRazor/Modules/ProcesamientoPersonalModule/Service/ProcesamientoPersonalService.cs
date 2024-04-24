using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Data;

using OfficeOpenXml;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service
{
    public class ProcesamientoPersonalService : IProcesamientoPersonalService
    {
        private readonly IProcesamientoPersonalRepository _procesamientoRepository;

        public ProcesamientoPersonalService(IProcesamientoPersonalRepository procesamientoRepository)
        {
            _procesamientoRepository = procesamientoRepository;   
        }

        public byte[] ExportToExcel(List<Procesamiento> procesamientos)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Procesamientos Personal Prodeng");

                // Encabezados
                worksheet.Cells["A1"].Value = "DNI";
                worksheet.Cells["B1"].Value = "Legajo";
                worksheet.Cells["C1"].Value = "Hora Ingreso";
                worksheet.Cells["D1"].Value = "Hora Egreso";
                worksheet.Cells["E1"].Value = "Total Horas";
                worksheet.Cells["F1"].Value = "Procesado";
                worksheet.Cells["G1"].Value = "Centro Costo Desc";
                worksheet.Cells["H1"].Value = "Estado Fichada";
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
                    worksheet.Cells[row, 2].Value = procesamiento.Legajo;
                    worksheet.Cells[row, 3].Value = procesamiento.HoraIngreso;
                    worksheet.Cells[row, 4].Value = procesamiento.HoraEgreso;                    
                    worksheet.Cells[row, 5].Value = procesamiento.TotalHoras;
                    if (procesamiento.Procesado.Value)
                    {
                        worksheet.Cells[row, 6].Value = "Verdadero";
                    }
                    else
                    {
                        worksheet.Cells[row, 6].Value = "Falso";
                    }
                    worksheet.Cells[row, 7].Value = procesamiento.CentroCostoDesc;
                    worksheet.Cells[row, 8].Value = procesamiento.EstadoFichada;
                    worksheet.Cells[row, 9].Value = procesamiento.Fecha;
                    
                }

                // Autoajustar columnas
                worksheet.Cells.AutoFitColumns();

                // Convertir a array de bytes
                return package.GetAsByteArray();
            }
        }

        public List<Procesamiento> GetAllByCentroCosto(int centroCosto)
        {
            return _procesamientoRepository.GetAsync(x => x.CentroCosto == centroCosto).Result.ToList();
        }

        public List<Procesamiento> GetAllByCentroCostoNoCZero()
        {
            return _procesamientoRepository.GetAsync(x => x.CentroCosto != 0 ).Result.ToList();
        }

        public List<Procesamiento> GetAllProcesamiento()
        {
            return _procesamientoRepository.GetAll().ToList();
        }

        public List<Procesamiento> GetAllProcesamientoDistincZero()
        {
            var result = _procesamientoRepository.GetAsync(x => x.CentroCosto != 0).Result;
            return result.ToList();
        }

        public List<Procesamiento> GetProcemientoByCentroCosto(int centroCosto)
        {
            var result = _procesamientoRepository.GetAsync(x=> x.CentroCosto == centroCosto).Result;
            return result.ToList();
        }

        public Procesamiento GetProcesamientoByID(int ID)
        {
            return _procesamientoRepository.GetById(ID);
        }

        public Procesamiento UpdateProcesamiento(Procesamiento procesamiento)
        {
            return _procesamientoRepository.Update(procesamiento);
        }
    }
}
