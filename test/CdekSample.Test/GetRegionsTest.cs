// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample.Test;

[TestClass]
public sealed class GetRegionsTest
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
              options.GetTokenUrl = "v2/oauth/token?parameters";
              options.ClientId = "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI";
              options.ClientSecret = "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG";
              options.ApiBaseUrl = "https://api.edu.cdek.ru";
            });

    IServiceScope scope = services.BuildServiceProvider().CreateScope();
    IHttpClientFactory factory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();

    _disposable = scope;
    _httpClient = factory.CreateClient("api");
  }

  [TestCleanup]
  public void Cleanup() => _disposable?.Dispose();

  [TestMethod]
  public async Task GetAsync_RegionUrl_200Returned()
  {
    // Arrange
    string url = "v2/location/regions";

    // Act
    using HttpResponseMessage getCitiesResponseMessage = await _httpClient.GetAsync(url);

    // Assert
    Assert.AreEqual(HttpStatusCode.OK, getCitiesResponseMessage.StatusCode);
  }

  [TestMethod]
  public async Task GetAsync_RegionUrl_RegionsReturned()
  {
    // Arrange
    string url = "v2/location/regions";

    // Act
    using HttpResponseMessage getCitiesResponseMessage = await _httpClient.GetAsync(url);
    RegionResponse[]? regions = await getCitiesResponseMessage.Content.ReadFromJsonAsync<RegionResponse[]>();

    // Assert
    Assert.IsNotNull(regions);
    Assert.IsTrue(regions.Length > 0);
  }

  [TestMethod]
  public void ToUri_NoParameters_RouteReturned()
  {
    // Arrange
    RegionRequest request = new();

    // Act
    string actual = request.ToUri();

    // Assert
    string expected = RegionRequest.Route;
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void ToUri_CountryCodes_UriWithParametersReturned()
  {
    // Arrange
    RegionRequest request = new
    (
      Countries: ["BY", "RU"]
    );

    // Act
    string actual = request.ToUri();

    // Assert
    string expected = $"{RegionRequest.Route}?country_codes=BY&country_codes=RU";
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void ToUri_SizeAndPage_UriWithParametersReturned()
  {
    // Arrange
    RegionRequest request = new
    (
      Size: 10,
      Page: 2
    );

    // Act
    string actual = request.ToUri();

    // Assert
    string expected = $"{RegionRequest.Route}?size=10&page=2";
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void ToUri_Language_UriWithParametersReturned()
  {
    // Arrange
    RegionRequest request = new
    (
      Language: Language.English
    );

    // Act
    string actual = request.ToUri();

    // Assert
    string expected = $"{RegionRequest.Route}?lang=eng";
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void ToUri_AllParameters_UriWithParametersReturned()
  {
    // Arrange
    RegionRequest request = new
    (
      Countries   : [CountryCode.Belarus, CountryCode.Russia],
      Size        : 10,
      Page        : 2,
      Language    : Language.English
    );

    // Act
    string actual = request.ToUri();

    // Assert
    string expected = $"{RegionRequest.Route}?country_codes=BY&country_codes=RU&size=10&page=2&lang=eng";
    Assert.AreEqual(expected, actual);
  }
}
