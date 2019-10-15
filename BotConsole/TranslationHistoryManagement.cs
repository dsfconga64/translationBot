using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotConsole
{
    public class TranslationHistoryManagement
    {
        private TranslationHistoryCrudFactory crudTranslationHistory;

        public TranslationHistoryManagement()
        {
            crudTranslationHistory = new TranslationHistoryCrudFactory();
        }

        public void Create(TranslationsHistory translationHistory)
        {

            crudTranslationHistory.Create(translationHistory);

        }
        public List<TranslationsHistory> RetrieveAll()
        {
            return crudTranslationHistory.RetrieveAll<TranslationsHistory>();
        }

        public TranslationsHistory RetrieveById(TranslationsHistory translationsHistory)
        {
            return crudTranslationHistory.Retrieve<TranslationsHistory>(translationsHistory);
        }

        internal void Update(TranslationsHistory translationsHistory)
        {
            crudTranslationHistory.Update(translationsHistory);
        }

        internal void Delete(TranslationsHistory translationsHistory)
        {
            crudTranslationHistory.Delete(translationsHistory);
        }

        public List<TranslationsHistory> RetrieveTopHundredWords()
        {
            return crudTranslationHistory.RetrieveHundredMostUsedWords<TranslationsHistory>();
        }
    }
}
