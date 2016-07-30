using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class User : Model
    {
        private string _username;
        private string _password;
        private int _roleId;
        private int? _photoId;
        private List<Address> _addresses;

        //constructor
        public User()
        {
            //this.Id = ;
            this._username = "";
            this._password = "";
            _addresses = new List<Address>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public override int Id
        {
            get; set;
        }
        //property Username
        [Index(IsUnique = true)]
        [MaxLength(50)]
        [DataMember]
        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }
        [DataMember]
        [DataType(DataType.Password)]
        //property Password
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }
        [DataMember]
        //property CategoryId
        public int RoleId
        {
            get { return this._roleId; }
            set { this._roleId = value; }
        }
        [DataMember]
        //property PhotoId
        public int? PhotoId
        {
            get { return this._photoId; }
            set { this._photoId = value; }
        }
        [DataMember]
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        [DataMember]
        [ForeignKey("PhotoId")]
        public virtual Photo ProfilePicture { get; set; }
        [DataMember]
        public virtual ICollection<Address> Addresses { get; set; }

        public override void Validate()
        {
            if (Role == null || _addresses == null || _username == "")
            {
                throw new Exception("Invalid Data");
            }
        }
    }
}
