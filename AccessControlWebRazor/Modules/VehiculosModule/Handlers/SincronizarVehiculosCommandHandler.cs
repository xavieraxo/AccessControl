using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.VehiculosModule.Command;
using AccessControlWebRazor.Modules.VehiculosModule.Service;
using ExcelDataReader;
using MediatR;
using System.Data;

namespace AccessControlWebRazor.Modules.VehiculosModule.Handlers
{
    public class SincronizarVehiculosCommandHandler : IRequestHandler<SincronizarVehiculosCommand, bool>
    {
        private readonly IVehiculoService _service;

        public SincronizarVehiculosCommandHandler(IVehiculoService vehiculoService)
        {
            _service = vehiculoService;
        }
        public Task<bool> Handle(SincronizarVehiculosCommand request, CancellationToken cancellationToken)
        {
            var result = ReadExcelFile(request.Path);
            _service.Sincronizacion(result);
            return Task.FromResult(true);
        }

        public List<Vehiculo> ReadExcelFile(string filePath)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePaths = Path.Combine(desktopPath, "Flota.xlsx");


            using (var stream = File.Open(filePaths, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    reader.Read();
                    var columnNames = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames.Add(reader.GetValue(i)?.ToString());
                    }

                    // Lee los datos
                    while (reader.Read())
                    {
                        var statusStr = GetValueFromColumn(reader, "Estado", columnNames);
                        int status = 0;
                        if (statusStr == "Activa")
                        {
                            status = 1;
                        }
                        var vehiculo = new Vehiculo
                        {
                            Dominio = GetValueFromColumn(reader, "Patente", columnNames),
                            Model = GetValueFromColumn(reader, "Modelo", columnNames),
                            IsActive = status
                        };

                        vehiculos.Add(vehiculo);
                    }
                }
            }

            return vehiculos;
        }

        private string GetValueFromColumn(IDataRecord reader, string columnName, List<string> columnNames)
        {
            int columnIndex = columnNames.IndexOf(columnName);
            return (columnIndex >= 0 && columnIndex < reader.FieldCount) ? reader[columnIndex]?.ToString() : null;
        }
    }
}
