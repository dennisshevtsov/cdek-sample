// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;
using System.Text.Json;

namespace CdekSample;

public sealed class RequestTypeJsonConverter : JsonConverter<RequestType>
{
  public override RequestType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      return (RequestType)reader.GetString();
    }

    throw new Exception($"Invalid JSON token to convert to RequestType: {reader.GetString()}");
  }

  public override void Write(Utf8JsonWriter writer, RequestType value, JsonSerializerOptions options) =>
    writer.WriteStringValue(value);
}
