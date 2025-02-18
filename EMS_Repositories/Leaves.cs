using System.Reflection;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public class Leaves
    {
        [XmlElement] public int? m_nCasualLeaves { get; set; }
        [XmlElement] public int? m_nSickLeaves { get; set; }
        [XmlElement] public int? m_nAnnualLeaves { get; set; }
        [XmlElement] public int? m_nApprovedLeaves { get; set; }
        [XmlElement] public int? m_nTotalAvailedLeaves { get; set; }  
        [XmlElement] public int? m_nBalanceLeaves { get; set; }
                               

        public Leaves() { }
        public Leaves(int casualLeaves,int sickLeaves, int annualLeaves)
        {
            this.m_nCasualLeaves = casualLeaves;
            this.m_nSickLeaves = sickLeaves;
            this.m_nAnnualLeaves = annualLeaves;
            this.m_nApprovedLeaves = 0;
            this.m_nTotalAvailedLeaves = 0; //initially zero
            this.m_nBalanceLeaves = casualLeaves + sickLeaves;
        }
    }


}