// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;


[JsonConverter(typeof(TariffCodeJsonConverter))]
public readonly record struct TariffCode
{
  public TariffCode(): this(code: 0) { }

  private TariffCode(int code) => Code = code;

  private int Code { get; }

  public override string ToString() => Code.ToString();

  private static TariffCode From(int code) => new(code);

  public static implicit operator TariffCode(int code)   => TariffCode.From(code);
  public static implicit operator int(TariffCode tariff) => tariff.Code;

  public static implicit operator TariffCode(string? code)  => string.IsNullOrEmpty(code) ? TariffCode.None : TariffCode.From(int.Parse(code));
  public static implicit operator string(TariffCode tariff) => tariff.ToString();

  /// <summary>
  /// Значение по умолчанию
  /// </summary>
  public static readonly TariffCode None = new();

  /// <summary>
  ///   <para>Название тарифа: Международный экспресс документы дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 5 кг</para>
  ///   <para>Услуга: Международный экспресс</para>
  ///   <para>Описание: Экспресс-доставка за/из-за границы документов и писем.</para>
  /// </summary>
  public static readonly TariffCode InternationalExpressDocumentsDoorDoor = new(code: 7);

  /// <summary>
  ///   <para>Название тарифа: Международный экспресс грузы дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Международный экспресс</para>
  ///   <para>Описание: Экспресс-доставка за/из-за границы грузов и посылок до 30 кг.</para>
  /// </summary>
  public static readonly TariffCode InternationalExpressFreightDoorDoor = new (code: 8);

  /// <summary>
  ///   <para>Название тарифа: Посылка склад-склад</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode WarehouseWarehouseParcel = new(code: 136);

  /// <summary>
  ///   <para>Название тарифа: Посылка склад-дверь</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode WarehouseDoorParcel = new(code: 137);

  /// <summary>
  ///   <para>Название тарифа: Посылка дверь-склад</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode DoorWarehouseParcel = new(code: 138);

  /// <summary>
  ///   <para>Название тарифа: Посылка дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode DoorDoorParcel = new(code: 139);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode EconomyDoorDoorParcel = new(code: 231);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка дверь-склад</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode EconomyDoorWarehouseParcel = new(code: 232);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка склад-дверь</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode EconomyWarehouseDoorParcel = new(code: 233);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка склад-склад</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode EconomyWarehouseWarehouseParcel = new(code: 234);

  /// <summary>
  ///   <para>Название тарифа: E-com Express склад-склад</para>
  ///   <para>Режим доставки: Склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly TariffCode EcomExpressWarehouseWarehouse = new (code: 291);

  /// <summary>
  ///   <para>Название тарифа: E-com Express дверь-дверь</para>
  ///   <para>Режим доставки: Дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly TariffCode EcomExpressDoorDoor = new (code: 293);

  /// <summary>
  ///   <para>Название тарифа: E-com Express склад-дверь</para>
  ///   <para>Режим доставки: Склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly TariffCode EcomExpressWarehouseDoor = new (code: 294);

  /// <summary>
  ///   <para>Название тарифа: E-com Express дверь-склад</para>
  ///   <para>Режим доставки: Дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly TariffCode EcomExpressDoorWarehouse = new (code: 295);

  /// <summary>
  ///   <para>Название тарифа: E-com Express дверь-постамат</para>
  ///   <para>Режим доставки: Дверь-постамат (Д-П)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly TariffCode EcomExpressDoorParcelTerminal = new(code: 509);

  /// <summary>
  ///   <para>Название тарифа: E-com Express склад-постамат</para>
  ///   <para>Режим доставки: Склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly TariffCode EcomExpressWarehouseParcelTerminal = new(code: 510);

  /// <summary>
  ///   <para>Название тарифа: Посылка дверь-постамат</para>
  ///   <para>Режим доставки: дверь-постамат (Д-П)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode ParcelDoorParcelTerminal = new(code: 366);

  /// <summary>
  ///   <para>Название тарифа: Посылка склад-постамат</para>
  ///   <para>Режим доставки: склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode ParcelWarehouseParcelTerminal = new(code: 368);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка склад-постамат</para>
  ///   <para>Режим доставки: склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly TariffCode EconomicParcelWarehouseParcelTerminal = new(code: 378);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard дверь-дверь</para>
  ///   <para>Режим доставки: Дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly TariffCode EcomStandardDoorDoor = new (code: 184);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard склад-склад</para>
  ///   <para>Режим доставки: Склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly TariffCode EcomStandardWarehouseWarehouse = new (code: 185);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard склад-дверь</para>
  ///   <para>Режим доставки: Склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly TariffCode EcomStandardWarehouseDoor = new (code: 186);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard дверь-склад</para>
  ///   <para>Режим доставки: Дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly TariffCode EcomStandardDoorWarehouse = new (code: 187);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard дверь-постамат</para>
  ///   <para>Режим доставки: Дверь-постамат (Д-П)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly TariffCode EcomStandardDoorParcelTerminal = new(code: 497);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard склад-постамат</para>
  ///   <para>Режим доставки: Склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly TariffCode EcomStandardWarehouseParcelTerminal = new(code: 498);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly TariffCode DocumentsExpressDoorDoor = new (code: 2261);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Дверь-постамат (Д-П)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly TariffCode DocumentsExpressDoorParcelTerminal = new(code: 2266);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly TariffCode DocumentsExpressDoorWarehouse = new(code: 2262);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly TariffCode DocumentsExpressWarehouseDoor = new(code: 2263);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly TariffCode DocumentsExpressWarehouseParcelTerminal = new(code: 2267);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly TariffCode DocumentsExpressWarehouseWarehouse = new(code: 2264);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу.</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo18DoorDoor = new (code: 3);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 9</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo9DoorDoor = new (code: 57);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 10</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo10DoorDoor = new (code: 58);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo12DoorDoor = new (code: 59);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo14DoorDoor = new (code: 60);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo16DoorDoor = new (code: 61);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12 </para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo12DoorWarehouse = new(code: 777);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo14DoorWarehouse = new(code: 786);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo16DoorWarehouse = new(code: 795);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo18DoorWarehouse = new(code: 804);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo12WarehouseDoor = new(code: 778);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo14WarehouseDoor = new(code: 787);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo16WarehouseDoor = new(code: 796);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo18WarehouseDoor = new(code: 805);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo12WarehouseWarehouse = new(code: 779);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo14WarehouseWarehouse = new(code: 788);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo16WarehouseWarehouse = new(code: 797);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly TariffCode SuperExpressUpTo18WarehouseWarehouse = new(code: 806);

  /// <summary>
  ///   <para>Название тарифа: Магистральный экспресс склад-склад</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экономичная доставка</para>
  ///   <para>Описание: Быстрая экономичная доставка грузов.</para>
  /// </summary>
  public static readonly TariffCode LongDistanceExpressWarehouseWarehouse = new(code: 62);

  /// <summary>
  ///   <para>Название тарифа: Магистральный экспресс дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экономичная доставка</para>
  ///   <para>Описание: Быстрая экономичная доставка грузов.</para>
  /// </summary>
  public static readonly TariffCode LongDistanceExpressDoorDoor = new(code: 121);

  /// <summary>
  ///   <para>Название тарифа: Магистральный экспресс склад-дверь</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экономичная доставка</para>
  ///   <para>Описание: Быстрая экономичная доставка грузов.</para>
  /// </summary>
  public static readonly TariffCode LongDistanceExpressWarehouseDoor = new(code: 122);

  /// <summary>
  ///   <para>Название тарифа: Магистральный экспресс дверь-склад</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экономичная доставка</para>
  ///   <para>Описание: Быстрая экономичная доставка грузов.</para>
  /// </summary>
  public static readonly TariffCode LongDistanceExpressDoorWarehouse = new(code: 123);

  /// <summary>
  ///   <para>Название тарифа: Магистральный супер-экспресс склад-склад</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экономичная доставка</para>
  ///   <para>Описание: Быстрая экономичная доставка грузов к определенному часу</para>
  /// </summary>
  public static readonly TariffCode LongDistanceSuperExpressWarehouseWarehouse = new(code: 63);

  /// <summary>
  ///   <para>Название тарифа: Магистральный супер-экспресс дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экономичная доставка</para>
  ///   <para>Описание: Быстрая экономичная доставка грузов к определенному часу</para>
  /// </summary>
  public static readonly TariffCode MainSuperExpressDoorDoor = new(code: 124);

  /// <summary>
  ///   <para>Название тарифа: Магистральный супер-экспресс склад-дверь</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экономичная доставка</para>
  ///   <para>Описание: Быстрая экономичная доставка грузов к определенному часу</para>
  /// </summary>
  public static readonly TariffCode MainSuperExpressWarehouseDoor = new(code: 125);

  /// <summary>
  ///   <para>Название тарифа: Магистральный супер-экспресс дверь-склад</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экономичная доставка</para>
  ///   <para>Описание: Быстрая экономичная доставка грузов к определенному часу</para>
  /// </summary>
  public static readonly TariffCode MainSuperExpressDoorWarehouse = new(code: 126);

  /// <summary>
  ///   <para>Название тарифа: Экспресс дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экспресс</para>
  ///   <para>Описание: Классическая экспресс-доставка документов и грузов по стандартным срокам доставки внутри страны. Без ограничений по весу</para>
  /// </summary>
  public static readonly TariffCode ExpressDoorDoor = new (code: 480);

  /// <summary>
  ///   <para>Название тарифа: Экспресс дверь-склад</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экспресс</para>
  ///   <para>Описание: Классическая экспресс-доставка документов и грузов по стандартным срокам доставки внутри страны. Без ограничений по весу</para>
  /// </summary>
  public static readonly TariffCode ExpressDoorWarehouse = new (code: 481);

  /// <summary>
  ///   <para>Название тарифа: Экспресс склад-дверь</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экспресс</para>
  ///   <para>Описание: Классическая экспресс-доставка документов и грузов по стандартным срокам доставки внутри страны. Без ограничений по весу</para>
  /// </summary>
  public static readonly TariffCode ExpressWarehouseDoor = new (code: 482);

  /// <summary>
  ///   <para>Название тарифа: Экспресс склад-склад</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экспресс</para>
  ///   <para>Описание: Классическая экспресс-доставка документов и грузов по стандартным срокам доставки внутри страны. Без ограничений по весу</para>
  /// </summary>
  public static readonly TariffCode ExpressWarehouseWarehouse = new (code: 483);

  /// <summary>
  ///   <para>Название тарифа: Экспресс дверь-постамат</para>
  ///   <para>Режим доставки: дверь-постамат (Д-П)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экспресс</para>
  ///   <para>Описание: Классическая экспресс-доставка документов и грузов по стандартным срокам доставки внутри страны. Без ограничений по весу</para>
  /// </summary>
  public static readonly TariffCode ExpressDoorParcelTerminal = new(code: 485);

  /// <summary>
  ///   <para>Название тарифа: Экспресс склад-постамат</para>
  ///   <para>Режим доставки: склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Экспресс</para>
  ///   <para>Описание: Классическая экспресс-доставка документов и грузов по стандартным срокам доставки внутри страны. Без ограничений по весу</para>
  /// </summary>
  public static readonly TariffCode ExpressWarehouseParcelTerminal = new(code: 486);

  /// <summary>
  ///   <para>Название тарифа: Сборный груз дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Сборный груз</para>
  ///   <para>Описание: Экономичная наземная доставка сборных грузов</para>
  /// </summary>
  public static readonly TariffCode ComposedCargoDoorDoor = new(code: 748);

  /// <summary>
  ///   <para>Название тарифа: Сборный груз дверь-склад</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Сборный груз</para>
  ///   <para>Описание: Экономичная наземная доставка сборных грузов</para>
  /// </summary>
  public static readonly TariffCode ComposedCargoDoorWarehouse = new(code: 749);

  /// <summary>
  ///   <para>Название тарифа: Сборный груз склад-дверь</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: Сборный груз</para>
  ///   <para>Описание: Экономичная наземная доставка сборных грузов</para>
  /// </summary>
  public static readonly TariffCode ComposedCargoWarehouseDoor = new (code: 750);

  /// <summary>
  ///   <para>Название тарифа: Сборный груз склад-склад</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 20000 кг</para>
  ///   <para>Услуга: Сборный груз</para>
  ///   <para>Описание: Экономичная наземная доставка сборных грузов</para>
  /// </summary>
  public static readonly TariffCode ComposedCargoWarehouseWarehouse = new (code: 751);

  /// <summary>
  ///   <para>Название тарифа: Доставка за 4 часа внутри города пешие</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 15 кг</para>
  ///   <para>Услуга: Блиц-экспресс</para>
  ///   <para>Описание: Доставка заказов от 0 до 15 кг пешими курьерами день в день по Москве и Санкт-Петербургу</para>
  /// </summary>
  public static readonly TariffCode DeliveryFor4HInsideCityFoot = new(code: 66);

  /// <summary>
  ///   <para>Название тарифа: Доставка за 4 часа МСК-МО МО-МСК пешие</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 15 кг</para>
  ///   <para>Услуга: </para>
  ///   <para>Описание: Доставка заказов от 0 до 15 кг пешими курьерами день в день по Москве и Московской области (до 10 км от МКАД)</para>
  /// </summary>
  public static readonly TariffCode DeliveryFor4HMskMoFoot = new(code: 67);

  /// <summary>
  ///   <para>Название тарифа: Доставка за 4 часа внутри города авто</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: от 15 кг до 30 кг</para>
  ///   <para>Услуга: </para>
  ///   <para>Описание: Доставка заказов от 15 кг до 30 кг курьерами день в день по Москве и Санкт-Петербургу</para>
  /// </summary>
  public static readonly TariffCode DeliveryFor4HInsideCityAuto = new(code: 68);

  /// <summary>
  ///   <para>Название тарифа: Доставка за 4 часа МСК-МО МО-МСК авто</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: от 15 кг до 30 кг</para>
  ///   <para>Услуга: </para>
  ///   <para>Описание: Доставка заказов от 15 кг до 30 кг курьерами день в день по Москве и Московской области (до 10 км от МКАД</para>
  /// </summary>
  public static readonly TariffCode DeliveryFor4HMskMoAuto = new(code: 69);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 10.00</para>
  ///   <para>Режим доставки: дверь-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress10DoorDoor  = new(code: 676);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 10.00 </para>
  ///   <para>Режим доставки: дверь-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress10DoorWarehouse = new(code: 677);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 10.00</para>
  ///   <para>Режим доставки: склад-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress10WarehouseDoor = new(code: 678);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 10.00</para>
  ///   <para>Режим доставки: склад-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress10WarehouseWarehouse = new(code: 679);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12.00</para>
  ///   <para>Режим доставки: дверь-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress12DoorDoor = new(code: 686);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12.00</para>
  ///   <para>Режим доставки: дверь-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress12DoorWarehouse = new (code: 687);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12.00 </para>
  ///   <para>Режим доставки: склад-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress12WarehouseDoor = new (code: 688);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12.00</para>
  ///   <para>Режим доставки: склад-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress12WarehouseWarehouse = new(code: 689);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14.00</para>
  ///   <para>Режим доставки: дверь-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress14DoorDoor = new(code: 696);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14.00</para>
  ///   <para>Режим доставки: дверь-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress14DoorWarehouse = new(code: 697);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14.00</para>
  ///   <para>Режим доставки: склад-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress14WarehouseDoor = new(code: 698);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14.00</para>
  ///   <para>Режим доставки: склад-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress14WarehouseWarehouse = new(code: 699);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16.00</para>
  ///   <para>Режим доставки: дверь-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress16DoorDoor = new(code: 706);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16.00</para>
  ///   <para>Режим доставки: дверь-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress16DoorWarehouse = new(code: 707);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16.00</para>
  ///   <para>Режим доставки: склад-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress16WarehouseDoor = new(code: 708);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16.00</para>
  ///   <para>Режим доставки: склад-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress16WarehouseWarehouse = new(code: 709);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18.00</para>
  ///   <para>Режим доставки: дверь-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress18DoorDoor = new(code: 716);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18.00</para>
  ///   <para>Режим доставки: дверь-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress18DoorWarehouse = new(code: 717);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18.00</para>
  ///   <para>Режим доставки: склад-дверь</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress18WarehouseDoor = new(code: 718);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18.00</para>
  ///   <para>Режим доставки: склад-склад</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за 1-2 суток).</para>
  /// </summary>
  public static readonly TariffCode SuperExpress18WarehouseWarehouse = new(code: 719);

  /// <summary>
  ///   <para>Название тарифа: СДЭК документы дверь-дверь</para>
  ///   <para>Режим доставки: Дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: 0.3 кг</para>
  ///   <para>Услуга: СДЭК документы</para>
  ///   <para>Описание: Экспресс доставка документов со спец. условием от 90 документов за 90 дней</para>
  /// </summary>
  public static readonly TariffCode CdekDocumentsDoorDoor = new(code: 533);

  /// <summary>
  ///   <para>Название тарифа: СДЭК документы дверь-склад</para>
  ///   <para>Режим доставки: Дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: 0.3 кг</para>
  ///   <para>Услуга: СДЭК документы</para>
  ///   <para>Описание: Экспресс доставка документов со спец. условием от 90 документов за 90 дней</para>
  /// </summary>
  public static readonly TariffCode CdekDocumentsDoorWarehouse = new(code: 534);

  /// <summary>
  ///   <para>Название тарифа: СДЭК документы склад-дверь</para>
  ///   <para>Режим доставки: Склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: 0.3 кг</para>
  ///   <para>Услуга: СДЭК документы</para>
  ///   <para>Описание: Экспресс доставка документов со спец. условием от 90 документов за 90 дней</para>
  /// </summary>
  public static readonly TariffCode CdekDocumentsWarehouseDoor = new(code: 535);

  /// <summary>
  ///   <para>Название тарифа: СДЭК документы склад-склад</para>
  ///   <para>Режим доставки: Склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: 0.3 кг</para>
  ///   <para>Услуга: СДЭК документы</para>
  ///   <para>Описание: Экспресс доставка документов со спец. условием от 90 документов за 90 дней</para>
  /// </summary>
  public static readonly TariffCode CdekDocumentsWarehouseWarehouse = new(code: 536);
}
