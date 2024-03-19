// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;
using System.Text.Json;

namespace CdekSample;

public sealed class CountryCodeJsonConverter : JsonConverter<CountryCode>
{
  public override CountryCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      return reader.GetString();
    }

    throw new Exception($"Invalid JSON token to create DeliveryMode: {reader.GetString()}");
  }

  public override void Write(Utf8JsonWriter writer, CountryCode value, JsonSerializerOptions options) =>
    writer.WriteStringValue(value);
}
