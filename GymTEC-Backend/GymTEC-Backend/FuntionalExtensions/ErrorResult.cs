namespace GymTEC_Backend.FuntionalExtensions
{
    public class ErrorResult
    {
        public ErrorTypes ErrorType { get; }
        public string ErrorMessage { get; }
        private ErrorResult(ErrorTypes errorTypes, string error)
        {
            ErrorType = errorTypes;
            ErrorMessage = error;
        }

        public static ErrorResult TypedError(ErrorTypes errorTypes, string errorMessage = "") =>
            new ErrorResult(errorTypes, errorMessage);

        public static ErrorResult StringError(ErrorTypes errorTypes, string errorMessage) =>
            new ErrorResult(errorTypes, errorMessage);
    }
}
