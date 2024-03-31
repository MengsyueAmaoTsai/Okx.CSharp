using RichillCapital.Okx;

var apiKey = "your-api-key";
var secretKey = "your-secret";
var passphrase = "your-passphrase";

var client = new OkxClient(apiKey, secretKey, passphrase);

var serverTime = await client.GetServerTimeAsync();
Console.WriteLine($"{serverTime:yyyy-MM-dd HH:mm:ss.fff}");