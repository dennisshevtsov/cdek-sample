// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace CdekSample;

public sealed class DeliveryPointCodeJsonConverter : JsonConverter<DeliveryPointCode>
{
  public override DeliveryPointCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.Number)
    {
      return (DeliveryPointCode)reader.GetString();
    }

    throw new Exception($"Invalid JSON token to create DeliveryMode: {reader.GetString()}");
  }

  public override void Write(Utf8JsonWriter writer, DeliveryPointCode value, JsonSerializerOptions options) =>
    writer.WriteStringValue(value);
}
