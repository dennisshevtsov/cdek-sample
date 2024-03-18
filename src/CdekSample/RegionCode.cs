// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

[JsonConverter(typeof(RegionCodeJsonConverter))]
public readonly struct RegionCode
{
  private RegionCode(int code) => Code = code;

  private int Code { get; }

  public override string ToString() => Code.ToString();

  private static RegionCode From(int code)
  {
    if (code <= 0)
    {
      throw new Exception($"Invalid code {code} to create RegionCode");
    }

    return new(code);
  }

  public static implicit operator RegionCode(int code)       => RegionCode.From(code);
  public static implicit operator int(RegionCode regionCode) => regionCode.Code;
}
