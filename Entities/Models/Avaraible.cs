using System.Runtime.Serialization;

namespace Entities.Models
{
    public enum Avaraible
    {
        [EnumMember(Value = "Open")]
        Open,
        [EnumMember(Value = "Close")]
        Close
    }
}