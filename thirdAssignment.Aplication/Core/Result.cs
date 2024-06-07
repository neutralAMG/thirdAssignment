

namespace thirdAssignment.Aplication.Core
{
    public class Result<T> where T : class
    {
        public Result()
        {
            IsSuccess = true; 
        }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
