using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Languague:BaseEntity
    {
        public int IdLanguague { get; set; }
        public string languague { get; set; }

        public Languague() { }
        public Languague(string planguague)
        {
            languague = planguague;
        }
    }
}
