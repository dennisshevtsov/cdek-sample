// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace CdekSample;

public sealed class PaymentLimitJsonConverter : JsonConverter<PaymentLimit>
{
  public override PaymentLimit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.Number)
    {
      return reader.GetSingle();
    }

    throw new Exception($"Invalid JSON token to create to PaymentLimit: {reader.GetString()}");
  }

  public override void Write(Utf8JsonWriter writer, PaymentLimit value, JsonSerializerOptions options) =>
    writer.WriteNumberValue(value);
}
