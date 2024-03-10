﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public sealed record class RegionRequest
(
  string[]? CountryCodes = null, // country_codes
  int?      Size         = null, // size
  int?      Page         = null, // page
  Language? Language     = null  // lang
)
{
  public string[]? CountryCodes { get; } = CountryCodes;

  public int? Size { get; } = Size is null && Page is not null ? throw new Exception("Size required if page not null") : Size;

  public int? Page { get; } = Page;

  public Language? Language { get; } = Language;
}
