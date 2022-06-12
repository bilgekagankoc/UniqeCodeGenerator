using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqeCodeGenerator.Models
{
    public class RandomNumberModel
    {
        public RandomNumberModel()
        {
            randomNumbers = new List<int>();
        }
        public List<int> randomNumbers { get; set; }
        public int randomNumber { get; set; }
    }
}
