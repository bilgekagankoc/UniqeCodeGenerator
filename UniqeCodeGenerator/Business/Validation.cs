using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqeCodeGenerator.Business
{
    public interface IValidation
    {
        bool CheckCode(string code);
    }
    public class Validation : IValidation
    {
        public bool CheckCode(string code)
        {
            List<char> CharList = new List<char> { '2', '3', '4', '5', '7', '9', 'A', 'B', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z' };
            List<char> CharListNumber = new List<char> { '2', '3', '4', '5', '7', '9' };
            List<char> CharListLetter = new List<char> { 'A', 'B', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z' };
            if (code.Length != 8)
            {
                return false;
            }
            code = code.ToUpper();
            if (!CharListLetter.Contains(code[0]))
            {
                return false;
            }
            if (!CharListNumber.Contains(code[1]))
            {
                return false;
            }
            var totalSixCharAsciiCode = Convert.ToChar(code[0]) + Convert.ToChar(code[1]) + Convert.ToChar(code[2]) + Convert.ToChar(code[3]) + Convert.ToChar(code[4]) + Convert.ToChar(code[5]);
            var mod23 = totalSixCharAsciiCode % 23;
            if (CharList[mod23] != code[6])
            {
                return false;
            }
            if (Convert.ToChar(code[7]) != '2')
            {
                return false;
            }
            return true ;
        }
    }
}
