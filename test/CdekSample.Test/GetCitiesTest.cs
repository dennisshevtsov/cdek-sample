// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample.Test;

[TestClass]
public sealed class GetCitiesTest
{
#pragma warning disable CS8618
  private IDisposable _disposable;
  private HttpClient _httpClient;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    ServiceCollection services = new();
    services.AddAuthorizedHttpClient(apiClientName: "api")
            .UseHttpClientSettings(options =>
            {
              options.TokenBaseUrl = "https://api.edu.cdek.ru";
              options.GetTokenUrl  = "v2/oauth/token?parameters";
              options.ClientId     = "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI";
              options.ClientSecret = "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG";
              options.ApiBaseUrl   = "https://api.edu.cdek.ru";
            });

    IServiceScope scope = services.BuildServiceProvider().CreateScope();
    IHttpClientFactory factory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();

    _disposable = scope;
    _httpClient = factory.CreateClient("api");
  }

  [TestCleanup]
  public void Cleanup() => _disposable?.Dispose();

  [TestMethod]
  public async Task GetAsync_CityUrl_200Returned()
  {
    // Arrange
    string url = "v2/location/cities";

    // Act
    using HttpResponseMessage getCitiesResponseMessage = await _httpClient.GetAsync(url);

    // Assert
    Assert.AreEqual(HttpStatusCode.OK, getCitiesResponseMessage.StatusCode);
  }

  [TestMethod]
  public async Task GetAsync_CityUrl_CitiesReturned()
  {
    // Arrange
    string url = "v2/location/cities";

    // Act
    using HttpResponseMessage getCitiesResponseMessage = await _httpClient.GetAsync(url);
    CityResponse[]? cities = await getCitiesResponseMessage.Content.ReadFromJsonAsync<CityResponse[]>();

    // Assert
    Assert.IsNotNull(cities);
    Assert.IsTrue(cities.Length > 0);
  }

  [TestMethod]
  public void ToUri_NoParameters_UriReturned()
  {
    // Arrange
    CityRequest request = new();

    // Act
    string actual = request.ToUri();

    // Assert
    Assert.AreEqual(CityRequest.Route, actual);
  }

  [TestMethod]
  public void ToUri_CountryCodes_UriReturned()
  {
    // Arrange
    CityRequest request = new
    (
      CountryCodes: ["BY", "RU"]
    );

    // Act
    string actual = request.ToUri();

    // Assert
    string expected = $"{CityRequest.Route}?country_codes=BY&country_codes=RU";
    Assert.AreEqual(expected, actual);
  }
}
