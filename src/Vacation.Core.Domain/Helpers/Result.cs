
namespace Vacation.Core.Domain.Helpers
{
    public class Result<T>
    {
        public bool IsSuccess { get { return Errors.Count == 0; } }

        public List<string> Errors { get; set; } = new List<string>();

        public T Data { get; set; }

        public void Merge(Result<T> result)
        {
            if (result.Data != null)
            {
                Data = result.Data;
            }
            Errors.AddRange(result.Errors);
        }

        public string GetErrorsString()
        {
            return string.Join(',', Errors);
        }

        public Result<T> AddError(string err)
        {
            this.Errors.Add(err);
            return this;
        }
    }
}