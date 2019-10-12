using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    class TranslationsHistory
    {
        public int translationHistoryId { get; set; }
        public string word { get; set; }
        public DateTime translatedDate { get; set; }
        public string translatedWord { get; set; }
        public int FkLanguagueId { get; set; }
        public int FkUserId { get; set; }
    }
}
