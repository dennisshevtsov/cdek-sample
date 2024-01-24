// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace CdekSample.Test;

[TestClass]
public sealed class AuthorizationTest
{
  [TestMethod]
  public async Task PostAsync_TokenUrlAndCredentials_200Returned()
  {
    // Arrange
    using HttpClient http = new();
    using FormUrlEncodedContent content = new(new Dictionary<string, string>
    {
      { "grant_type", "client_credentials" },
      { "client_id", "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI" },
      { "client_secret", "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG" },
    });

    // Act
    using HttpResponseMessage message = await http.PostAsync("https://api.edu.cdek.ru/v2/oauth/token?parameters", content);

    // Assert
    Assert.AreEqual(HttpStatusCode.OK, message.StatusCode);
  }

  [TestMethod]
  public async Task PostAsync_TokenUrlAndCredentials_TokenReturned()
  {
    // Arrange
    using HttpClient http = new();
    using FormUrlEncodedContent content = new(new Dictionary<string, string>
    {
      { "grant_type", "client_credentials" },
      { "client_id", "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI" },
      { "client_secret", "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG" },
    });

    // Act
    using HttpResponseMessage message = await http.PostAsync("https://api.edu.cdek.ru/v2/oauth/token?parameters", content);
    Token? token = await message.Content.ReadFromJsonAsync<Token>();

    // Assert
    Assert.IsNotNull(token);
    Assert.IsNotNull(token.AccessToken);
    Assert.IsNotNull(token.TokenType);
    Assert.IsTrue(token.ExpiresIn > 0);
    Assert.IsNotNull(token.Scope);
    Assert.IsNotNull(token.Jti);
  }

  public sealed record Token
  (
    [property: JsonPropertyName("access_token")] string AccessToken,
    [property: JsonPropertyName("token_type")]   string TokenType,
    [property: JsonPropertyName("expires_in")]   int    ExpiresIn,
    [property: JsonPropertyName("scope")]        string Scope,
    [property: JsonPropertyName("jti")]          string Jti
  );
}
