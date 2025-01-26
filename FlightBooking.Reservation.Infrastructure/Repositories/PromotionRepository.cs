using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using FlightBooking.Reservation.Domain.Entities;

namespace FlightBooking.Reservation.Infrastructure.Repositories
{
    /// <summary>
    /// Class responsible for changing data on Promotion Repository
    /// </summary>
    public class PromotionRepository : RepositoryBase<Promotion>
    {
        public PromotionRepository()
        {
            this.Seed();
        }

        /// <summary>
        /// Used to seed the Flight Repository with initial data
        /// </summary>
        private void Seed()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "FlightBooking.Reservation.Infrastructure.InitalStatePromotion.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    var initialList = JsonConvert.DeserializeObject<List<Promotion>>(json, new JsonSerializerSettings
                    {
                        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });

                    this.collection.AddRange(initialList);
                }
            }
        }
    }
}
