// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public sealed record DeliveryPointRequest
(
  PostalCode?        PostalCode,
  City?              City,
  DeliveryPointType? Type,
  Country?           Country,
  int?               RegionCode,
  bool?              HaveCashless,
  bool?              HaveCach,
  bool?              AllowedCod,
  bool?              IsDressingRoom,
  int?               WeightMax,
  int?               WeightMin,
  Language?          Language,
  bool?              TakeOnly,
  bool?              IsHandout,
  bool?              IsReception,
  Guid?              FiasGuid,
  string?            Code,
  bool?              IsTtl,
  bool?              IsFoolfillment,
  int?               Size,
  int?               Page
);
