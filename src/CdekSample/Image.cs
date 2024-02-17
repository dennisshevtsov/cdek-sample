// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// All photos of the office (except for a photo showing how to get to it)
/// </summary>
/// <param name="Url">All photos have a separate tag with url attribute. A link to the image is displayed.</param>
public sealed record class Image
(
  [property: JsonPropertyName("url")] string Url
);
