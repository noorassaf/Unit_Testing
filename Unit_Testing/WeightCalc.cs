using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing
{
    public class WeightCalc
    {
        private readonly IWeightRepo weightRepo;

        public WeightCalc(IWeightRepo weightRepo)
        {
            this.weightRepo = weightRepo;
        }
        public WeightCalc()
        {
            
        }
        public double height { get; set; }
        public char sexe { get; set; }
        public double getweight()
        {
            switch (sexe)
            {
                case 'm': 
                    return (height-100)-((height-150)/4);
                case 'w':
                    return (height - 100) - ((height - 150) / 2);
                default :
                    throw new ArgumentException("the sex is not vaild");
            }
        }
        public bool vaildate()
        {
            return sexe=='m'||sexe=='w';
        }
        public List<double> getweightsFromDataSource()
        {
            List<double> result = new List<double>();
            
            
            IEnumerable<WeightCalc> weights = weightRepo.getWeights();

            foreach (var weight in weights)
            {
                result.Add(weight.getweight());
            }
            return result;
        }
    }
}
