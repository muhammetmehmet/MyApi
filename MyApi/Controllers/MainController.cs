using Microsoft.AspNetCore.Mvc;
using MyApi.Enums;
using MyApi.Models.Abstracts;
using MyApi.Service;

namespace MyApi.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        #region Scoped Service kısmı burası -- Buraya program.cs kısmından register edilip gönderiliyor

        private ICarService _carService;
        private IBusService _busService;
        private IBoatService _boatService;
        public MainController(ICarService carService, IBusService busService, IBoatService boatService)
        {
            _carService = carService;
            _busService = busService;
            _boatService = boatService;
        }

        #endregion

        // Renge göre araba, otobüs ve tekneleri dönen actionlar, far açma kapama ve araba silme de burada.
        // Projeyi start ettiğinizde Swagger açılacak ona izin vererek actionları test edebilirsiniz veya Postman'den de gönderilebilir.
        // appsettings.json içine DefaultConnection içine kendi sql bilgilerinizi girersiniz şuan ben boşaltıyorum.

        [HttpGet("{color}")]
        public ActionResult GetCar(ColorEnum color)
        {
            var result = _carService.GetList(x => x.Color == color);
            return Ok(result);
        }

        [HttpGet("{color}")]
        public ActionResult GetBus(ColorEnum color)
        {
            var result = _busService.GetList(x => x.Color == color);
            return Ok(result);
        }
        [HttpGet("{color}")]
        public ActionResult GetBoat(ColorEnum color)
        {
            var result = _boatService.GetList(x => x.Color == color);
            return Ok(result);
        }

        [HttpPost("{carId}/{isOn}")]
        public ActionResult SetHeadlight(int carId, bool isOn)
        {
            
            var result = _carService.GetSingle(x => x.Id == carId);
            if (result.Data != null)
            {
                result.Data.Headlights = isOn;
                return Ok(_carService.Update(result.Data));
            }
            return Ok("Car is not exist");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            return Ok(_carService.Delete(id));
        }
    }
}