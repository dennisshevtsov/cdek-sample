// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

[JsonConverter(typeof(MoneyJsonConverter))]
public readonly record struct Money(decimal Value, decimal? VatSum, VatRate? VatRate);
