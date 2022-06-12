using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqeCodeGenerator.DataAccess.Bases;

namespace UniqeCodeGenerator.DataAccess.Entites
{
    public class UniqeCode : RecordBase
    {
        public string Code { get; set; }
    }
}
