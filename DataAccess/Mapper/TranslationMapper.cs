using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TranslationMapper:EntityMapper,ISqlStatements,IObjectMapper
    {
        private const string DB_COL_ID_TRANSLATION = "ID_TRANSLATION";
        private const string DB_COL_TRANSLATION_AMOUNT = "TRANSLATION_AMOUNT";
        private const string DB_COL_WORD = "WORD";
        private const string DB_COL_TRANSLATED_DATE = "TRANSLATED_DATE";
        private const string DB_COL_TRANSLATED_WORD = "TRANSLATED_WORD";
        private const string DB_COL_FK_LANGUAUGE_ID = "FK_LANGUAUGE_ID";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_TRANSLATION_PR" };

            var c = (Translations)entity;
            operation.AddIntParam(DB_COL_TRANSLATION_AMOUNT, c.translationAmount);
            operation.AddVarcharParam(DB_COL_WORD, c.word);
            operation.AddDatetimeParam(DB_COL_TRANSLATED_DATE, c.translatedDate);
            operation.AddVarcharParam(DB_COL_TRANSLATED_WORD, c.translatedWord);
            operation.AddIntParam(DB_COL_FK_LANGUAUGE_ID, c.FkLanguagueId);
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_TRANSLATION_PR" };

            var c = (Translations)entity;
            operation.AddIntParam(DB_COL_FK_LANGUAUGE_ID, c.FkLanguagueId);
            operation.AddVarcharParam(DB_COL_TRANSLATED_WORD, c.word);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRANSLATION_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_TRANSLATION_PR" };

            var c = (Translations)entity;
            operation.AddVarcharParam(DB_COL_WORD, c.word);
            operation.AddIntParam(DB_COL_FK_LANGUAUGE_ID, c.FkLanguagueId);
            operation.AddVarcharParam(DB_COL_TRANSLATED_WORD, c.translatedWord);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_TRANSLATION_PR" };

            var c = (Translations)entity;
            operation.AddIntParam(DB_COL_ID_TRANSLATION, c.IdTranslation);
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
            var translation = new Translations
            {
                IdTranslation = GetIntValue(row, DB_COL_ID_TRANSLATION),
                translationAmount = GetIntValue(row, DB_COL_TRANSLATION_AMOUNT),
                word = GetStringValue(row, DB_COL_WORD),
                translatedDate = GetDateValue(row, DB_COL_TRANSLATED_DATE),
                translatedWord = GetStringValue(row, DB_COL_TRANSLATED_WORD),
                FkLanguagueId = GetIntValue(row, DB_COL_FK_LANGUAUGE_ID)
            };

            return translation;
        }
    }
}
