using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class Location : Model
    {
        private double _latitude;
        private double _longitude;
        public Location()
        {

        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public override int Id
        {
            get; set;
        }
        [DataMember]
        public double Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; }
        }
        [DataMember]
        public double Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; }
        }
    }
}
