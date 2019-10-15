using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class LanguagueMapper: EntityMapper,ISqlStatements,IObjectMapper
    {
        private const string DB_COL_ID_LANGUAGUE = "ID_LANGUAGUE";
        private const string DB_COL_LANGUAGUE = "LANGUAGUE";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_LANGUAGUE_PR" };

            var c = (Languague)entity;
            operation.AddVarcharParam(DB_COL_LANGUAGUE, c.languague);
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_LANGUAGUE_PR" };

            var c = (Languague)entity;
            operation.AddVarcharParam(DB_COL_LANGUAGUE, c.languague);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LANGUAGUE_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_LANGUAGUE_PR" };

            var c = (Languague)entity;
            operation.AddVarcharParam(DB_COL_LANGUAGUE, c.languague);
           

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_LANGUAGUE_PR" };

            var c = (Languague)entity;
            operation.AddIntParam(DB_COL_ID_LANGUAGUE, c.IdLanguague);
            return operation;
        }

        public SqlOperation GetRetrieveMostPopularLanguague()
        {
            var operation = new SqlOperation { ProcedureName = "RET_MOST_POPULAR_LANGUAGUE" };
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var languague = new Languague
            {
                IdLanguague = GetIntValue(row, DB_COL_ID_LANGUAGUE),
                languague = GetStringValue(row, DB_COL_LANGUAGUE)
            };

            return languague;
        }

        public BaseEntity BuildMostUsedLanguague(Dictionary<string, object> row)
        {
            var languague = new Languague
            {
                languague = GetStringValue(row, DB_COL_LANGUAGUE)
            };

            return languague;
        }
    }
}
