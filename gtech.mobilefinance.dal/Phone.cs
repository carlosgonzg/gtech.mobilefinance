using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class Phone : Model
    {
        private int _typeId;
        private string _number;

        //constructor
        public Phone()
        {
            this._typeId = 0;
            this._number = "";
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public override int Id
        {
            get; set;
        }
        //Property Type
        [DataMember]
        public int TypeId
        {
            get { return this._typeId; }
            set { this._typeId = value; }
        }

        //Property Number
        [DataMember]
        public string Number
        {
            get { return this._number; }
            set { this._number = value; }
        }
        [DataMember]
        [ForeignKey("TypeId")]
        public virtual PhoneType PhoneType { get; set; }
    }
}