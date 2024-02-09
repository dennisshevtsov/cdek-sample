// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Json;

namespace CdekSample.Test;

[TestClass]
public sealed class AuthorizationTest
{
#pragma warning disable CS8618
  private IDisposable _disposable;
  private HttpClient _httpClient;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    ServiceCollection services = new();
    services.AddAuthorizedHttpClient(tokenClientName: "token")
            .UseHttpClientSettings(options =>
            {
              options.TokenBaseUrl = "https://api.edu.cdek.ru";
              options.GetTokenUrl  = "v2/oauth/token?parameters";
            });

    IServiceScope scope = services.BuildServiceProvider().CreateScope();
    IHttpClientFactory factory = scope.ServiceProvider.GetRequiredService<IHttpClientFactory>();

    _disposable = scope;
    _httpClient = factory.CreateClient("token");
  }

  [TestCleanup]
  public void Cleanup()
  {
    _disposable?.Dispose();
  }

  [TestMethod]
  public async Task PostAsync_TokenUrlAndCredentials_200Returned()
  {
    // Arrange
    using FormUrlEncodedContent content = new(new Dictionary<string, string>
    {
      { "grant_type"   , "client_credentials"               },
      { "client_id"    , "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI" },
      { "client_secret", "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG" },
    });

    // Act
    using HttpResponseMessage message = await _httpClient.PostAsync("v2/oauth/token?parameters", content);

    // Assert
    Assert.AreEqual(HttpStatusCode.OK, message.StatusCode);
  }

  [TestMethod]
  public async Task PostAsync_TokenUrlAndCredentials_TokenReturned()
  {
    // Arrange
    using FormUrlEncodedContent content = new(new Dictionary<string, string>
    {
      { "grant_type"   , "client_credentials"               },
      { "client_id"    , "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI" },
      { "client_secret", "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG" },
    });

    // Act
    using HttpResponseMessage message = await _httpClient.PostAsync("v2/oauth/token?parameters", content);
    Token? token = await message.Content.ReadFromJsonAsync<Token>();

    // Assert
    Assert.IsNotNull(token);
    Assert.IsNotNull(token.AccessToken);
    Assert.IsNotNull(token.TokenType);
    Assert.IsTrue(token.ExpiresIn > 0);
    Assert.IsNotNull(token.Scope);
    Assert.IsNotNull(token.Jti);
  }
}
