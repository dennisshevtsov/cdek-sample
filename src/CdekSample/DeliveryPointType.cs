// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public readonly struct DeliveryPointType
{
  private DeliveryPointType(string type) => Type = type;

  private string Type { get; }

  public override string ToString() => Type;

  public static DeliveryPointType From(string? type)
  {
    if (type == DeliveryPointType.Pvz.Type     ) return DeliveryPointType.Pvz;
    if (type == DeliveryPointType.Postamat.Type) return DeliveryPointType.Postamat;
    if (type == DeliveryPointType.All.Type     ) return DeliveryPointType.All;

    throw new Exception($"Invalid type to create DeliveryPointType");
  }

  public static implicit operator DeliveryPointType(string? type) => DeliveryPointType.From(type);
  public static implicit operator string(DeliveryPointType type)  => type.Type;

  /// <summary>
  /// Для отображения складов СДЭК
  /// </summary>
  public static readonly DeliveryPointType Pvz = new(type: "PVZ");

  /// <summary>
  /// Для отображения постаматов СДЭК
  /// </summary>
  public static readonly DeliveryPointType Postamat = new(type: "POSTAMAT");

  /// <summary>
  /// Для отображения всех ПВЗ независимо от их типа
  /// </summary>
  public static readonly DeliveryPointType All = new(type: "ALL");
}
