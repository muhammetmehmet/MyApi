
using MyApi.Enums;
using System.Linq.Expressions;

namespace MyApi.Models.Abstracts
{
    public interface IVehicle
    {
        ColorEnum Color { get; set; }
        int Id { get; set; }
    }
}
