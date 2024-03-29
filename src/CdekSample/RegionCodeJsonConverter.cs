﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace CdekSample;

public sealed class RegionCodeJsonConverter : JsonConverter<RegionCode>
{
  public override RegionCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.Number)
    {
      return reader.GetInt32();
    }

    throw new Exception($"Invalid JSON token to convert to Currency: {reader.GetString()}");
  }

  public override void Write(Utf8JsonWriter writer, RegionCode value, JsonSerializerOptions options) =>
    writer.WriteNumberValue(value);
}
