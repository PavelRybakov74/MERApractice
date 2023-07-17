using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shop.Data.Models
{
    public class Device {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("shortDesc")]
        public string shortDesc { get; set; }

        [BsonElement("img")]
        public string img { get; set; }

        [BsonElement("price")]
        public ushort price { get; set; }

        [BsonElement("category")]
        public string category { get; set; }

        /*public static implicit operator List<object>(Device v)
        {
            throw new NotImplementedException();
        }*/
    }
}
