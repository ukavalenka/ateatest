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
        

        public List<ArgumentsModel> GetAll()
        {
            var result = new List<ArgumentsModel>();

            try
            {
                var collection = _liteDatabase.GetCollection<ArgumentsModel>();
                foreach(var element in collection.FindAll())
                {
                    result.Add(element);
                };
            }
            catch(Exception ex)
            {
                _logger.Log($"Cannot read arguments from database. {ex.Message}");
            }
            

            return result;
        }

        public ArgumentsModel Insert(ArgumentsModel entity)
        {
            var result = new ArgumentsModel(entity);

            try
            {
                var collection = _liteDatabase.GetCollection<ArgumentsModel>();
                result.Id = collection.Insert(entity).AsInt32;
            }
            catch (Exception ex)
            {
                _logger.Log($"Cannot insert argument to database. {ex.Message}");
            }

            return result;
        }

        public void Dispose()
        {
            _liteDatabase.Dispose();
        }
    }
}
