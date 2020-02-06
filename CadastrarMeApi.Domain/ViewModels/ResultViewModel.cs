namespace CadastrarMeApi.Domain.ViewModels
{
    public class ResultViewModel : IResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}