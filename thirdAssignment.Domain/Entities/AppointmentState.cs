

namespace thirdAssignment.Domain.Entities
{
    public class AppointmentState
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public IList<Appointment> appointments { get; set; }
    }
}
