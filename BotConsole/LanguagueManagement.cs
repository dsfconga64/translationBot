using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotConsole
{
    public class LanguagueManagement
    {
        private LanguagueCrudFactory crudLanguague;

        public LanguagueManagement()
        {
            crudLanguague = new LanguagueCrudFactory();
        }

        public void Create(Languague languague)
        {

            crudLanguague.Create(languague);

        }


        public List<Languague> RetrieveAll()
        {
            return crudLanguague.RetrieveAll<Languague>();
        }

        public Languague RetrieveById(Languague languague)
        {
            return crudLanguague.Retrieve<Languague>(languague);
        }

        internal void Update(Languague languague)
        {
            crudLanguague.Update(languague);
        }

        internal void Delete(Languague languague)
        {
            crudLanguague.Delete(languague);
        }
    }
}
