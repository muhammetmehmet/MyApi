using MyApi.Context;
using MyApi.Models.Abstracts;
using MyApi.Models.Base;
using System.Linq.Expressions;

namespace MyApi.Models
{
    // Classları dediği gibi vehicle (Base class) ' tan aldım. Renk, Id ve Name kolonları Base Class'tan geliyor.
    // (Boat ve Bus'ta da bu şekilde onlara ayrı ayrı yazmıyorum)
    public class Car : Vehicle
    {
        public bool Headlights { get; set; }
        public string Wheels { get; set; }
    }
}
