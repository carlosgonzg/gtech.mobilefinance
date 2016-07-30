using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class PhoneType : Model
    {
        private string _description;

        //constructor
        public PhoneType()
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
    }
}