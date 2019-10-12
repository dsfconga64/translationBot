using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Translations:BaseEntity
    {
        public int IdTranslation { get; set; }
        public int translationAmount { get; set; }
        public string word { get; set; }
        public DateTime translatedDate { get; set; }
        public string translatedWord { get; set; }
        public int FkLanguagueId { get; set; }

    }
}
