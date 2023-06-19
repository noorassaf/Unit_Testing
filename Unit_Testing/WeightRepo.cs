using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing
{
    public class WeightRepo:IWeightRepo
    {
        IEnumerable<WeightCalc> Weights { get; set; }
        public WeightRepo()
        {
            Weights = new List<WeightCalc>() { 
                new WeightCalc {height=175,sexe='w'},
                new WeightCalc {height=167,sexe='m'},
                new WeightCalc {height=182,sexe='m'},
            };
        }
        public IEnumerable<WeightCalc> getWeights()
        {
            return Weights;
        }
    }
}
