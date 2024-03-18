// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

[JsonConverter(typeof(RegionCodeJsonConverter))]
public readonly struct RegionCode
{
  private RegionCode(string code) => Code = code;

  private string Code { get; }

  public override string ToString() => Code;

  private static RegionCode From(string? code)
  {
    if (string.IsNullOrEmpty(code))
    {
      throw new Exception("Unempty code required to create RegionCode");
    }

    return new(code);
  }

  public static implicit operator RegionCode(string? code)      => RegionCode.From(code);
  public static implicit operator string(RegionCode regionCode) => regionCode.Code;
}
