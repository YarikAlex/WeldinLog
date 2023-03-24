namespace MyWeldingLog.Models.Enums
{
    public enum ErrorCodes
    {
        ServerError = 0,
        Ok,
        
        //Hierarchy
        LinkAlreadyExist,
        LinkNotFound,

        //Objects
        ObjectNotFound,
        ObjectsNotFound,
        ObjectAlreadyExist,

        //SubObjects
        SubObjectAlreadyExist,
        SubObjectNotFound,
        SubObjectsNotFound,

        //ProjectCodes
        ProjectCodeAlreadyExist,
        ProjectCodeNotFound,
        ProjectCodesNotFound
    }
}