// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Request for List of Pickup Points
/// </summary>
/// <param name="Code">Code</param>
/// <param name="Uuid"></param>
/// <param name="Location">Address</param>
/// <param name="AddressComment">Description of location</param>
/// <param name="NearestStation">Nearest station/public transport stop</param>
/// <param name="NearestMetroStation">Nearest metro station</param>
/// <param name="WorkTime">Opening hours, string of the following type: Mon–Fri 9–18, Sat9–16”</param>
/// <param name="Phones">List of phones</param>
/// <param name="Email">E-mail</param>
/// <param name="Note">Pickup points note</param>
/// <param name="Type">Pickup point type: PVZ — CDEK warehouse, POSTAMAT — CDEK parcel terminals.</param>
/// <param name="OwnerCode">Affiliation of the pickup points company: CDEK — pickup point is owned by CDEK, InPost — pickup point is owned by InPost.</param>
/// <param name="TakeOnly">Whether the pickup point is only a pickup point</param>
/// <param name="IsHandout">Availability of an issuing orders</param>
/// <param name="IsReception">Availability of an taking orders</param>
/// <param name="IsDressingRoom">Availability of a fitting room</param>
/// <param name="HaveCashless">Availability of payment terminal</param>
/// <param name="HaveCash">Availability of cash payment</param>
/// <param name="AllowedCod">Cash on delivery is permitted in a pickup point</param>
/// <param name="IsLtl"></param>
/// <param name="Fulfillment">Availability of an order fulfillment zone</param>
/// <param name="Site">Pickup point's website on the CDEK page</param>
/// <param name="OfficeImageList">All photos of the office (except for a photo showing how to get to it)</param>
/// <param name="WorkTimeList">Opening hours for every day</param>
/// <param name="WorkTimeExceptions">Office schedule exceptions</param>
/// <param name="WeightMin">Minimum weight (in kg) accepted by a pickup point (> WeightMin)</param>
/// <param name="WeightMax">Maximum weight (in kg) accepted by a pickup point (<=WeightMax)floatyes</param>
/// <param name="Dimensions">List of locker dimensions (only for type = POSTAMAT)</param>
public sealed record class DeliveryPoint
(
  [property: JsonPropertyName("code")]                  string               Code,
  [property: JsonPropertyName("uuid")]                  string               Uuid,
  [property: JsonPropertyName("location")]              Location             Location,
  [property: JsonPropertyName("address_comment")]       string?              AddressComment,
  [property: JsonPropertyName("nearest_station")]       string?              NearestStation,
  [property: JsonPropertyName("nearest_metro_station")] string?              NearestMetroStation,
  [property: JsonPropertyName("work_time")]             string               WorkTime,
  [property: JsonPropertyName("phones")]                Phone[]              Phones,
  [property: JsonPropertyName("email")]                 string?              Email,
  [property: JsonPropertyName("note")]                  string?              Note,
  [property: JsonPropertyName("type")]                  string               Type,
  [property: JsonPropertyName("owner_code")]            string               OwnerCode,
  [property: JsonPropertyName("take_only")]             bool                 TakeOnly,
  [property: JsonPropertyName("is_handout")]            bool                 IsHandout,
  [property: JsonPropertyName("is_reception")]          bool                 IsReception,
  [property: JsonPropertyName("is_dressing_room")]      bool                 IsDressingRoom,
  [property: JsonPropertyName("have_cashless")]         bool                 HaveCashless,
  [property: JsonPropertyName("have_cash")]             bool                 HaveCash,
  [property: JsonPropertyName("allowed_cod")]           bool                 AllowedCod,
  [property: JsonPropertyName("is_ltl")]                bool?                IsLtl,
  [property: JsonPropertyName("fulfillment")]           bool?                Fulfillment,
  [property: JsonPropertyName("site")]                  string?              Site,
  [property: JsonPropertyName("office_image_list")]     Image[]?             OfficeImageList,
  [property: JsonPropertyName("work_time_list")]        WorkTime[]           WorkTimeList,
  [property: JsonPropertyName("work_time_exceptions")]  WorkTimeException[]? WorkTimeExceptions,
  [property: JsonPropertyName("weight_min")]            float?               WeightMin,
  [property: JsonPropertyName("weight_max")]            float?               WeightMax,
  [property: JsonPropertyName("dimensions")]            Dimension[]?         Dimensions
);
