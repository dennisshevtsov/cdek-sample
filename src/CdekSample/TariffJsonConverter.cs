// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace CdekSample;

public sealed class TariffJsonConverter : JsonConverter<Tariff>
{
  public override Tariff Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      return reader.GetString();
    }

    throw new Exception($"Invalid JSON token to convert to Currency: {reader.GetString()}");
  }

  public override void Write(Utf8JsonWriter writer, Tariff value, JsonSerializerOptions options) =>
    writer.WriteNumberValue(value);
}
