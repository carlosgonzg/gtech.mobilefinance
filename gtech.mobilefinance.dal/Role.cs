using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class Role : Model
    {
        private string _description;

        public Role()
        {
            _description = "";
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public override int Id
        {
            get; set;
        }
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}