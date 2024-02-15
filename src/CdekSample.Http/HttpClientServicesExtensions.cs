// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using CdekSample.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class HttpClientServicesExtensions
{
  public static IHttpClientBuilder AddAuthorizedHttpClient(this IServiceCollection services, string tokenClientName = "token", string apiClientName = "api")
  {
    ArgumentNullException.ThrowIfNull(services);

    services.AddHttpClient
    (
      name : tokenClientName,
      configureClient: (IServiceProvider provider, HttpClient tokenHttpClient) =>
      {
        HttpClientSettings authorizedHttpClientSettings =
          provider.GetRequiredService<IOptions<HttpClientSettings>>().Value ??
          throw new Exception("No authorizated HTTP client settings retrieved");

        tokenHttpClient.BaseAddress = new Uri(authorizedHttpClientSettings.TokenBaseUrl);
      }
    );

    IHttpClientBuilder apiClientBuilder = services.AddHttpClient
    (
      name: apiClientName,
      configureClient: (IServiceProvider provider, HttpClient tokenHttpClient) =>
      {
        HttpClientSettings authorizedHttpClientSettings =
          provider.GetRequiredService<IOptions<HttpClientSettings>>().Value ??
          throw new Exception("No authorizated HTTP client settings retrieved");

        tokenHttpClient.BaseAddress = new Uri(authorizedHttpClientSettings.ApiBaseUrl);
        tokenHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
      }
    );

    apiClientBuilder.AddHttpMessageHandler((IServiceProvider provider) =>
    {
      HttpClientSettings authorizedHttpClientSettings =
          provider.GetRequiredService<IOptions<HttpClientSettings>>().Value ??
          throw new Exception("No authorizated HTTP client settings retrieved");

      HttpClient tokenHttpClient = provider.GetRequiredService<IHttpClientFactory>().CreateClient(tokenClientName);
      AuthorizedHttpMessageHandler authorizedHttpMessageHandler = new
      (
        tokenHttpClient,
        authorizedHttpClientSettings.GetTokenUrl,
        authorizedHttpClientSettings.ClientId,
        authorizedHttpClientSettings.ClientSecret
      );

      return authorizedHttpMessageHandler;
    });

    return apiClientBuilder;
  }

  public static IHttpClientBuilder UseHttpClientSettings(this IHttpClientBuilder builder, IConfiguration configuration)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.Services.AddOptions<HttpClientSettings>()
                    .Bind(configuration)
                    .ValidateOnStart();

    return builder;
  }

  public static IHttpClientBuilder UseHttpClientSettings(this IHttpClientBuilder builder, Action<HttpClientSettings> configure)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.Services.AddOptions<HttpClientSettings>()
                    .Configure(configure);

    return builder;
  }
}
