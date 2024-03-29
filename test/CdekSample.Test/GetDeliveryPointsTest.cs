﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

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
  public async Task GetAsync_DeliveryPointUrl_200Returned()
  {
    // Arrange
    string url = "v2/deliverypoints";

    // Act
    using HttpResponseMessage getCitiesResponseMessage = await _httpClient.GetAsync(url);

    // Assert
    Assert.AreEqual(HttpStatusCode.OK, getCitiesResponseMessage.StatusCode);
  }

  [TestMethod]
  public async Task GetAsync_DeliveryPointUrl_RegionsReturned()
  {
    // Arrange
    string url = "v2/deliverypoints";

    // Act
    using HttpResponseMessage getCitiesResponseMessage = await _httpClient.GetAsync(url);
    DeliveryPointResponse[]? regions = await getCitiesResponseMessage.Content.ReadFromJsonAsync<DeliveryPointResponse[]>();

    // Assert
    Assert.IsNotNull(regions);
    Assert.IsTrue(regions.Length > 0);
  }

  [TestMethod]
  public void ToUri_NoParameters_RouteReturned()
  {
    // Arrange
    DeliveryPointRequest request = new();

    // Act
    string uri = request.ToUri();

    // Assert
    Assert.AreEqual(DeliveryPointRequest.Route, uri);
  }

  [TestMethod]
  public void ToUri_PostalCode_UriWithPostalCodeReturned()
  {
    // Arrange
    PostalCode postalCode = "12345";
    DeliveryPointRequest request = new(PostalCode: postalCode);

    // Act
    string uri = request.ToUri();

    // Assert
    Assert.AreEqual($"{DeliveryPointRequest.Route}?postal_code={postalCode}", uri);
  }
}
