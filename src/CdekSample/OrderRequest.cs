﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class OrderRequest
(
  TariffCode                 TariffCode,
  Contact                     Recipient,
  OrderType?                       Type = null,
  AdditionalOrderType?  AdditionalTypes = null,
  string?                        Number = null,
  string?                       Comment = null,
  string?                  DeveloperKey = null,
  DeliveryPointCode?      ShipmentPoint = null,
  DeliveryPointCode?      DeliveryPoint = null,
  DateTimeOffset?           DateInvoice = null,
  string?                   ShipperName = null,
  string?                ShipperAddress = null,
  Money?          DeliveryRecipientCost = null,
  Threshold[]? DeliveryRecipientCostAdv = null,
  Contact?                       Sender = null,
  Seller?                        Seller = null,
  Location?                        From = null,
  Location?                          To = null,
  Service[]?                   Services = null,
  Package[]?                   Packages = null,
  Print?                          Print = null,
  bool?                  IsClientReturn = null
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

  [JsonPropertyName("delivery_recipient_cost_adv")]
  [JsonPropertyOrder(13)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Threshold[]? DeliveryRecipientCostAdv { get; } = DeliveryRecipientCostAdv;

  [JsonPropertyName("sender")]
  [JsonPropertyOrder(14)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Contact? Sender { get; } = Sender;

  [JsonPropertyName("seller")]
  [JsonPropertyOrder(15)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Seller? Seller { get; } = Seller;

  [JsonPropertyName("recipient")]
  [JsonPropertyOrder(16)]
  public Contact Recipient { get; } = Recipient;

  [JsonPropertyName("from_location")]
  [JsonPropertyOrder(17)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Location? From { get; } = From;

  [JsonPropertyName("to_location")]
  [JsonPropertyOrder(18)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Location? To { get; } = To;

  [JsonPropertyName("services")]
  [JsonPropertyOrder(19)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Service[]? Services { get; } = Services;

  [JsonPropertyName("packages")]
  [JsonPropertyOrder(20)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Package[]? Packages { get; } = Packages;

  [JsonPropertyName("print")]
  [JsonPropertyOrder(21)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Print? Print { get; } = Print;

  [JsonPropertyName("is_client_return")]
  [JsonPropertyOrder(22)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public bool? IsClientReturn { get; } = IsClientReturn;
}
