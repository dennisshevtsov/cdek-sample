// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

[JsonConverter(typeof(DeliveryPointCodeJsonConverter))]
public readonly struct DeliveryPointCode
{
  private DeliveryPointCode(string code) => Code = code;

  private string Code { get; }

  public override string ToString() => Code;

  private static DeliveryPointCode From(string? code)
  {
    if (string.IsNullOrEmpty(code))
    {
      return DeliveryPointCode.None;
    }

    return new(code);
  }

  public static explicit operator DeliveryPointCode(string? code) => DeliveryPointCode.From(code);
  public static implicit operator string(DeliveryPointCode code)  => code.Code;

  private static readonly DeliveryPointCode _none;
  public static DeliveryPointCode None => _none;
}
