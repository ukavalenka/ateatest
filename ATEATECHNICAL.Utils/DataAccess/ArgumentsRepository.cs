using ATEATECHNICAL.Utils.Interfaces;
using ATEATECHNICAL.Utils.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ATEATECHNICAL.Utils.DataAccess
{
    public class ArgumentsRepository : IRepository<ArgumentsModel>
    {
        private string _databasefilename = "AgrumentsDb.db";
        private ILogger _logger;
        private LiteDatabase _liteDatabase;

        public ArgumentsRepository(ILogger logger)
        {
            _logger = logger;

            var path = Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), _databasefilename);
            try
            {
                _liteDatabase = new LiteDatabase(path);
            } 
            catch (Exception ex)
            {
                _logger.Log($"Cannot open database {ex.Message}");
            }
            
            

            //if (databaseFilename != null) _databaseFileName = databaseFilename;
            //_databaseFilePath = Path.Combine(Utilities.GetExecutableDirectoryPath(), _databaseFileName);

            //if (!File.Exists(_databaseFilePath)) CreateDatabase(_databaseFilePath);

            //try
            //{
            //    _connection = new SQLiteConnection($"Data Source={_databaseFilePath}; Version=3;");
            //    _connection.Open();
            //}
            //catch (Exception e)
            //{
            //    _logger.LogError($"Wasn't able to open database connection. Message: {e.Message}");
            //}
        }
        

        public IEnumerable<ArgumentsModel> GetAll()
        {
            var collection = _liteDatabase.GetCollection<ArgumentsModel>();

            return collection.FindAll();
        }

        public void Insert(ArgumentsModel entity)
        {
            var collection = _liteDatabase.GetCollection<ArgumentsModel>();

            collection.Insert(entity);
        }

        public void Dispose()
        {
            _liteDatabase.Dispose();
        }
    }
}
