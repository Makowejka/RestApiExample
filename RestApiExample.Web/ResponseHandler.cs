namespace RestApiExample.Web.Model;

public class ResponseHandler
{
    public static ApiResponse GetExceptionResponse(Exception ex)
    {
        ApiResponse response = new ApiResponse();
        response.Code = "1";
        response.ResponseData = ex.Message;
        return response;
    }

    public static ApiResponse GetAppResponse(ApiResponse.ResponseType type, object? contract)
    {
        ApiResponse response;

        response = new ApiResponse();

        switch (type)
        {
            case ApiResponse.ResponseType.Success:
                response.Code = "0";
                response.Message = "Success";
                response.ResponseData = contract;
                break;

            case ApiResponse.ResponseType.NotFound:
                response.Code = "2";
                response.Message = "No record available";
                break;
        }

        return response;
    }
}