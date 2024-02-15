// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample.Http;

public sealed record class HttpClientSettings
{
  public required string TokenBaseUrl { get; set; }
  public required string GetTokenUrl  { get; set; }
  public required string ClientId     { get; set; }
  public required string ClientSecret { get; set; }

  public required string ApiBaseUrl { get; set; }
}
