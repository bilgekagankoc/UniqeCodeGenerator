using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqeCodeGenerator.Models;

namespace UniqeCodeGenerator.Business
{
    public interface ICreateCode
    {
        List<int> GenerateRandomNumber(Enums.GeneratorType type, int count = 0);
    }
    public class CreateCode : ICreateCode
    {
        public List<int> GenerateRandomNumber(Enums.GeneratorType type, int count = 0)
        {
            RandomNumberModel codeModel = new RandomNumberModel();
            Random rnd = new Random();
            if (type == Enums.GeneratorType.Number)
            {
                codeModel.randomNumber = rnd.Next(0, 6);
                codeModel.randomNumbers.Add(codeModel.randomNumber);
                return codeModel.randomNumbers;
            }
            else if (type == Enums.GeneratorType.Letters)
            {
                codeModel.randomNumber = rnd.Next(6, 23);
                codeModel.randomNumbers.Add(codeModel.randomNumber);
                return codeModel.randomNumbers;
            }
            //sadece 0 dönüyor. ihtiyaca göre değişebilir.
            else if (type == Enums.GeneratorType.ZeroOrTwo)
            {
                codeModel.randomNumber = 0;
                codeModel.randomNumbers.Add(codeModel.randomNumber);
                return codeModel.randomNumbers;

            }
            else if (type == Enums.GeneratorType.Any)
            {
                for (int i = 0; i < count; i++)
                {
                    codeModel.randomNumber = rnd.Next(0, 23);
                    codeModel.randomNumbers.Add(codeModel.randomNumber);
                }
                return codeModel.randomNumbers;
            }
            return null;
        }
    }
}
