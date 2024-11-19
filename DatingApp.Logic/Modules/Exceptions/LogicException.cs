namespace QTSocialSecurity5.Logic.Modules.Exceptions
{
    /// <summary>
    /// Represents errors encountered while running the application.
    /// </summary>
    public partial class LogicException : Exception
    {
        public int ErrorId {get;} = -1;


        /// <summary>
        /// Initializes a new instance of the LogicException class with a specified error message.
        /// </summary>
        /// <param name="errorType">Identification of the error message.</param>
        /// <param name="message">The message that describes the error.</param>
        public LogicException(ErrorType errorType, string message)
            : base(message)
        {
            ErrorId = (int)errorType;
        }

        /// <summary>
        /// Initializes a new instance of the LogicException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LogicException(string? message) 
            : base(message)
        {
        }     
    }
}