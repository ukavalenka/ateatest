using System;
using System.Collections.Generic;
using System.Text;

namespace ATEATECHNICAL.Utils.Models
{
    public class ArgumentsModel : BaseModel
    {
        public string Arg1 { get; set; }
        public string Arg2 { get; set; }

        public ArgumentsModel() { }

        public ArgumentsModel(string arg1, string arg2)
        {
            Arg1 = arg1;
            Arg2 = arg2;
        }

        public ArgumentsModel(int id, string arg1, string arg2)
        {
            Arg1 = arg1;
            Arg2 = arg2;
            Id = id;
        }

        public ArgumentsModel(ArgumentsModel model)
        {
            Arg1 = model.Arg1;
            Arg2 = model.Arg2;
            Id = model.Id;
        }
    }
}
