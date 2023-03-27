using MyWeldingLog.Models.Enums;
using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class ClusterAlreadyExistException : WeldingLogException
    {
        public string ObjectName { get; set; }
        public string SubObjectName { get; set; }

        public string ClusterName { get; set; }

        public ClusterAlreadyExistException(
            string objectName,
            string subObjectName,
            string clusterName)
        {
            ObjectName = objectName;
            SubObjectName = subObjectName;
            ClusterName = clusterName;

            Code = ErrorCodes.ClusterAlreadyExist;
            Message = $"For object { objectName } and subObject { subObjectName } " +
                      $"already exist cluster with name { clusterName }";
            Details = new { ClusterName, ObjectName, SubObjectName };
        }
    }
}