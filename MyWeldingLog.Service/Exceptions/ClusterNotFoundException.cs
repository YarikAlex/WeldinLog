using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class ClusterNotFoundException : WeldingLogException
    {
        public string Name { get; set; }

        public ClusterNotFoundException(string name)
        {
            Name = name;

            Code = ErrorCodes.ClusterNotFound;
            Message = $"Cluster { Name } not found.";
            Details = new { Name };
        }
    }
}