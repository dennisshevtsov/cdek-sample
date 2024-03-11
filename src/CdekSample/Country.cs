// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public readonly struct Country(string code)
{
  private string Code { get; } = code;

  public override string ToString() => Code;

  private static Country From(string? code)
  {
    if (string.IsNullOrEmpty(code))
    {
      throw new Exception("Unempty code required to create Country");
    }

    if (code.Length != 2 || code[0] < 'A' || code[0] > 'Z' || code[1] < 'A' || code[1] > 'Z')
    {
      throw new Exception("Invalid code to create Country");
    }

    return new(code);
  }

  public static implicit operator Country(string? code)   => Country.From(code);
  public static implicit operator string(Country country) => country.Code;

  public static readonly Country Belarus    = new(code: "BY");
  public static readonly Country Kazakhstan = new(code: "KZ");
  public static readonly Country Russia     = new(code: "RU");
}
