// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample.Test;

[TestClass]
public sealed class CalculatorByTariffListTest
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
  public async Task GetAsync_CalculatorUrl_200Returned()
  {
    // Arrange
    string url = "v2/calculator/tarifflist";
    CalculatorByAvailableTariffsRequest request = new
    (
      Date                : default,
      Type                : OrderType.Delivery,
      AdditionalOrderTypes: null,
      Currency            : Currency.RussianRouble,
      Lang                : Language.Russian,
      FromLocation        : new(Code: 270),
      ToLocation          : new(Code: 44),
      Packages            : [new(Weight: 1000)]
    );

    // Act
    using HttpResponseMessage calculatorByTariffListResponseMessage = await _httpClient.PostAsJsonAsync(url, request);

    // Assert
    Assert.AreEqual(HttpStatusCode.OK, calculatorByTariffListResponseMessage.StatusCode);
  }

  [TestMethod]
  public async Task GetAsync_CalculatorUrl_CalculationReturned()
  {
    // Arrange
    string url = "v2/calculator/tarifflist";
    CalculatorByAvailableTariffsRequest request = new
    (
      Date                : default,
      Type                : OrderType.Delivery,
      AdditionalOrderTypes: null,
      Currency            : Currency.RussianRouble,
      Lang                : Language.Russian,
      FromLocation        : new(Code: 270),
      ToLocation          : new(Code: 44),
      Packages            : [new(Weight: 1000)]
    );

    // Act
    using HttpResponseMessage calculatorByTariffListResponseMessage = await _httpClient.PostAsJsonAsync(url, request);
    CalculatorByAvailableTariffsResponse? calculatorByTariffListResponse =
      await calculatorByTariffListResponseMessage.Content.ReadFromJsonAsync<CalculatorByAvailableTariffsResponse>();

    // Assert
    Assert.IsNotNull(calculatorByTariffListResponse);
    Assert.IsNotNull(calculatorByTariffListResponse.TariffCodes);
    Assert.IsTrue(calculatorByTariffListResponse.TariffCodes.Length > 0);
  }
}
