// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;
using System.Text.Json;

namespace CdekSample;

public sealed class MoneyJsonConverter : JsonConverter<Money>
{
  public override Money Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
    throw new NotImplementedException();

  public override void Write(Utf8JsonWriter writer, Money value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteNumber("value", value.Value);
   
    if (value.VatSum is not null)
    {
      writer.WriteNumber("vat_sum", value.VatSum.Value);
    }
    else
    {
      writer.WriteNull("vat_sum");
    }

    if (value.VatRate is not null)
    {
      writer.WriteNumber("vat_rate", value.VatRate.Value);
    }
    else
    {
      writer.WriteNull("vat_rate");
    }

    writer.WriteEndObject();
  }
}
