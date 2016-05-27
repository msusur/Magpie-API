namespace Magpie.Library.Http
{
    public class CallResponse<TResponseModelType>
    {
        public HttpCall Call { get; set; }

        public TResponseModelType Response { get; set; }

        public string ResponseCode { get; set; }

        public CallResponse ConvertToResponse()
        {
            return new CallResponse { Call = Call, Response = Response as GenericDataModel, ResponseCode = ResponseCode };
        }
    }

    public class CallResponse : CallResponse<GenericDataModel>
    {

    }

    public class GenericDataModel
    {
    }
}
