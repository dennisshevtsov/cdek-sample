// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

[JsonConverter(typeof(CountryCodeJsonConverter))]
public readonly struct CountryCode
{
  public CountryCode(): this(string.Empty) { }
  private CountryCode(string code) => Code = code;
 
  private string Code { get; }

  public override string ToString() => Code;

  private static CountryCode From(string? code)
  {
    if (string.IsNullOrEmpty(code))
    {
      return CountryCode.None;
    }

    if (code.Length != 2 || code[0] < 'A' || code[0] > 'Z' || code[1] < 'A' || code[1] > 'Z')
    {
      throw new Exception("Invalid code to create CountryCode");
    }

    return new(code);
  }

  public static implicit operator CountryCode(string? code)   => CountryCode.From(code);
  public static implicit operator string(CountryCode country) => country.Code;

  public static readonly CountryCode None       = new();
  public static readonly CountryCode Belarus    = new(code: "BY");
  public static readonly CountryCode Kazakhstan = new(code: "KZ");
  public static readonly CountryCode Russia     = new(code: "RU");
}
