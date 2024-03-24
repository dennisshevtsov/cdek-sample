// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public sealed record class Service(AdditionalServiceCode Code, string? Parameter = null);
