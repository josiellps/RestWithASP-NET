using System.Runtime.Serialization;

namespace RestWithAPI.Model.Base
{
    [DataContract]
    public class BaseEntity
    {
        public long Id{get;set;}
    }
}