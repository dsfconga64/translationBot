using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotConsole
{
    public class TranslationManagement
    {
        private TranslationCrudFactory crudTranslation;

        public TranslationManagement()
        {
            crudTranslation = new TranslationCrudFactory();
        }

        public void Create(Translations translation)
        {

            crudTranslation.Create(translation);

        }
        public List<Translations> RetrieveAll()
        {
            return crudTranslation.RetrieveAll<Translations>();
        }

        public Translations RetrieveById(Translations translations)
        {
            return crudTranslation.Retrieve<Translations>(translations);
        }

        internal void Update(Translations translations)
        {
            crudTranslation.Update(translations);
        }

        internal void Delete(Translations translations)
        {
            crudTranslation.Delete(translations);
        }
    }
}
