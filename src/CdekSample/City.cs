// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public readonly struct City
{
  private City(int code) => Code = code;

  private int Code { get; }

  public override string ToString() => Code.ToString();

  private static City From(int code)
  {
    if (code <= 0)
    {
      throw new Exception($"Invalid code {code} to create City");
    }

    return new(code);
  }

  public static implicit operator City(int code) => City.From(code);
  public static implicit operator int(City city) => city.Code;
}
