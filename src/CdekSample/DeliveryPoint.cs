// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class DeliveryPoint
(
  [property: JsonPropertyName("code")]                  string              Code,
  [property: JsonPropertyName("uuid")]                  string              Uuid,
  [property: JsonPropertyName("location")]              Location            Location,
  [property: JsonPropertyName("address_comment")]       string?             AddressComment,
  [property: JsonPropertyName("nearest_station")]       string?             NearestStation,
  [property: JsonPropertyName("nearest_metro_station")] string?             NearestMetroStation,
  [property: JsonPropertyName("work_time")]             string              WorkTime,
  [property: JsonPropertyName("phones")]                Phone[]             Phones,
  [property: JsonPropertyName("email")]                 string?             Email,
  [property: JsonPropertyName("note")]                  string?             Note,
  [property: JsonPropertyName("type")]                  string              Type,
  [property: JsonPropertyName("owner_code")]            string              OwnerCode,
  [property: JsonPropertyName("take_only")]             bool                TakeOnly,
  [property: JsonPropertyName("is_handout")]            bool                IsHandout,
  [property: JsonPropertyName("is_reception")]          bool                IsReception,
  [property: JsonPropertyName("is_dressing_room")]      bool                IsDressingRoom,
  [property: JsonPropertyName("have_cashless")]         bool                HaveCashless,
  [property: JsonPropertyName("have_cash")]             bool                HaveCash,
  [property: JsonPropertyName("allowed_cod")]           bool                AllowedCod,
  [property: JsonPropertyName("is_ltl")]                bool?               IsLtl,
  [property: JsonPropertyName("fulfillment")]           bool?               Fulfillment,
  [property: JsonPropertyName("site")]                  string?             Site,
  [property: JsonPropertyName("office_image_list")]     Image[]?            OfficeImageList,
  [property: JsonPropertyName("work_time_list")]        WorkTime[]          WorkTimeList,
  [property: JsonPropertyName("work_time_exceptions")] WorkTimeException[]? WorkTimeExceptions,
  [property: JsonPropertyName("weight_min")]            float?              WeightMin,
  [property: JsonPropertyName("weight_max")]            float?              WeightMax,
  [property: JsonPropertyName("dimensions")]            Dimension[]?        Dimensions
);
