using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;
using System.Globalization;

namespace CleanArchitecture.Core.Entities
{
    public class Mission : BaseEntity
    {
        public Mission() { }

        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string Address
        {
            get { return this._address; }
            set { _address = new CultureInfo("nb-NO", false).TextInfo.ToTitleCase(value); }
        }

        private string _address;
        public List<MissionImage> MissionImages { get; set; }

        public List<MissionNote> MissionNotes { get; set; }
        public MissionType MissionType { get; set; }
        public int? MissionTypeId { get; set; }
        public Employer Employer { get; set; }
        public int? EmployerId { get; set; }

    }
}
