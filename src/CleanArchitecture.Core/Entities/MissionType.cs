using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class MissionType : BaseEntity
    {
        public MissionType() { }
        public string Name { get; set; }
        public List<Mission> Missions { get; set; }
    }
}
