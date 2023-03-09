namespace MyWeldingLog.Models.Enums
{
    public enum StatusCode
    {
        InternalServerError = 0,
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
        
        //ProjectCodes
        ProjectCodeAlreadyExist,
        ProjectCodeNotFound,
        ProjectCodesNotFound
    }
}