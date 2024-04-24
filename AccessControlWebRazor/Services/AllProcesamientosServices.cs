using AccessControlWebRazor.DTO_s.AllProcesamientoDTO;
using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Data;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries;
using AccessControlWebRazor.Modules.PersonalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Data;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Data;
using AccessControlWebRazor.Modules.ProcessExternalModule.Data;
using Humanizer;
using MediatR;

namespace AccessControlWebRazor.Services
{
    public class AllProcesamientosServices : IAllProcesamientosServices
    {
        private readonly IMediator _mediator;
        private readonly IProcesamientoPersonalRepository _procesamientoPersonalRepository;
        private readonly IProcesamientoPersonalExternoRepository _procesamientoPersonalExternoRepository;
        private readonly ILecturasGaritaLogRepository _lecturasGaritaLogRepository;

        public AllProcesamientosServices(IMediator mediator, IProcesamientoPersonalRepository procesamientoPersonalRepository,
                                                             IProcesamientoPersonalExternoRepository procesamientoPersonalExternoRepository,
                                                             ILecturasGaritaLogRepository lecturasGaritaLogRepository)
        {
            _mediator = mediator;
            _procesamientoPersonalRepository = procesamientoPersonalRepository;
            _procesamientoPersonalExternoRepository = procesamientoPersonalExternoRepository;
            _lecturasGaritaLogRepository = lecturasGaritaLogRepository;
        }

        public void ProcesarPersonas()
        {
            var lecturasPersonas = _lecturasGaritaLogRepository.GetAsync(x => x.Procesado == 0).Result.ToList();
            List<DNIyFecha> ListaDNIFecha = new List<DNIyFecha>();

            foreach (var lectura in lecturasPersonas)
            {

                if (lectura.DNI != null)
                {
                    var persona = _mediator.Send(new GetPersonalByDNIQuery(Convert.ToInt32(lectura.DNI))).Result;
                    if (persona != null)
                    {
                        var lecturaEsaPersona = lecturasPersonas.Where(x => x.DNI == lectura.DNI && x.Procesado == 0).OrderBy(x => x.FechaLectura).ToList();
                        foreach (var item in lecturaEsaPersona)
                        {

                            if (lecturaEsaPersona.Count(x => x.FechaLectura.Value.Date == item.FechaLectura.Value.Date) > 1)
                            {
                                var primerIngreso = item.FechaLectura.Value;
                                var ultimoIngreso = lecturasPersonas.LastOrDefault(x => x.FechaLectura.Value.Date == primerIngreso.Date && x.DNI == persona.NroDocumento.Value.ToString())?.FechaLectura.Value;
                                if (ultimoIngreso == null)
                                {
                                    ultimoIngreso = primerIngreso;
                                }
                                var totalHoras = 0;
                                if (primerIngreso.Hour != ultimoIngreso.Value.Hour && primerIngreso.Minute != ultimoIngreso.Value.Minute)
                                {
                                    if (!ListaDNIFecha.Any(x => x.DNI == persona.NroDocumento.Value.ToString()) && !ListaDNIFecha.Any(x => x.Fecha.Date == item.FechaLectura.Value.Date))
                                    {
                                        if (primerIngreso != null && ultimoIngreso != null)
                                        {
                                            totalHoras = ultimoIngreso.Value.Hour - primerIngreso.Hour;
                                        }
                                        var nuevoProcesamiento = new Procesamiento()
                                        {
                                            DNI = lectura.DNI,
                                            CentroCostoDesc = "",
                                            CentroCosto = 0,
                                            Fecha = primerIngreso.ToShortDateString(),
                                            HoraIngreso = primerIngreso.ToString(),
                                            HoraEgreso = ultimoIngreso.ToString(),
                                            Legajo = persona.NroLegajo.ToString(),
                                            TotalHoras = totalHoras.ToString(),
                                            Procesado = false,
                                            EstadoFichada = ""
                                        };
                                        var result = _procesamientoPersonalRepository.Insert(nuevoProcesamiento);
                                        var todasIngresosEsaFecha = lecturaEsaPersona.Where(x => x.FechaLectura.Value.Date == item.FechaLectura.Value.Date).ToList();
                                        if (result != null)
                                        {
                                            var DNIFecha = new DNIyFecha()
                                            {
                                                DNI = persona.NroDocumento.ToString(),
                                                Fecha = item.FechaLectura.Value.Date
                                            };
                                            ListaDNIFecha.Add(DNIFecha);
                                            foreach (var itemsFecha in todasIngresosEsaFecha)
                                            {
                                                itemsFecha.Procesado = 1;
                                                _lecturasGaritaLogRepository.Update(itemsFecha);
                                            }
                                        }
                                    }
                                }

                            }
                        }

                    }
                    else
                    {
                        var personaExt = _mediator.Send(new GetPersonalExternoByFilterQuery(lectura.DNI)).Result;
                        if (personaExt.Count > 0)
                        {
                            var lecturaEsaPersona2 = lecturasPersonas.Where(x => x.DNI == lectura.DNI && x.Procesado == 0).OrderBy(x => x.FechaLectura).ToList();
                            foreach (var item in lecturaEsaPersona2)
                            {
                               
                                    if (lecturaEsaPersona2.Count(x => x.FechaLectura.Value.Date == item.FechaLectura.Value.Date) > 1)
                                    {
                                        var primerIngreso = item.FechaLectura.Value;
                                        var ultimoIngreso = lecturasPersonas.LastOrDefault(x => x.FechaLectura.Value.Date == primerIngreso.Date && x.DNI == personaExt.FirstOrDefault().Dni)?.FechaLectura.Value;
                                        if (ultimoIngreso == null)
                                        {
                                            ultimoIngreso = primerIngreso;
                                        }
                                        var totalHoras = 0;
                                        if (primerIngreso.Hour != ultimoIngreso.Value.Hour && primerIngreso.Minute != ultimoIngreso.Value.Minute)
                                        {
                                            if (primerIngreso != null && ultimoIngreso != null)
                                            {
                                                totalHoras = ultimoIngreso.Value.Hour - primerIngreso.Hour;
                                            }
                                        if (!ListaDNIFecha.Any(x => x.DNI == personaExt.FirstOrDefault().Dni) && !ListaDNIFecha.Any(x => x.Fecha.Date == item.FechaLectura.Value.Date))
                                        {
                                            var nuevoProcesamiento = new ProcesamientoPersonalExterno()
                                            {
                                                DNI = lectura.DNI,
                                                CentroCostoDesc = "",
                                                CentroCostoId = 0,
                                                Fecha = primerIngreso.ToShortDateString(),
                                                HoraIngreso = primerIngreso.ToString(),
                                                HoraEgreso = ultimoIngreso.ToString(),
                                                TotalHoras = totalHoras.ToString(),
                                                Procesado = 0,
                                                EstadoFichada = ""
                                            };
                                            var result = _procesamientoPersonalExternoRepository.Insert(nuevoProcesamiento);
                                            var todasIngresosEsaFecha = lecturaEsaPersona2.Where(x => x.FechaLectura.Value.Date == item.FechaLectura.Value.Date).ToList();
                                            if (result != null)
                                            {
                                                var DNIFecha = new DNIyFecha()
                                                {
                                                    DNI = personaExt.FirstOrDefault().Dni.ToString(),
                                                    Fecha = item.FechaLectura.Value.Date
                                                };
                                                ListaDNIFecha.Add(DNIFecha);
                                                foreach (var itemsFecha in todasIngresosEsaFecha)
                                                {
                                                    itemsFecha.Procesado = 1;
                                                    _lecturasGaritaLogRepository.Update(itemsFecha);
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

            }

        }

        public void ProcesarVehiculos()
        {
            throw new NotImplementedException();
        }

        //public void ProcesarVehiculos()
        //{
        //    var lecturasPatentes = _lecturaPatenteRepository.GetAsync(x => x.Procesado == 0).Result.ToList();
        //    List<DNIyFecha> ListaDNIFecha = new List<DNIyFecha>();

        //    foreach (var item in lecturasPatentes)
        //    {

        //        if (item.Patente != "unknown" || item.Patente != "######" || !string.IsNullOrWhiteSpace(item.Patente))
        //        {
        //            var vehiculoProdeng = _mediator.Send(new GetVehiculosProdengByFilterQuery(item.Patente)).Result.FirstOrDefault();

        //            if (vehiculoProdeng != null)
        //            {

        //                var lecturaEseVehiculo = lecturasPatentes.Where(x => x.Patente == item.Patente && x.Procesado == 0).ToList();
        //                foreach (var lectura in lecturaEseVehiculo)
        //                {
        //                    var primerIngreso = lectura.FechaLectura_datetime;
        //                    var ultimoIngreso = lecturaEseVehiculo.LastOrDefault(x => x.FechaLectura_datetime.Date == primerIngreso.Date && x.Patente == vehiculoProdeng.Dominio)?.FechaLectura_datetime;
        //                    if (ultimoIngreso == null)
        //                    {
        //                        ultimoIngreso = primerIngreso;
        //                    }
        //                    var totalHoras = 0;
        //                    if (primerIngreso.Hour != ultimoIngreso.Value.Hour && primerIngreso.Minute != ultimoIngreso.Value.Minute)
        //                    {
        //                        if (!ListaDNIFecha.Any(x => x.DNI == vehiculoProdeng.Dominio) && !ListaDNIFecha.Any(x => x.Fecha.Date == item.FechaLectura_datetime.Date))
        //                        {
        //                            if (primerIngreso != null && ultimoIngreso != null)
        //                            {
        //                                totalHoras = ultimoIngreso.Value.Hour - primerIngreso.Hour;
        //                            }
        //                            var nuevoProcesamiento = new ProcesamientoVehiculos()
        //                            {
        //                                Dominio = vehiculoProdeng.Dominio,
        //                                CentroCostoDesc = "",
        //                                CentroCostoId = 0,
        //                                Fecha = primerIngreso.ToShortDateString(),
        //                                HoraIngreso = primerIngreso.ToString(),
        //                                HoraEgreso = ultimoIngreso.ToString(),
        //                                TotalHoras = totalHoras.ToString(),
        //                                Procesado = 0,
        //                            };
        //                            var result = _procesamientoVehiculoProdengRepository.Insert(nuevoProcesamiento);
        //                            if (result != null)
        //                            {
        //                                var DNIFecha = new DNIyFecha()
        //                                {
        //                                    DNI = vehiculoProdeng.Dominio,
        //                                    Fecha = item.FechaLectura_datetime
        //                                };
        //                                ListaDNIFecha.Add(DNIFecha);
        //                                var itemsDeEsaFecha = lecturaEseVehiculo.Where(x => x.FechaLectura_datetime == item.FechaLectura_datetime).ToList();
        //                                foreach (var itemFecha in itemsDeEsaFecha)
        //                                {
        //                                    itemFecha.Procesado = 1;
        //                                    _lecturaPatenteRepository.Update(itemFecha);
        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                var vehiculoExterno = _mediator.Send(new GetVehiculosExternosByFilterQuery(item.Patente)).Result.FirstOrDefault();
        //                if (vehiculoExterno != null)
        //                {
        //                    var lecturaEseVehiculo2 = lecturasPatentes.Where(x => x.Patente == vehiculoExterno.Dominio && x.Procesado == 0).ToList();

        //                    foreach (var lectura in lecturaEseVehiculo2)
        //                    {
        //                        var primerIngreso = lectura.FechaLectura_datetime;
        //                        var ultimoIngreso = lecturaEseVehiculo2.LastOrDefault(x => x.FechaLectura_datetime.Date == primerIngreso.Date && x.Patente == vehiculoExterno.Dominio)?.FechaLectura_datetime;
        //                        if (ultimoIngreso == null)
        //                        {
        //                            ultimoIngreso = primerIngreso;
        //                        }
        //                        var totalHoras = 0;
        //                        if (primerIngreso.Hour != ultimoIngreso.Value.Hour && primerIngreso.Minute != ultimoIngreso.Value.Minute)
        //                        {
        //                            if (!ListaDNIFecha.Any(x => x.DNI == vehiculoExterno.Dominio) && !ListaDNIFecha.Any(x => x.Fecha.Date == item.FechaLectura_datetime.Date))
        //                            {
        //                                if (primerIngreso != null && ultimoIngreso != null)
        //                                {
        //                                    totalHoras = ultimoIngreso.Value.Hour - primerIngreso.Hour;
        //                                }
        //                                var nuevoProcesamiento = new ProcesamientoVehiculoExterno()
        //                                {
        //                                    Dominio = vehiculoExterno.Dominio,
        //                                    CentroCostoDesc = "",
        //                                    CentroCostoID = 0,
        //                                    Fecha = primerIngreso.ToShortDateString(),
        //                                    HoraIngreso = primerIngreso.ToString(),
        //                                    HoraEgreso = ultimoIngreso.ToString(),
        //                                    TotalHoras = totalHoras.ToString(),
        //                                    Procesado = 0,
        //                                };
        //                                var result = _procesamientoVehiculoExternoRepository.Insert(nuevoProcesamiento);
        //                                if (result != null)
        //                                {
        //                                    var DNIFecha = new DNIyFecha()
        //                                    {
        //                                        DNI = vehiculoExterno.Dominio,
        //                                        Fecha = item.FechaLectura_datetime
        //                                    };
        //                                    ListaDNIFecha.Add(DNIFecha);
        //                                    var itemsDeEsaFecha = lecturaEseVehiculo2.Where(x => x.FechaLectura_datetime == item.FechaLectura_datetime).ToList();
        //                                    foreach (var itemFecha in itemsDeEsaFecha)
        //                                    {
        //                                        itemFecha.Procesado = 1;
        //                                        _lecturaPatenteRepository.Update(itemFecha);
        //                                    }

        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
