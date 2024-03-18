// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public readonly struct RegionCode
{
  private RegionCode(string code) => Code = code;

  private string Code { get; }

  public override string ToString() => Code;

  public static implicit operator RegionCode(string code)       => new(code);
  public static implicit operator string(RegionCode regionCode) => regionCode.Code;
}
