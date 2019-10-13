using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UserMapper: EntityMapper, ISqlStatements,IObjectMapper
    {
        private const string DB_COL_ID_USER = "ID_USER";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_TRANSLATED_WORDS_AMOUNT = "TRANSLATED_WORDS_AMOUNT";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USER_PR" };

            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddIntParam(DB_COL_TRANSLATED_WORDS_AMOUNT, c.amountTranslatedWords);
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_PR" };

            var c = (User)entity;
            operation.AddIntParam(DB_COL_ID_USER, c.IdUser);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USER_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USER_PR" };

            var c = (User)entity;
            operation.AddIntParam(DB_COL_ID_USER, c.IdUser);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddIntParam(DB_COL_TRANSLATED_WORDS_AMOUNT, c.amountTranslatedWords);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var c = (User)entity;
            operation.AddIntParam(DB_COL_ID_USER, c.IdUser);
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
            var user = new User
            {
                IdUser = GetIntValue(row, DB_COL_ID_USER),
                Name = GetStringValue(row, DB_COL_NAME),
                amountTranslatedWords = GetIntValue(row,DB_COL_TRANSLATED_WORDS_AMOUNT)
            };

            return user;
        }
    }
}
