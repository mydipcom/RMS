//Contributor:  Nicholas Mayne


namespace Rms.Services.Authentication.External
{
    public partial interface IClaimsTranslator<T>
    {
        UserClaims Translate(T response);
    }
}