namespace QTSocialSecurity5.Logic.Modules.Exceptions
{
    public enum ErrorType : int
    {
        InitAppAccess,
        InvalidAccount,
        InvalidIdentityName,

        InvalidToken,
        InvalidSessionToken,
        InvalidJsonWebToken,

        InvalidEmail,
        InvalidPassword,
        NotLogedIn,
        NotAuthorized,
        AuthorizationTimeOut,
        InvalidId,
        InvalidPageSize,

        InvalidEntityInsert,
        InvalidEntityUpdate,
        InvalidEntityContent,

        InvalidControllerType,
        InvalidControllerObject,

        InvalidFacadeType,
        InvalidFacadeObject,

        InvalidOperation,
    }
}