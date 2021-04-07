using Utilities.BaseClasses;

namespace Data.Entities
{
    public class Letter : BaseEntity
    {
        public string FullName { get; set; }     
        public string Email { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
