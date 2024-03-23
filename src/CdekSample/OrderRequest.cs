// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class OrderRequest
(
  TariffCode                TariffCode,
  OrderType?                      Type = null,
  AdditionalOrderType? AdditionalTypes = null,
  string?                       Number = null,
  string?                      Comment = null,
  string?                 DeveloperKey = null,
  DeliveryPointCode?     ShipmentPoint = null,
  DeliveryPointCode?     DeliveryPoint = null,
  DateTimeOffset?          DateInvoice = null,
  string?                  ShipperName = null,
  string?               ShipperAddress = null,
  Money?         DeliveryRecipientCost = null,
  Threshold?                 Threshold = null,
  Contact?                      Sender = null
)
{
  [JsonPropertyName("type")]
  [JsonPropertyOrder(1)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public OrderType? Type { get; } = Type;

  [JsonPropertyName("additional_order_types")]
  [JsonPropertyOrder(2)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public AdditionalOrderType? AdditionalTypes { get; } = AdditionalTypes;

  [JsonPropertyName("number")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Number { get; } = Number;

  [JsonPropertyName("tariff_code")]
  [JsonPropertyOrder(4)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public TariffCode TariffCode { get; } = TariffCode;

  [JsonPropertyName("comment")]
  [JsonPropertyOrder(5)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Comment { get; } = Comment;

  [JsonPropertyName("developer_key")]
  [JsonPropertyOrder(6)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? DeveloperKey { get; } = DeveloperKey;

  [JsonPropertyName("shipment_point")]
  [JsonPropertyOrder(7)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public DeliveryPointCode? ShipmentPoint { get; } = ShipmentPoint;

  [JsonPropertyName("delivery_point")]
  [JsonPropertyOrder(8)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public DeliveryPointCode? DeliveryPoint { get; } = DeliveryPoint;

  [JsonPropertyName("date_invoice")]
  [JsonPropertyOrder(9)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public DateTimeOffset? DateInvoice { get; } = DateInvoice;

  [JsonPropertyName("shipper_name")]
  [JsonPropertyOrder(10)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? ShipperName { get; } = ShipperName;

  [JsonPropertyName("shipper_address")]
  [JsonPropertyOrder(11)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? ShipperAddress { get; } = ShipperAddress;

  [JsonPropertyName("delivery_recipient_cost")]
  [JsonPropertyOrder(12)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Money? DeliveryRecipientCost { get; } = DeliveryRecipientCost;
}
