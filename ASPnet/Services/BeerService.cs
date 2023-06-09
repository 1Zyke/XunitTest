﻿using ASPnet.Models;

namespace ASPnet.Services
{
    public class BeerService : IBeerService
    {
        private List<Beer> _beers = new List<Beer>()
        {
            new Beer(){ id=1, name = "Corona", Brand = "Modelo" },
            new Beer(){ id=2, name = "Presidente", Brand = "Jumbo Light" }
        };

        public IEnumerable<Beer> Get() => _beers;

        public Beer? Get(int id) => _beers.FirstOrDefault(x => x.id == id);
    }
}
