using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqeCodeGenerator.Models
{
    public class CodeModel
    {
        public CodeModel()
        {
            CharList = new List<char> { '2', '3', '4', '5', '7', '9', 'A', 'B', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z' };
            CurrentUniqeCode = new List<char>();
            TotalUniceCodeList = new List<string>();
        }
        public List<char> CharList { get; set; }
        public List<char> CurrentUniqeCode { get; set; }
        public List<string> TotalUniceCodeList { get; set; }
        public List<int> RandomNumber { get; set; }
        public int TotalFirstSix { get; set; }
    }
}
