using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class Address : Model
    {
        private string _branch;
        private string _address1;
        private string _address2;
        private City _city;
        private string _zipcode;
        private List<Phone> _phones; 
        private int _userId;
        private int _locationId;
        public Address()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public override int Id
        {
            get; set;
        }

        [DataMember]
        public string Branch
        {
            get
            {
                return _branch;
            }
            set
            {
                _branch = value;
            }
        }

        [DataMember]
        public string Address1
        {
            get
            {
                return _address1;
            }
            set
            {
                _address1 = value;
            }
        }

        [DataMember]
        public string Address2
        {
            get
            {
                return _address2;
            }
            set
            {
                _address2 = value;
            }
        }

        [DataMember]
        public City City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        [DataMember]
        public string Zipcode
        {
            get
            {
                return _zipcode;
            }
            set
            {
                _zipcode = value;
            }
        }

        [DataMember]
        public List<Phone> Phones
        {
            get
            {
                return _phones;
            }
            set
            {
                _phones = value;
            }
        }

        [DataMember]
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        [DataMember]
        public int LocationId
        {
            get
            {
                return _locationId;
            }
            set
            {
                _locationId = value;
            }
        }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        [ForeignKey("UserId")]
        [ScriptIgnore]
        public virtual User User { get; set; }

    }
}
