using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Services
    {
    public interface ITiotmasterRepository
        {

        public List<ITiotmasterView> GetList(string modelSerial, double? from, double? to, string sortBy, int page);
        public ITiotmasterView GetById(int id);
        public ITiotmasterView Create(ITiotmasterView Item);
        public void Update(ITiotmaster Item,int id );
        public void DeleteById(int id);

        }
    }
