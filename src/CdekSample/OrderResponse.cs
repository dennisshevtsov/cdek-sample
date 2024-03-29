﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class OrderResponse
(
  Entity? Entity,
  Request[] Requests,
  Warning[]? Warnings,
  [property: JsonPropertyName("related_entities")] RelatedEntity[] RelatedEntitiies
);