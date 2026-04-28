using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUTURE_POP.CORE
{
    public class Governorate
    {
        //Fields (Attributes)
        //Inputs
        protected string name;
        protected string capital;
        protected string type;
        public double [] popCount = new double[5];
        protected int area;
        //Calculated
        protected int popDensity;
        public double[] PopGrowthRate = new double[4] ;
        protected double avgGrowthRate;
        protected double avgGrowthRateDrop;
        protected int schoolNumber;
        protected int hospitalNumber;
        protected int policeNumber;
        //Predicted 
        public double[] PredGrowthRate = new double[2];
        public int[] PredPopCount = new int[2];
        //Properties
        public string Name  { get { return name; } }
        public string Capital  {get { return capital; }}
        public string Type  {get { return type; }}
        public int Area  {get { return area; }}
        public int PopDensity {get { return popDensity; }}
        public double AvgGrowthRate {get { return avgGrowthRate; }}
        public int SchoolNumber { get { return schoolNumber; } }
        public int HospitalNumber { get { return hospitalNumber; } }
        public int PoliceNumber { get { return policeNumber; } }
        //Methods
        public void CalculateDensity ()
        {
            double Density = popCount[4] / area;
            popDensity = (int)Density ;
        }
        public void CalculateGrowthRate()
        {
            double sum = 0;
            for (int i = 0; i < popCount.Length; i++)
            {
                if (i == popCount.Length - 1) break;
                PopGrowthRate[i] = (popCount[i + 1] - popCount[i]) / popCount[i];
            }
            for (int j = 0; j < PopGrowthRate.Length;  j++)
            {
                sum += PopGrowthRate[j];
            }
            avgGrowthRate = sum / PopGrowthRate.Length;
        }
        public void CalculateAverage()
        {
            double A1 = PopGrowthRate[1] - PopGrowthRate[0];
            double A2 = PopGrowthRate[2] - PopGrowthRate[1];
            double A3 = PopGrowthRate[3] - PopGrowthRate[2];
            avgGrowthRateDrop = (A1 + A2 + A3) / 3;
        }
        public void PredictNewPopGrowth()
        {
            PredGrowthRate[0] = PopGrowthRate[3] + avgGrowthRateDrop;          // Can be increased
            PredGrowthRate[1] = PredGrowthRate[0] + avgGrowthRateDrop;
        }
        public void PredictNewPopCount()
        {
            double Pop2028 = (1 + PredGrowthRate[0]) * popCount[4];
            double Pop2030 = (1 + PredGrowthRate[1]) * Pop2028;
            PredPopCount[0] = (int)Pop2028;
            PredPopCount[1] = (int)Pop2030;
        }
        public void PrintData()
        {
            Console.WriteLine("Name : " + name + " , Capital : " + capital + " , Type : " + type);
            Console.WriteLine("Pop Count : " + popCount[0] + "\t" + popCount[1] + "\t" + popCount[2] + "\t" + popCount[3] + "\t" + popCount[4] + "\t");
            Console.WriteLine("Density : " + PopDensity);
            Console.WriteLine("GrowthRate : " + PopGrowthRate[0] + "\t" + PopGrowthRate[1] + "\t" + PopGrowthRate[2] + "\t" + PopGrowthRate[3] + "\t") ;
            Console.WriteLine("Average GrowthRate : " + avgGrowthRate);
            Console.WriteLine("Average : " + avgGrowthRateDrop);
            Console.WriteLine("New GrowthRate : " + PredGrowthRate[0] + "\t" + PredGrowthRate[1]);
            Console.WriteLine("New PopCount : " + PredPopCount[0] + "\t" + PredPopCount[1]);
        }
        public virtual void ServiceRatio()
        {

        }
        public virtual void ShowData()
        {

        }
    }
    public class Urban : Governorate
    {
        //Fields
        double SchoolRatio = 10000;
        double HospitalRatio = 55000; 
        double PoliceRatio = 35000; 
        //Constructor
        public Urban (string name, string capital, int pop0, int pop1, int pop2, int pop3, int pop4, int area, string type)
        {
            this.name = name;
            this.capital = capital;
            this.type = type;
            popCount[0] = pop0;
            popCount[1] = pop1;
            popCount[2] = pop2;
            popCount[3] = pop3;
            popCount[4] = pop4;
            this.area = area;
        }
        //Methods
        public override void ServiceRatio()
        {
            double UrbanSchool = popCount[4] / SchoolRatio;
            schoolNumber = (int)UrbanSchool;
            double UrbanHospital = popCount[4] / HospitalRatio;
            hospitalNumber = (int)UrbanHospital;
            double UrbanPolice = popCount[4] / PoliceRatio;
            policeNumber = (int)UrbanPolice;
        }
        public override void ShowData()
        {
            Console.WriteLine("The number of needed schools is " + schoolNumber);
            Console.WriteLine("The number of needed hospitals is " + hospitalNumber);
            Console.WriteLine("The number of needed police stations is " + policeNumber);
        }
    }
    public class Rural : Governorate
    {
        //Fields
        double SchoolRatio = 4500;
        double HospitalRatio = 37500;
        double PoliceRatio = 26500;
        //Constructor
        public Rural (string name, string capital, int pop0, int pop1, int pop2, int pop3, int pop4, int area, string type)
        {
            this.name = name;
            this.capital = capital;
            this.type = type;
            popCount[0] = pop0;
            popCount[1] = pop1;
            popCount[2] = pop2;
            popCount[3] = pop3;
            popCount[4] = pop4;
            this.area = area;
        }
        //Methods
        public override void ServiceRatio()
        {
            double RuralSchool = popCount[4] / SchoolRatio;
            schoolNumber = (int)RuralSchool;
            double RuralHospital = popCount[4] / HospitalRatio;
            hospitalNumber = (int)RuralHospital;
            double RuralPolice = popCount[4] / PoliceRatio;
            policeNumber = (int)RuralPolice;
        }
    }
    public class Border : Governorate
    {
        //Fields
        double SchoolRatio = 3000;
        double HospitalRatio = 25000;
        double PoliceRatio = 17500;
        //Constructor
        public Border (string name, string capital, int pop0, int pop1, int pop2, int pop3, int pop4, int area, string type)
        {
            this.name = name;
            this.capital = capital;
            this.type = type;
            popCount[0] = pop0;
            popCount[1] = pop1;
            popCount[2] = pop2;
            popCount[3] = pop3;
            popCount[4] = pop4;
            this.area = area;
        }
        //Methods
        public override void ServiceRatio()
        {
            double BorderSchool = popCount[4] / SchoolRatio;
            schoolNumber = (int)BorderSchool;
            double BorderHospital = popCount[4] / HospitalRatio;
            hospitalNumber = (int)BorderHospital;
            double BorderPolice = popCount[4] / PoliceRatio;
            policeNumber = (int)BorderPolice;
        }
    }
    public class Mixed : Governorate
    {
        //Fields
        double SchoolRatio = 7500;
        double HospitalRatio = 42500;
        double PoliceRatio = 31000;
        //Constructor
        public Mixed (string name, string capital, int pop0, int pop1, int pop2, int pop3, int pop4, int area, string type)
        {
            this.name = name;
            this.capital = capital;
            this.type = type;
            popCount[0] = pop0;
            popCount[1] = pop1;
            popCount[2] = pop2;
            popCount[3] = pop3;
            popCount[4] = pop4;
            this.area = area;
        }
        //Methods
        public override void ServiceRatio()
        {
            double MixedSchool = popCount[4] / SchoolRatio;
            schoolNumber = (int)MixedSchool;
            double MixedHospital = popCount[4] / HospitalRatio;
            hospitalNumber = (int)MixedHospital;
            double MixedPolice = popCount[4] / PoliceRatio;
            policeNumber = (int)MixedPolice;
        }
    }
}
