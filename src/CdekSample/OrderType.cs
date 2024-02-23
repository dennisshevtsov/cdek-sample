// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Тип заказа (для проверки доступности тарифа и дополнительных услуг по типу заказа)
/// </summary>
[JsonConverter(typeof(OrderTypeJsonConverter))]
public readonly record struct OrderType
{
  public OrderType(): this(code: 0, name: "None") { }

  private OrderType(int code, string name) => (Code, Name) = (code, name);

  private int Code { get; }

  /// <summary>
  /// Имя для логгирования
  /// </summary>
  private string Name { get; }

  public override string ToString() => Name;

  private static OrderType From(int code)
  {
    if (code == OrderType.None.Code       ) return OrderType.None;
    if (code == OrderType.OnlineStore.Code) return OrderType.OnlineStore;
    if (code == OrderType.Delivery.Code   ) return OrderType.Delivery;

    throw new Exception($"Invalid code to create OrderType {code}");
  }

  public static implicit operator OrderType(int code)      => OrderType.From(code);
  public static implicit operator int(OrderType orderType) => orderType.Code;

  /// <summary>
  /// Значение по умолчание (невалидное)
  /// </summary>
  public static readonly OrderType None = new();

  /// <summary>
  /// Интернет-магазин
  /// </summary>
  public static readonly OrderType OnlineStore = new(code: 1, name: "OnlineStore");

  /// <summary>
  /// Доставка
  /// </summary>
  public static readonly OrderType Delivery = new(code: 2, name: "Delivery");
}
