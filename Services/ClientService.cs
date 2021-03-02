using System.Collections.Generic;
using getaclub_api.Data;
using getaclub_api.Models;
using System;
namespace getaclub_api.Services
{
    public class ClientService
    {
        public List<ClientModel> all()
        {
            ClientData client = new ClientData();
            return client.all();
        }

        public ClientModel get(int id)
        {
            ClientData client = new ClientData();
            return client.get(id);
        }

        public bool insert(ClientModel client)
        {
            ClientData dclient = new ClientData();
            return dclient.insert(client);
        }

        public bool update(ClientModel client,int id)
        {
            ClientData dclient = new ClientData();
            return dclient.update(client,id);
        }
        public bool delete(int id)
        {
            ClientData dclient = new ClientData();
            return dclient.delete(id);
        }

        public bool exist(int id)
        {
            ClientData dclient = new ClientData();
            return dclient.exist(id);
        }

    }
}