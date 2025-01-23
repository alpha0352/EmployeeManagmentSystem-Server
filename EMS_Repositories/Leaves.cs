using System.Xml.Serialization;

namespace EMS_Repositories
{
    public class Leaves
    {
        [XmlElement] public int m_CasualLeaves { get; set; }
        [XmlElement] public int m_SickLeaves { get; set; }
        [XmlElement] public int m_ApprovedLeaves { get; set; }
        [XmlElement] public int m_TotalAvailedLeaves { get; set; }
        [XmlElement] public int m_BalanceLeaves { get; set; }


        public Leaves() { }
        public Leaves(int casualLeaves,int sickLeaves, int approvedLeaves)
        {
            this.m_CasualLeaves = casualLeaves;
            this.m_SickLeaves = sickLeaves;
            this.m_ApprovedLeaves = approvedLeaves;
            this.m_TotalAvailedLeaves = 0; //initially zero
            this.m_BalanceLeaves = casualLeaves + sickLeaves - approvedLeaves;
        }
    }


}