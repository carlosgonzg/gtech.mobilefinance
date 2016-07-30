using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace gtech.mobilefinance.dal
{
    [DataContract]
    public class Photo : Model
    {
        private int _userId;
        private string _image;
        public Photo()
        {

        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public override int Id
        {
            get; set;
        }
        [DataMember]
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
