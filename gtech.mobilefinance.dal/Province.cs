using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class Province : Model
    {
        private string _description;
        private int _countryId;

        //constructor
        public Province()
        {
            _description = "";
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
            get { return _description; }
            set { _description = value; }
        }

        //property Country
        [DataMember]
        public int CountryId
        {
            get { return _countryId; }
            set { _countryId = value; }
        }

        [ForeignKey("CountryId")]
        [ScriptIgnore]
        public virtual Country Country { get; set; }

        //property Cities
        [NotMapped]
        public virtual ICollection<City> Cities { get; set; }
    }
}