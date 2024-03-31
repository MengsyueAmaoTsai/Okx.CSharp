namespace RichillCapital.Okx;

public sealed class OkxClient
{
    private const string RestUrl = "https://www.okx.com/";
    private const string RestUrlDemo = "https://www.okx.com";

    private readonly HttpClient _httpClient;

    public OkxClient(
        string apiKey, 
        string secretKey, 
        string passphrase)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(RestUrl),
        };
    }
}
