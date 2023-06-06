using ASPnet.Controllers;
using ASPnet.Models;
using ASPnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPTest
{
    public class BeerTesting
    {
        private readonly BeerController _controller;  /* Controller */
        private readonly IBeerService _service;  /* Service */

        public BeerTesting()
        {
            _service = new BeerService();
            _controller = new BeerController(_service);
        }
        [Fact]
        public void Get_Ok()
        {
            var result = _controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Quantity()
        {
            var result = (OkObjectResult)_controller.Get();

            var beers = Assert.IsType<List<Beer>>(result.Value);
            Assert.True(beers.Count > 0);
        }

        [Fact]
        public void GetById_Ok()
        {
            int id = 1;

            var result = _controller.GetById(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_Exists()
        {
            int id = 1;

            var result = (OkObjectResult)_controller.GetById(id);

            var beer = Assert.IsType<Beer>(result?.Value);
            Assert.True(beer != null);
            Assert.Equal(beer?.id, id);
        }

        [Fact]
        public void GetById_Found()
        {
            int id = 1;

            var result = _controller.GetById(id);

            var beer = Assert.IsType<NotFoundResult>(result);
        }
    }
}