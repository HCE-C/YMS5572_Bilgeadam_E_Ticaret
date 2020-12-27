namespace E_Ticaret.Common.Client.Models
{
    public class WebApiResponse<T>
    {
        public string ResultMessage { get; set; }
        public bool IsSuccess { get; set; }
        public T ResultData { get; set; }

        public WebApiResponse()
        {

        }
        public WebApiResponse(string resultMessage, bool isSuccess)
        {
            ResultMessage = resultMessage ;
            IsSuccess = isSuccess;

        }
        public WebApiResponse(string resultMessage, bool isSuccess, T resultData)
        {
            ResultMessage = resultMessage;
            IsSuccess = isSuccess;
            ResultData = resultData;
        }
    }
}
