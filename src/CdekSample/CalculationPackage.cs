// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Информации по местам (упаковкам)
/// </summary>
/// <param name="Weight">Общий вес (в граммах)</param>
/// <param name="Length">Габариты упаковки. Длина (в сантиметрах)</param>
/// <param name="Width">Габариты упаковки. Ширина (в сантиметрах)</param>
/// <param name="Height">Габариты упаковки. Высота (в сантиметрах)</param>
public sealed record class CalculationPackage
(
  [property: JsonPropertyName("weight")] int  Weight,
  [property: JsonPropertyName("length")] int? Length = null,
  [property: JsonPropertyName("width")]  int? Width  = null,
  [property: JsonPropertyName("height")] int? Height = null
);
  