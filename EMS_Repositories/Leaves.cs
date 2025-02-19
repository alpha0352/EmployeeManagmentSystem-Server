using System.Reflection;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public class Leaves
    {
        [XmlElement] public int? CasualLeaves { get; set; }
        [XmlElement] public int? SickLeaves { get; set; }
        [XmlElement] public int? AnnualLeaves { get; set; }
        [XmlElement] public int? ApprovedLeaves { get; set; }
        [XmlElement] public int? AvailedLeaves { get; set; }  
        [XmlElement] public int? BalanceLeaves { get; set; }
                               

        public Leaves() { }
        public Leaves(int casualLeaves,int sickLeaves, int annualLeaves)
        {
            this.CasualLeaves = casualLeaves;
            this.SickLeaves = sickLeaves;
            this.AnnualLeaves = annualLeaves;
            this.ApprovedLeaves = 0;
            this.AvailedLeaves = 0; //initially zero
            this.BalanceLeaves = casualLeaves + sickLeaves;
        }
    }


}