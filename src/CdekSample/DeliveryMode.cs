// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Режим доставки
/// </summary>
[JsonConverter(typeof(DeliveryModeJsonConverter))]
public readonly record struct DeliveryMode
{
  private DeliveryMode(int code, string name) => (Code, Name) = (code, name);

  private int Code { get; }

  /// <summary>
  /// Для логгирования
  /// </summary>
  private string Name { get; }

  public override string ToString() => Name;

  public static DeliveryMode From(int code)
  {
    if (code == DeliveryMode.DoorDoor.Code                    ) return DeliveryMode.DoorDoor;
    if (code == DeliveryMode.DoorWarehouse.Code               ) return DeliveryMode.DoorWarehouse;
    if (code == DeliveryMode.WarehouseDoor.Code               ) return DeliveryMode.WarehouseDoor;
    if (code == DeliveryMode.WarehouseWarehouse.Code          ) return DeliveryMode.WarehouseWarehouse;
    if (code == DeliveryMode.DoorParcelTeminal.Code           ) return DeliveryMode.DoorParcelTeminal;
    if (code == DeliveryMode.WarehouseParcelTerminal.Code     ) return DeliveryMode.WarehouseParcelTerminal;
    if (code == DeliveryMode.ParcelTerminalDoor.Code          ) return DeliveryMode.ParcelTerminalDoor;
    if (code == DeliveryMode.ParcelTerminalWarehouse.Code     ) return DeliveryMode.ParcelTerminalWarehouse;
    if (code == DeliveryMode.ParcelTerminalParcelTerminal.Code) return DeliveryMode.ParcelTerminalParcelTerminal;

    throw new Exception($"Invalid code to create DeliveryMode: {code}");
  }

  public static implicit operator DeliveryMode(int code)  => DeliveryMode.From(code);
  public static implicit operator int(DeliveryMode value) => value.Code;

  /// <summary>
  /// дверь-дверь
  /// </summary>
  public static readonly DeliveryMode DoorDoor = new(code: 1, name: "DoorDoor");

  /// <summary>
  /// дверь-склад
  /// </summary>
  public static readonly DeliveryMode DoorWarehouse = new(code: 2, name: "DoorWarehouse");

  /// <summary>
  /// склад-дверь
  /// </summary>
  public static readonly DeliveryMode WarehouseDoor = new(code: 3, name: "WarehouseDoor");

  /// <summary>
  /// склад-склад
  /// </summary>
  public static readonly DeliveryMode WarehouseWarehouse = new(code: 4, name: "WarehouseWarehouse");

  /// <summary>
  /// дверь-постамат
  /// </summary>
  public static readonly DeliveryMode DoorParcelTeminal = new(code: 6, name: "DoorParcelTeminal");

  /// <summary>
  /// склад-постамат
  /// </summary>
  public static readonly DeliveryMode WarehouseParcelTerminal = new(code: 7, name: "WarehouseParcelTerminal");

  /// <summary>
  /// постамат-дверь
  /// </summary>
  public static readonly DeliveryMode ParcelTerminalDoor = new(code: 8, name: "ParcelTerminalDoor");

  /// <summary>
  /// постамат-склад
  /// </summary>
  public static readonly DeliveryMode ParcelTerminalWarehouse = new(code: 9, name: "ParcelTerminalWarehouse");

  /// <summary>
  /// постамат-постамат
  /// </summary>
  public static readonly DeliveryMode ParcelTerminalParcelTerminal = new(code: 10, name: "ParcelTerminalParcelTerminal");
}
