﻿


using System.ComponentModel.DataAnnotations;

namespace thirdAssignment.Aplication.Models.LabTest
{
    public class LabTestModel
    {
        [Required(ErrorMessage = "the name is a requierd field")]
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string? Description { get; set; }

    }
}
