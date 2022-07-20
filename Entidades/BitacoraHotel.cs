using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entidades
{
    public class BitacoraHotel
    {
        #region Propiedad

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NumeroRegistro")]
        public int NumeroRegistro { get; set; }

        [BsonElement("FechaRegistro")]
        public DateTime FechaRegistro { get; set; }

        [BsonElement("ObservacionAccion")]
        public string ObservacionAccion { get; set; }

        #endregion

        #region Constructor

        public BitacoraHotel()
        {
            Id = string.Empty;
            NumeroRegistro = 0;
            FechaRegistro = DateTime.MinValue;
            ObservacionAccion = string.Empty;
        }

        #endregion
    }
}
