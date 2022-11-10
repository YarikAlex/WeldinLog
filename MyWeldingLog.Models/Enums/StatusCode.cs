namespace MyWeldingLog.Models.Enums
{
    public enum StatusCode
    {
        InternalServerError = 0,
        Ok,
        
        //Hierarchy
        LinkAlreadyExist,
        
        //Objects
        ObjectNotFound,
        ObjectsNotFound,
        ObjectAlreadyExist,
        
        //SubObjects
        SubObjectAlreadyExist,
        SubObjectNotFound,
        
        //Pipes
        PipeNotFound,
        
        //Branches
        BranchNotFound
    }
}