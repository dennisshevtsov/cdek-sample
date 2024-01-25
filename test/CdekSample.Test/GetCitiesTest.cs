// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Net.Http.Json;

namespace CdekSample.Test;

[TestClass]
public sealed class GetCitiesTest
{
  [TestMethod]
  public async Task GetAsync_CitiesUrl_CitiesReturned()
  {
    // Arrange
    using HttpClient httpClient = new();
    using FormUrlEncodedContent authorizationContent = new(new Dictionary<string, string>
    {
      { "grant_type"   , "client_credentials"               },
      { "client_id"    , "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI" },
      { "client_secret", "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG" },
    });

    // Act
    using HttpResponseMessage authorizationResponseMessage = await httpClient.PostAsync("https://api.edu.cdek.ru/v2/oauth/token?parameters", authorizationContent);
    Token? token = await authorizationResponseMessage.Content.ReadFromJsonAsync<Token>();

    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token!.AccessToken}");

    using HttpResponseMessage getCitiesResponseMessage = await httpClient.GetAsync("https://api.edu.cdek.ru/v2/location/cities");
    City[]? cities = await getCitiesResponseMessage.Content.ReadFromJsonAsync<City[]>();

    // Assert
    Assert.IsNotNull(cities);
    Assert.IsTrue(cities.Length > 0);
  }
}
