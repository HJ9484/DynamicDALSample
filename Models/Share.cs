using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDALSample.Models
{
    //You have to add this CustomeAttributes on your Entity
    [DynamicDAL.CustomAttributes.Name(EntityName = "Share", TableName = "Share")]
    public class Share
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Namad { get; set; }

    }
    public class ShareConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Share>
    {
        public ShareConfiguration()
        {
            ToTable("Share");
        }
    }
}
