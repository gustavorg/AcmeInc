using System.Collections.Generic;
using getaclub_api.Data;
using getaclub_api.Models;
using System;
namespace getaclub_api.Services
{
    public class CateringService
    {
        public List<CateringModel> all()
        {
            CateringData dcatering = new CateringData();
            return dcatering.all();
        }

        public CateringModel get(int id)
        {
            CateringData dcatering = new CateringData();
            return dcatering.get(id);
        }

        public bool insert(CateringModel catering)
        {
            CateringData dcatering = new CateringData();
            return dcatering.insert(catering);
        }

        public bool update(CateringModel catering,int id)
        {
            CateringData dcatering = new CateringData();
            return dcatering.update(catering,id);
        }
        public bool delete(int id)
        {
            CateringData dcatering = new CateringData();
            return dcatering.delete(id);
        }

    }
}