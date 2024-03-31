using Newtonsoft.Json;
using RichillCapital.SharedKernel.Diagnostics;

namespace RichillCapital.Okx;

public sealed class OkxClient
{
    private const string RestUrl = "https://www.okx.com/";
    private const string RestUrlDemo = "https://www.okx.com";

    private readonly string _apiKey;
    private readonly string _secretKey;
    private readonly string _passphrase;

    private readonly HttpClient _httpClient;

    public OkxClient(
        string apiKey,
        string secretKey,
        string passphrase)
    {
        Ensure.NotEmpty(apiKey);
        Ensure.NotEmpty(secretKey);
        Ensure.NotEmpty(passphrase);

        _apiKey = apiKey;
        _secretKey = secretKey;
        _passphrase = passphrase;

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(RestUrl),
        };
    }

    public async Task<DateTimeOffset> GetServerTimeAsync()
    {
        var response = await _httpClient.GetAsync(ApiRoutes.Public.Time.Get);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<OkxResponse<ServerTimeResponse>>(content);

        var timestamp = result!.Data.First().Timestamp;

        return DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
    }
}

internal static class ApiRoutes
{
    private const string ApiBase = "api/v5";

    internal static class Public
    {
        private const string PublicBase = $"{ApiBase}/public";

        internal static class Time
        {
            private const string TimeBase = $"{PublicBase}/time";
            internal const string Get = TimeBase;
        }
    }
}

public sealed record OkxResponse<TData>
{
    [JsonProperty("code")]
    public int Code { get; init; }

    [JsonProperty("msg")]
    public string Message { get; init; } = string.Empty;

    [JsonProperty("data")]
    public IEnumerable<TData> Data { get; init; } = default!;
}

public sealed record ServerTimeResponse
{
    [JsonProperty("ts")]
    public long Timestamp { get; init; }
}