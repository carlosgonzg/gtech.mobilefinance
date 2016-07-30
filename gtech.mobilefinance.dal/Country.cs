using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class Country : Model
    {
        private string _description;

        //constructor
        public Country()
        {
            _id = 0;
            this._description = "";
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public override int Id
        {
            get; set;
        }

        //property Description
        [MaxLength(100)]
        [DataMember]
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        //property Provinces
        [NotMapped]
        public virtual ICollection<Province> Provinces { get; set; }

        public override void Validate()
        {
            if (Description == "")
            {
                throw new Exception("Invalid Data");
            }
        }
    }
}