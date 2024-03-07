// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

[JsonConverter(typeof(PaymentLimitJsonConverter))]
public record struct PaymentLimit
{
  private const float NoLimitValue             = -1F;
  private const float NoDeliveryOnPaymentValue = 0F;

  public PaymentLimit(): this(PaymentLimit.NoLimitValue) { }
  private PaymentLimit(float value) => Value = value;

  private float Value { get; }

  public override readonly string ToString() => Value.ToString();

  private static PaymentLimit From(float value)
  {
    if (value > 0)
    {
      return new PaymentLimit(value);
    }

    throw new Exception($"Invalid value to create PaymentLimit: {value}");
  }

  public static implicit operator PaymentLimit(float value)        => PaymentLimit.From(value);
  public static implicit operator float(PaymentLimit paymentLimit) => paymentLimit.Value;

  public static readonly PaymentLimit NoLimit             = new();
  public static readonly PaymentLimit NoDeliveryOnPayment = new(PaymentLimit.NoDeliveryOnPaymentValue);
}
