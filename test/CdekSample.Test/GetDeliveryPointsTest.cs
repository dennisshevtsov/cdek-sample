// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Net.Http;
using System;

namespace CdekSample.Test;

[TestClass]
public sealed class GetDeliveryPointsTest
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
  public async Task GetAsync_CitiesUrl_200Returned()
  {
    // Arrange
    string url = "v2/deliverypoints";

    // Act
    using HttpResponseMessage getCitiesResponseMessage = await _httpClient.GetAsync(url);

    // Assert
    Assert.AreEqual(HttpStatusCode.OK, getCitiesResponseMessage.StatusCode);
  }

  [TestMethod]
  public async Task GetAsync_RegionsUrl_RegionsReturned()
  {
    // Arrange
    string url = "v2/deliverypoints";

    // Act
    using HttpResponseMessage getCitiesResponseMessage = await _httpClient.GetAsync(url);
    DeliveryPoint[]? regions = await getCitiesResponseMessage.Content.ReadFromJsonAsync<DeliveryPoint[]>();

    // Assert
    Assert.IsNotNull(regions);
    Assert.IsTrue(regions.Length > 0);
  }
}
