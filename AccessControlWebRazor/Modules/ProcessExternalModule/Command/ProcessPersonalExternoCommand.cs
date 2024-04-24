using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Command
{
    public class ProcessPersonalExternoCommand : IRequest<ProcesamientoPersonalExterno>
    {
        public PersonalExterno PersonalExterno { get; set; }
        public LecturasGaritaLog LecturaGaritaLog { get; set; }
        

        public ProcessPersonalExternoCommand(PersonalExterno personalExterno, LecturasGaritaLog lectura)
        {
            PersonalExterno = personalExterno;
            LecturaGaritaLog = lectura;
            


        }
    }
}
