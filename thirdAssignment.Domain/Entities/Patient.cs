﻿

using thirdAssignment.Domain.Core;

namespace thirdAssignment.Domain.Entities
{
    public class Patient : BaseNonUserLikeEntity
    {
        public Patient()
        {

        }
        public string Address { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasAllergies { get; set; }
        public DateOnly BirthDate { get; set; }
        public IList<Appointment> appointments { get; set; }
    }
}
