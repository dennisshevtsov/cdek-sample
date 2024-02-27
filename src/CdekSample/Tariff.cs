// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public readonly record struct Tariff
{
  public Tariff(): this(code: 0) { }

  private Tariff(int code) => Code = code;

  private int Code { get; }

  public override string ToString() => Code.ToString();

  private static readonly Dictionary<int, Tariff> _tariffs = new()
  {
    { Tariff.None.Code                                   , Tariff.None                                    },
    { Tariff.InternationalExpressDocumentsDoorDoor.Code  , Tariff.InternationalExpressDocumentsDoorDoor   },
    { Tariff.InternationalExpressFreightDoorDoor.Code    , Tariff.InternationalExpressFreightDoorDoor     },
    { Tariff.WarehouseWarehouseParcel.Code               , Tariff.WarehouseWarehouseParcel                },
    { Tariff.WarehouseDoorParcel.Code                    , Tariff.WarehouseDoorParcel                     },
    { Tariff.DoorWarehouseParcel.Code                    , Tariff.DoorWarehouseParcel                     },
    { Tariff.DoorDoorParcel.Code                         , Tariff.DoorDoorParcel                          },
    { Tariff.EconomyDoorDoorParcel.Code                  , Tariff.EconomyDoorDoorParcel                   },
    { Tariff.EconomyDoorWarehouseParcel.Code             , Tariff.EconomyDoorWarehouseParcel              },
    { Tariff.EconomyWarehouseDoorParcel.Code             , Tariff.EconomyWarehouseDoorParcel              },
    { Tariff.EconomyWarehouseWarehouseParcel.Code        , Tariff.EconomyWarehouseWarehouseParcel         },
    { Tariff.EcomExpressWarehouseWarehouse.Code          , Tariff.EcomExpressWarehouseWarehouse           },
    { Tariff.EcomExpressDoorDoor.Code                    , Tariff.EcomExpressDoorDoor                     },
    { Tariff.EcomExpressWarehouseDoor.Code               , Tariff.EcomExpressWarehouseDoor                },
    { Tariff.EcomExpressDoorWarehouse.Code               , Tariff.EcomExpressDoorWarehouse                },
    { Tariff.EcomExpressDoorParcelTerminal.Code          , Tariff.EcomExpressDoorParcelTerminal           },
    { Tariff.EcomExpressWarehouseParcelTerminal.Code     , Tariff.EcomExpressWarehouseParcelTerminal      },
    { Tariff.ParcelDoorParcelTerminal.Code               , Tariff.ParcelDoorParcelTerminal                },
    { Tariff.ParcelWarehouseParcelTerminal.Code          , Tariff.ParcelWarehouseParcelTerminal           },
    { Tariff.EconomicParcelWarehouseParcelTerminal.Code  , Tariff.EconomicParcelWarehouseParcelTerminal   },
    { Tariff.EcomStandardDoorDoor.Code                   , Tariff.EcomStandardDoorDoor                    },
    { Tariff.EcomStandardWarehouseWarehouse.Code         , Tariff.EcomStandardWarehouseWarehouse          },
    { Tariff.EcomStandardWarehouseDoor.Code              , Tariff.EcomStandardWarehouseDoor               },
    { Tariff.EcomStandardDoorWarehouse.Code              , Tariff.EcomStandardDoorWarehouse               },
    { Tariff.EcomStandardDoorParcelTerminal.Code         , Tariff.EcomStandardDoorParcelTerminal          },
    { Tariff.EcomStandardWarehouseParcelTerminal.Code    , Tariff.EcomStandardWarehouseParcelTerminal     },
    { Tariff.DocumentsExpressDoorDoor.Code               , Tariff.DocumentsExpressDoorDoor                },
    { Tariff.DocumentsExpressDoorParcelTerminal.Code     , Tariff.DocumentsExpressDoorParcelTerminal      },
    { Tariff.DocumentsExpressDoorWarehouse.Code          , Tariff.DocumentsExpressDoorWarehouse           },
    { Tariff.DocumentsExpressWarehouseDoor.Code          , Tariff.DocumentsExpressWarehouseDoor           },
    { Tariff.DocumentsExpressWarehouseParcelTerminal.Code, Tariff.DocumentsExpressWarehouseParcelTerminal },
    { Tariff.DocumentsExpressWarehouseWarehouse.Code     , Tariff.DocumentsExpressWarehouseWarehouse      },
  };

  private static Tariff From(int code)
  {
    if (_tariffs.TryGetValue(code, out Tariff tariff))
    {
      return tariff;
    }

    throw new Exception($"Invalid code to create Tariff: {code}");
  }

  public static implicit operator Tariff(int code)   => Tariff.From(code);
  public static implicit operator int(Tariff tariff) => tariff.Code;

  /// <summary>
  /// Значение по умолчанию
  /// </summary>
  public static readonly Tariff None = new();

  /// <summary>
  ///   <para>Название тарифа: Международный экспресс документы дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 5 кг</para>
  ///   <para>Услуга: Международный экспресс</para>
  ///   <para>Описание: Экспресс-доставка за/из-за границы документов и писем.</para>
  /// </summary>
  public static readonly Tariff InternationalExpressDocumentsDoorDoor = new(code: 7);

  /// <summary>
  ///   <para>Название тарифа: Международный экспресс грузы дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Международный экспресс</para>
  ///   <para>Описание: Экспресс-доставка за/из-за границы грузов и посылок до 30 кг.</para>
  /// </summary>
  public static readonly Tariff InternationalExpressFreightDoorDoor = new (code: 8);

  /// <summary>
  ///   <para>Название тарифа: Посылка склад-склад</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff WarehouseWarehouseParcel = new(code: 136);

  /// <summary>
  ///   <para>Название тарифа: Посылка склад-дверь</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff WarehouseDoorParcel = new(code: 137);

  /// <summary>
  ///   <para>Название тарифа: Посылка дверь-склад</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff DoorWarehouseParcel = new(code: 138);

  /// <summary>
  ///   <para>Название тарифа: Посылка дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff DoorDoorParcel = new(code: 139);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка дверь-дверь</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff EconomyDoorDoorParcel = new(code: 231);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка дверь-склад</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff EconomyDoorWarehouseParcel = new(code: 232);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка склад-дверь</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff EconomyWarehouseDoorParcel = new(code: 233);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка склад-склад</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff EconomyWarehouseWarehouseParcel = new(code: 234);

  /// <summary>
  ///   <para>Название тарифа: E-com Express склад-склад</para>
  ///   <para>Режим доставки: Склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly Tariff EcomExpressWarehouseWarehouse = new (code: 291);

  /// <summary>
  ///   <para>Название тарифа: E-com Express дверь-дверь</para>
  ///   <para>Режим доставки: Дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly Tariff EcomExpressDoorDoor = new (code: 293);

  /// <summary>
  ///   <para>Название тарифа: E-com Express склад-дверь</para>
  ///   <para>Режим доставки: Склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly Tariff EcomExpressWarehouseDoor = new (code: 294);

  /// <summary>
  ///   <para>Название тарифа: E-com Express дверь-склад</para>
  ///   <para>Режим доставки: Дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly Tariff EcomExpressDoorWarehouse = new (code: 295);

  /// <summary>
  ///   <para>Название тарифа: E-com Express дверь-постамат</para>
  ///   <para>Режим доставки: Дверь-постамат (Д-П)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly Tariff EcomExpressDoorParcelTerminal = new(code: 509);

  /// <summary>
  ///   <para>Название тарифа: E-com Express склад-постамат</para>
  ///   <para>Режим доставки: Склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: до 500 кг</para>
  ///   <para>Услуга: E-com Express</para>
  ///   <para>Описание: Самая быстрая экспресс-доставка в режиме авиа. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению(услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо.</para>
  /// </summary>
  public static readonly Tariff EcomExpressWarehouseParcelTerminal = new(code: 510);

  /// <summary>
  ///   <para>Название тарифа: Посылка дверь-постамат</para>
  ///   <para>Режим доставки: дверь-постамат (Д-П)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff ParcelDoorParcelTerminal = new(code: 366);

  /// <summary>
  ///   <para>Название тарифа: Посылка склад-постамат</para>
  ///   <para>Режим доставки: склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Посылка</para>
  ///   <para>Описание: Услуга экономичной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff ParcelWarehouseParcelTerminal = new(code: 368);

  /// <summary>
  ///   <para>Название тарифа: Экономичная посылка склад-постамат</para>
  ///   <para>Режим доставки: склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: до 50 кг</para>
  ///   <para>Услуга: Экономичная посылка</para>
  ///   <para>Описание: Услуга экономичной наземной доставки товаров для компаний, осуществляющих дистанционную торговлю.</para>
  /// </summary>
  public static readonly Tariff EconomicParcelWarehouseParcelTerminal = new(code: 378);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard дверь-дверь</para>
  ///   <para>Режим доставки: Дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly Tariff EcomStandardDoorDoor = new (code: 184);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard склад-склад</para>
  ///   <para>Режим доставки: Склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly Tariff EcomStandardWarehouseWarehouse = new (code: 185);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard склад-дверь</para>
  ///   <para>Режим доставки: Склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly Tariff EcomStandardWarehouseDoor = new (code: 186);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard дверь-склад</para>
  ///   <para>Режим доставки: Дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly Tariff EcomStandardDoorWarehouse = new (code: 187);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard дверь-постамат</para>
  ///   <para>Режим доставки: Дверь-постамат (Д-П)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly Tariff EcomStandardDoorParcelTerminal = new(code: 497);

  /// <summary>
  ///   <para>Название тарифа: E-com Standard склад-постамат</para>
  ///   <para>Режим доставки: Склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: </para>
  ///   <para>Услуга: E-com Standard</para>
  ///   <para>Описание: Стандартная экспресс-доставка. Сервис по доставке товаров из-за рубежа с услугами по таможенному оформлению (услуги для компаний дистанционной торговли). Тариф доступен только для клиентов с типом Юридическое лицо. Доступно для заказов с типом "ИМ" и "Доставка".</para>
  /// </summary>
  public static readonly Tariff EcomStandardWarehouseParcelTerminal = new(code: 498);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly Tariff DocumentsExpressDoorDoor = new (code: 2261);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Дверь-постамат (Д-П)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly Tariff DocumentsExpressDoorParcelTerminal = new(code: 2266);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly Tariff DocumentsExpressDoorWarehouse = new(code: 2262);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly Tariff DocumentsExpressWarehouseDoor = new(code: 2263);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Склад-постамат (С-П)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly Tariff DocumentsExpressWarehouseParcelTerminal = new(code: 2267);

  /// <summary>
  ///   <para>Название тарифа: Documents Express</para>
  ///   <para>Режим доставки: Склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: Индивидуальные ограничения в зависимости от направления</para>
  ///   <para>Услуга: Documents Express</para>
  ///   <para>Описание: Быстрая международная доставка документов</para>
  /// </summary>
  public static readonly Tariff DocumentsExpressWarehouseWarehouse = new(code: 2264);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу.</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo18DoorDoor = new (code: 3);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 9</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo9DoorDoor = new (code: 57);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 10</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo10DoorDoor = new (code: 58);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo12DoorDoor = new (code: 59);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo14DoorDoor = new (code: 60);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16</para>
  ///   <para>Режим доставки: дверь-дверь (Д-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo16DoorDoor = new (code: 61);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12 </para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo12DoorWarehouse = new(code: 777);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo14DoorWarehouse = new(code: 786);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo16DoorWarehouse = new(code: 795);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18</para>
  ///   <para>Режим доставки: дверь-склад (Д-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo18DoorWarehouse = new(code: 804);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo12WarehouseDoor = new(code: 778);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo14WarehouseDoor = new(code: 787);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo16WarehouseDoor = new(code: 796);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18</para>
  ///   <para>Режим доставки: склад-дверь (С-Д)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo18WarehouseDoor = new(code: 805);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 12</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo12WarehouseWarehouse = new(code: 779);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 14</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo14WarehouseWarehouse = new(code: 788);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 16</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo16WarehouseWarehouse = new(code: 797);

  /// <summary>
  ///   <para>Название тарифа: Супер-экспресс до 18</para>
  ///   <para>Режим доставки: склад-склад (С-С)</para>
  ///   <para>Ограничение по весу: до 30 кг</para>
  ///   <para>Услуга: Срочная доставка</para>
  ///   <para>Описание: Срочная доставка документов и грузов «из рук в руки» к определенному часу (доставка за сутки).</para>
  /// </summary>
  public static readonly Tariff SuperExpressUpTo18WarehouseWarehouse = new(code: 806);
}
