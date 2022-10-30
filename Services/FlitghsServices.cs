using MongoDB.Driver;
using POntheFly.Models;
using POntheFly.Utils;
using System;
using System.Collections.Generic;
using System.Net;

namespace POntheFly.Services
{
    public class FlitghsServices
    {
        private readonly IMongoCollection<Flitghs> _flitghs;

        public FlitghsServices(IDataBaseSettings settings)
        {
            var flitghs = new MongoClient(settings.ConnectionString);
            var DataBase = flitghs.GetDatabase(settings.DatabaseName);
            _flitghs = DataBase.GetCollection<Flitghs>(settings.FlightsCollectionName);

        }

        public Flitghs CreateFlitghs(Flitghs flitghs) 
        {
            _flitghs.InsertOne(flitghs); 
            return flitghs;
        }

        public List<Flitghs> GetAllFlitghs() => _flitghs.Find(flitghs => true).ToList();

        public void Update(string destiny, Flitghs flitghsin)
        {
            _flitghs.ReplaceOne(flitghs => flitghs.Destiny == destiny, flitghsin);
        }

        public void RemoveFlitghs(Flitghs flitghsin) => _flitghs.DeleteOne(flitghs => flitghs.Destiny == flitghs.Destiny);

        public Flitghs GetOneFlitghs(DateTime dateTime, string rabPlane, string destiny) => _flitghs.Find<Flitghs>(flitghs => flitghs.Departure == dateTime && flitghs.Plane == rabPlane && flitghs.Destiny == destiny).FirstOrDefault();

        
    }

}
