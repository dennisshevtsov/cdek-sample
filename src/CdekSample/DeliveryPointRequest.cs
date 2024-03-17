// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public sealed record DeliveryPointRequest
(
  PostalCode?        PostalCode     = null,
  City?              City           = null,
  DeliveryPointType? Type           = null,
  Country?           Country        = null,
  int?               RegionCode     = null,
  bool?              HaveCashless   = null,
  bool?              HaveCach       = null,
  bool?              AllowedCod     = null,
  bool?              IsDressingRoom = null,
  int?               WeightMax      = null,
  int?               WeightMin      = null,
  Language?          Language       = null,
  bool?              TakeOnly       = null,
  bool?              IsHandout      = null,
  bool?              IsReception    = null,
  Guid?              FiasGuid       = null,
  string?            Code           = null,
  bool?              IsTtl          = null,
  bool?              Foolfillment   = null,
  int?               Size           = null,
  int?               Page           = null
)
{
  public const string Route = "v2/deliverypoints";
  public string ToUri()
  {
    // 22 params by 3 segments (param_name= param_value &)
    // 1 route
    // 1 ?
    List<string> segments = new(capacity: 22 * 3 + 1 + 1)
    {
      DeliveryPointRequest.Route,
      "?",
    };

    if (PostalCode is not null)
    {
      segments.Add("postal_code=");
      segments.Add(PostalCode);
      segments.Add("&");
    }

    if (City is not null)
    {
      segments.Add("city_code=");
      segments.Add(City);
      segments.Add("&");
    }

    if (Type is not null)
    {
      segments.Add("type=");
      segments.Add(Type);
      segments.Add("&");
    }

    if (Country is not null)
    {
      segments.Add("country_code=");
      segments.Add(Country);
      segments.Add("&");
    }

    if (RegionCode is not null)
    {
      segments.Add("region_code=");
      segments.Add(RegionCode.Value.ToString());
      segments.Add("&");
    }

    if (HaveCashless is not null)
    {
      segments.Add("have_cashless=");
      segments.Add(HaveCashless.Value.ToString());
      segments.Add("&");
    }

    if (PostalCode is not null)
    {
      segments.Add("postal_code=");
      segments.Add(PostalCode);
      segments.Add("&");
    }

    if (HaveCach is not null)
    {
      segments.Add("have_cash=");
      segments.Add(HaveCach.Value.ToString());
      segments.Add("&");
    }

    if (AllowedCod is not null)
    {
      segments.Add("allowed_cod=");
      segments.Add(AllowedCod.Value.ToString());
      segments.Add("&");
    }

    if (IsDressingRoom is not null)
    {
      segments.Add("is_dressing_room=");
      segments.Add(IsDressingRoom.Value.ToString());
      segments.Add("&");
    }

    if (WeightMax is not null)
    {
      segments.Add("weight_max=");
      segments.Add(WeightMax.Value.ToString());
      segments.Add("&");
    }

    if (WeightMin is not null)
    {
      segments.Add("weight_min=");
      segments.Add(WeightMin.Value.ToString());
      segments.Add("&");
    }

    if (Language is not null)
    {
      segments.Add("lang=");
      segments.Add(Language);
      segments.Add("&");
    }

    if (TakeOnly is not null)
    {
      segments.Add("take_only=");
      segments.Add(TakeOnly.Value.ToString());
      segments.Add("&");
    }

    if (IsHandout is not null)
    {
      segments.Add("is_handout=");
      segments.Add(IsHandout.Value.ToString());
      segments.Add("&");
    }

    if (IsReception is not null)
    {
      segments.Add("is_reception=");
      segments.Add(IsReception.Value.ToString());
      segments.Add("&");
    }

    if (FiasGuid is not null)
    {
      segments.Add("fias_guid=");
      segments.Add(FiasGuid.Value.ToString());
      segments.Add("&");
    }

    if (Code is not null)
    {
      segments.Add("code=");
      segments.Add(Code);
      segments.Add("&");
    }

    if (IsTtl is not null)
    {
      segments.Add("is_ltl=");
      segments.Add(IsTtl.Value.ToString());
      segments.Add("&");
    }

    if (Foolfillment is not null)
    {
      segments.Add("fulfillment=");
      segments.Add(Foolfillment.Value.ToString());
      segments.Add("&");
    }

    if (Size is not null)
    {
      segments.Add("size=");
      segments.Add(Size.Value.ToString());
      segments.Add("&");
    }

    if (Page is not null)
    {
      segments.Add("page=");
      segments.Add(Page.Value.ToString());
      segments.Add("&");
    }

    segments.RemoveAt(segments.Count - 1);
    return string.Concat(segments);
  }
}
