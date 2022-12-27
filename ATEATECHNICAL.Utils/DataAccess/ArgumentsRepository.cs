using ATEATECHNICAL.Utils.Interfaces;
using ATEATECHNICAL.Utils.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;

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
        }
        

        public IEnumerable<ArgumentsModel> GetAll()
        {
            var collection = _liteDatabase.GetCollection<ArgumentsModel>();

            return collection.FindAll();
        }

        public ArgumentsModel Insert(ArgumentsModel entity)
        {
            var collection = _liteDatabase.GetCollection<ArgumentsModel>();

            collection.Insert(entity);

            return entity;
        }

        public void Dispose()
        {
            _liteDatabase.Dispose();
        }
    }
}
