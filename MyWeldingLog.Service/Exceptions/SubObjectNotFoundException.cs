using MyWeldingLog.Service.Exceptions.BaseException;

namespace MyWeldingLog.Service.Exceptions
{
    public class SubObjectNotFoundException : WeldingLogException
    {
        public int? SubObjectId { get; set; }

        public string? SubObjectName { get; set; }

        public SubObjectNotFoundException(int? subObjectId = null, string? subObjectName = null)
        {
            SubObjectId = subObjectId;
            SubObjectName = subObjectName;
        }
    }
}