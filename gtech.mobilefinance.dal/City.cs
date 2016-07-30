using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class City : Model
    {
        private string _description;
        private int _provinceId;

        //constructor
        public City()
        {
            this._description = "";
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public override int Id
        {
            get; set;
        }

        //property Description
        [DataMember]
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        //property Country
        [DataMember]
        public int ProvinceId
        {
            get { return this._provinceId; }
            set { this._provinceId = value; }
        }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }
    }
}