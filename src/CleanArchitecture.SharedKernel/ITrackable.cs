using System;

namespace CleanArchitecture.SharedKernel
{
    public interface ITrackable
    {
        //Auto tracking properties
        bool Deleted { get; set; }
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
        string UpdatedBy { get; set; }
    }
}
