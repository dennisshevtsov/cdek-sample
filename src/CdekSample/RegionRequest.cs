// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public sealed record class RegionRequest
(
  string[]? CountryCodes = null, // country_codes
  int?      Size         = null, // size
  int?      Page         = null, // page
  Language? Language     = null  // lang
);
