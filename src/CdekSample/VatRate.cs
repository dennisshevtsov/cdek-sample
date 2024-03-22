// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public readonly struct VatRate
{
  private VatRate(int rate) => Rate = rate;

  private int Rate { get; }

  public override string ToString() => Rate.ToString();

  private static VatRate From(int rate)
  {
    if (rate == VatRate.Vat0.Rate ) return VatRate.Vat0;
    if (rate == VatRate.Vat10.Rate) return VatRate.Vat10;
    if (rate == VatRate.Vat12.Rate) return VatRate.Vat12;
    if (rate == VatRate.Vat20.Rate) return VatRate.Vat20;

    throw new Exception($"Invalid rate {rate} to create VateRate");
  }

  public static explicit operator VatRate(int rate) => VatRate.From(rate);
  public static implicit operator int(VatRate rate) => rate.Rate;

  public static readonly VatRate Vat0  = new(rate: 0);
  public static readonly VatRate Vat10 = new(rate: 10);
  public static readonly VatRate Vat12 = new(rate: 12);
  public static readonly VatRate Vat20 = new(rate: 20);
}
