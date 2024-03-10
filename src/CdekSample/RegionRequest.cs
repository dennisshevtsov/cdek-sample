// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public sealed record class RegionRequest
(
  string[]? CountryCodes = null,
  int?      Size         = null,
  int?      Page         = null,
  Language? Language     = null
)
{
  public const string Route = "v2/location/regions";

  public string[]? CountryCodes { get; } = CountryCodes;

  public int? Size { get; } = Size is null && Page is not null ? throw new Exception("Size required if page not null") : Size;

  public int? Page { get; } = Page;

  public Language? Language { get; } = Language;

  public string ToUri()
  {
    List<string> segments = [Route, "?"];

    if (CountryCodes is not null)
    {
      for (int i = 0; i < CountryCodes.Length; i++)
      {
        segments.Add("country_codes=");
        segments.Add(CountryCodes[i]);
      }
    }

    if (Size is not null)
    {
      segments.Add("size=");
      segments.Add(Size.Value.ToString());
    }

    if (Page is not null)
    {
      segments.Add("page=");
      segments.Add(Page.Value.ToString());
    }

    if (Language is not null)
    {
      segments.Add("lang=");
      segments.Add(Language.Value.ToString());
    }

    segments.RemoveAt(segments.Count - 1);
    return string.Concat(segments);
  }
}
