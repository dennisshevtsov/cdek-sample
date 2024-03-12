// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.RegularExpressions;

namespace CdekSample;

public readonly partial struct PostalCode
{
  private PostalCode(string code) => Code = code;
 
  private string Code { get; }

  public override string ToString() => Code;

  [GeneratedRegex("\\d+")]
  private static partial Regex DigitsOnly();

  private static PostalCode From(string? code)
  {
    if (string.IsNullOrEmpty(code))
    {
      throw new Exception("Code required to create PostalCode");
    }

    if (DigitsOnly().IsMatch(code))
    {
      throw new Exception($"Code {code} must only contain digits");
    }

    return new(code);
  }

  public static implicit operator PostalCode(string? code)      => PostalCode.From(code);
  public static implicit operator string(PostalCode postalCode) => postalCode.Code;
}
