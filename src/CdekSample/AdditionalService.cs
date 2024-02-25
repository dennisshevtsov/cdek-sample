// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

/// <summary>
/// Дополнительные услуги
/// </summary>
public readonly record struct AdditionalService
{
  public AdditionalService(): this(code: "NONE") { }

  private AdditionalService(string code) => Code = code;

  private string Code { get; }

  public override string ToString() => Code;

  private static readonly Dictionary<string, AdditionalService> _services = new()
  {
    { AdditionalService.None.Code                     , AdditionalService.None                      },
    { AdditionalService.Insurance.Code                , AdditionalService.Insurance                 },
    { AdditionalService.TakeFromSender.Code           , AdditionalService.TakeFromSender            },
    { AdditionalService.DeliveryToReceiver.Code       , AdditionalService.DeliveryToReceiver        },
    { AdditionalService.TryingOn.Code                 , AdditionalService.TryingOn                  },
    { AdditionalService.PartialDelivery.Code          , AdditionalService.PartialDelivery           },
    { AdditionalService.BanAttachmentInsperation.Code , AdditionalService.BanAttachmentInsperation  },
    { AdditionalService.Reverse.Code                  , AdditionalService.Reverse                   },
    { AdditionalService.DangerCargo.Code              , AdditionalService.DangerCargo               },
    { AdditionalService.Sms.Code                      , AdditionalService.Sms                       },
    { AdditionalService.GetUpFloorByHand.Code         , AdditionalService.GetUpFloorByHand          },
    { AdditionalService.GetUpFloorByElevator.Code     , AdditionalService.GetUpFloorByElevator      },
    { AdditionalService.Call.Code                     , AdditionalService.Call                      },
    { AdditionalService.TherminalMode.Code            , AdditionalService.TherminalMode             },
    { AdditionalService.CourierPackageA2.Code         , AdditionalService.CourierPackageA2          },
    { AdditionalService.NotifyOrderCreated.Code       , AdditionalService.NotifyOrderCreated        },
    { AdditionalService.NotifyOrderDelivery.Code      , AdditionalService.NotifyOrderDelivery       },
    { AdditionalService.CartonBoxXs.Code              , AdditionalService.CartonBoxXs               },
    { AdditionalService.CartonBoxS.Code               , AdditionalService.CartonBoxS                },
    { AdditionalService.CartonBoxM.Code               , AdditionalService.CartonBoxM                },
    { AdditionalService.CartonBoxL.Code               , AdditionalService.CartonBoxL                },
    { AdditionalService.CartonBox1Kg.Code             , AdditionalService.CartonBox1Kg              },
    { AdditionalService.CartonBox2Kg.Code             , AdditionalService.CartonBox2Kg              },
    { AdditionalService.CartonBox3Kg.Code             , AdditionalService.CartonBox3Kg              },
    { AdditionalService.CartonBox5Kg.Code             , AdditionalService.CartonBox5Kg              },
    { AdditionalService.CartonBox10Kg.Code            , AdditionalService.CartonBox10Kg             },
    { AdditionalService.CartonBox15Kg.Code            , AdditionalService.CartonBox15Kg             },
    { AdditionalService.CartonBox20Kg.Code            , AdditionalService.CartonBox20Kg             },
    { AdditionalService.CartonBox30Kg.Code            , AdditionalService.CartonBox30Kg             },
    { AdditionalService.BubbleWrap.Code               , AdditionalService.BubbleWrap                },
    { AdditionalService.WastePaper.Code               , AdditionalService.WastePaper                },
    { AdditionalService.CartonFiller.Code             , AdditionalService.CartonFiller              },
    { AdditionalService.PhotoOfDocuments.Code         , AdditionalService.PhotoOfDocuments          },
    { AdditionalService.AdultGoods.Code               , AdditionalService.AdultGoods                },
    { AdditionalService.OversizeCargo.Code            , AdditionalService.OversizeCargo             },
    { AdditionalService.HeavyCargo.Code               , AdditionalService.HeavyCargo                },
    { AdditionalService.LoadingOperationsAtSender.Code, AdditionalService.LoadingOperationsAtSender },
    { AdditionalService.LoadOperationAtRecipient.Code , AdditionalService.LoadOperationAtRecipient  },
  };

  private static AdditionalService From(string code)
  {
    if (_services.TryGetValue(code, out AdditionalService service))
    {
      return service;
    }

    throw new Exception($"Invalid code to create AdditionalService: {code}");
  }

  public static implicit operator AdditionalService(string code)    => AdditionalService.From(code);
  public static implicit operator string(AdditionalService service) => service.Code;

  /// <summary>
  /// Значение по умолчанию
  /// </summary>
  public static readonly AdditionalService None = new();

  /// <summary>
  ///   <para>Страхование</para>
  ///   <para>Обеспечение страховой защиты посылки. Размер дополнительного сбора страхования вычисляется от размера объявленной стоимости отправления.</para>
  /// </summary>
  public static readonly AdditionalService Insurance = new(code: "INSURANCE");

  /// <summary>
  ///   <para>Забор в городе отправителе</para>
  ///   <para>Дополнительная услуга забора груза в городе отправителя</para>
  /// </summary>
  public static readonly AdditionalService TakeFromSender = new(code: "TAKE_SENDER");

  /// <summary>
  ///   <para>Доставка в городе получателе</para>
  ///   <para>Дополнительная услуга доставки груза в городе получателя. Не применимо к заказам до постаматов.</para>
  /// </summary>
  public static readonly AdditionalService DeliveryToReceiver = new(code: "DELIV_RECEIVER");

  /// <summary>
  ///   <para>Примерка на дому</para>
  ///   <para>Курьер доставляет покупателю несколько единиц товара (одежда, обувь и пр.) для примерки. Только для клиентов с договором типа ИМ. Не применима в одном заказе с дополнительной услугой «Запрет осмотра вложения».</para>
  ///   <para>Не применимо к заказам до постаматов.</para>
  /// </summary>
  public static readonly AdditionalService TryingOn = new(code: "TRYING_ON");

  /// <summary>
  ///   <para>Частичная доставка</para>
  ///   <para>Во время доставки товара покупатель может отказаться от одной или нескольких позиций, и выкупить только часть заказа. Если в заказе указано одно вложение, услуга не подключается (проверку невозможно добавить без Фото).</para>
  ///   <para>Не применимо к заказам до постаматов и доступно только для ИМ.</para>
  /// </summary>
  public static readonly AdditionalService PartialDelivery = new(code: "PART_DELIV");

  /// <summary>
  ///   <para>Запрет осмотра вложения</para>
  ///   <para>Предоставляет возможность запрета осмотра вложения. Предоставляется для интернет-магазинов.</para>
  ///   <para>Не совместима с доп.услугами "Примерка на дому" и "Частичная доставка".</para>
  ///   <para>Услуга не передается до постамата.</para>
  ///   <para>Только для клиентов с договором типа ИМ.</para>
  /// </summary>
  public static readonly AdditionalService BanAttachmentInsperation = new(code: "BAN_ATTACHMENT_INSPECTION");

  /// <summary>
  ///   <para>Реверс</para>
  ///   <para>Обратный заказ на доставку от получателя до отправителя. Например, подписанные документы.</para>
  ///   <para>Обязательно в договоре наличие заполненного блока с условиями работы по Реверсу(если он не заполнен, то услуга не будет доступна). Не применимо к заказам до постаматов.</para>
  /// </summary>
  public static readonly AdditionalService Reverse = new(code: "REVERSE");

  /// <summary>
  ///   <para>	Опасный груз</para>
  ///   <para>Кроме обычных документов и грузов, компания СДЭК готова доставить отправления, содержащие опасные грузы (кроме запрещенных к перевозке).</para>
  /// </summary>
  public static readonly AdditionalService DangerCargo = new(code: "DANGER_CARGO");

  /// <summary>
  ///   <para>СМС-уведомление</para>
  ///   <para>Компания СДЭК предлагает каждому клиенту оформить услугу "СМС-уведомление о доставке".</para>
  ///   <para>Отправителю высылается сообщение с датой и временем доставки.Стоимость услуги 10 рублей.</para>
  ///   <para>Отправитель получает СМС-сообщение с информацией о дате/времени доставки и ФИО получателя.При режиме доставки до склада и указании мобильного телефона получателя, Компания "СДЭК" предоставляет всем клиентам бесплатную услугу: "СМС-уведомление о приходе груза на склад" или уведомления в виде PUSH-сообщений в мобильное приложение СДЭК или в месседжеры. Получателю будет отправлено сообщение с информацией об адресе забора отправления и времени работы офиса.</para>
  /// </summary>
  public static readonly AdditionalService Sms = new(code: "SMS");

  /// <summary>
  /// <para>Подъем на этаж ручной</para>
  /// <para>Ручной подъем на этаж, есть доп. параметр количество этажей</para>
  /// </summary>
  public static readonly AdditionalService GetUpFloorByHand = new(code: "GET_UP_FLOOR_BY_HAND");

  /// <summary>
  /// <para>Подъем на этаж лифтом</para>
  /// <para>Подъем на лифте на этаж, без доп. параметра (ограничение 150кг)</para>
  /// </summary>
  public static readonly AdditionalService GetUpFloorByElevator = new(code: "GET_UP_FLOOR_BY_ELEVATOR");

  /// <summary>
  ///   <para>Прозвон</para>
  ///   <para>Каналы коммуникации с клиентом для согласования даты доставки, определяются исполнителем прозвона (роботизированный звонок, мессенджер, смс уведомление, звонок оператора и т.д.)</para>
  ///   <para>По заказу ежедневно осуществляется минимум 3 попытки дозвона(связи с получателем), при неудачной попытки дозвона, доп. услуга "Прозвон" переносится на следующий день, параллельно на эл.почту Плательщика направляется уведомление о не дозвоне с рекомендацией скорректировать номер телефона получателя.</para>
  ///   <para>Попытки дозвона получателю осуществляются в течение 14 дней, в случае не дозвона, по истечении срока хранения груз уходит на возврат.</para>
  ///   <para>Только для договоров с типом "ИМ"</para>
  /// </summary>
  public static readonly AdditionalService Call = new(code: "CALL");

  /// <summary>
  ///   <para>Тепловой режим</para>
  ///   <para>Услуга доступна только с режимом доставки склад-склад.</para>
  ///   <para>Направления, по которым возможна доставка с тепловым режимом: Кемерово-Новокузнецк, Новосибирск-Красноярск, Новосибирск-Кемерово, Новосибирск-Томск, Новосибирск-Омск, Новосибирск-Барнаул, Барнаул-Горно-Алтайск И в обратных направлениях.</para>
  /// </summary>
  public static readonly AdditionalService TherminalMode = new(code: "THERMAL_MODE");

  /// <summary>
  ///   <para>Пакет курьерский А2</para>
  /// </summary>
  public static readonly AdditionalService CourierPackageA2 = new(code: "COURIER_PACKAGE_A2");

  /// <summary>
  ///   <para>Уведомление о создании заказа в СДЭК</para>
  ///   <para>Применяется при создании заказа.</para>
  ///   <para>Страны города получателя: Россия, Казахстан, Беларусь</para>
  /// </summary>
  public static readonly AdditionalService NotifyOrderCreated = new(code: "NOTIFY_ORDER_CREATED");

  /// <summary>
  ///   <para>Уведомление о приеме заказа на доставку</para>
  ///   <para>Применяется при создании заказа.</para>
  ///   <para>Страны города получателя: Россия, Казахстан, Беларусь</para>
  /// </summary>
  public static readonly AdditionalService NotifyOrderDelivery = new(code: "NOTIFY_ORDER_DELIVERY");

  /// <summary>
  ///   <para>Коробка XS (0,5 кг 17х12х9 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 170*125*95 мм. Максимальная вместимость - 0,5 кг.</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService CartonBoxXs = new(code: "CARTON_BOX_XS");

  /// <summary>
  ///   <para>Коробка S (2 кг 23х19х10 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 216*200*110 мм. Максимальная вместимость - 2 кг.</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService CartonBoxS = new(code: "CARTON_BOX_S");

  /// <summary>
  ///   <para>Коробка M (5 кг 33х25х15 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 330*250*155 мм. Максимальная вместимость - 5 кг.</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService CartonBoxM = new(code: "CARTON_BOX_M");

  /// <summary>
  ///   <para>Коробка L (12 кг 31х25х38см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 340*330*264 мм. Максимальная вместимость - 12 кг.</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService CartonBoxL = new(code: "CARTON_BOX_L");

  /// <summary>
  ///   <para>Коробка (1 кг 24х17х10 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 240*170*100 мм. Максимальная вместимость - 1 кг.</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService CartonBox1Kg = new(code: "CARTON_BOX_1KG");

  /// <summary>
  ///   <para>Коробка (2 кг 34х24х10 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 340*240*100 мм. Максимальная вместимость - 2 кг.</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService CartonBox2Kg = new(code: "CARTON_BOX_2KG");

  /// <summary>
  ///   <para>Коробка (3 кг 24х24х21 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 240*240*210 мм. Максимальная вместимость - 3 кг.</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService CartonBox3Kg = new(code: "CARTON_BOX_3KG");

  /// <summary>
  ///   <para>Коробка (5 кг 40х24х21 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 400*240*210 мм. Максимальная вместимость - 5 кг.</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService CartonBox5Kg = new(code: "CARTON_BOX_5KG");

  /// <summary>
  ///   <para>Коробка (10 кг 40х35х28 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 400*350*280 мм. Максимальная вместимость - 10 кг.</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService CartonBox10Kg = new(code: "CARTON_BOX_10KG");

  /// <summary>
  ///   <para>Коробка (15 кг 60х35х29 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 600*350*290 мм. Максимальная вместимость - 15 кг.</para>
  ///   <para>Доступна для всех тарифов от склада(кроме режима "склад-постамат").</para>
  /// </summary>
  public static readonly AdditionalService CartonBox15Kg = new(code: "CARTON_BOX_15KG");

  /// <summary>
  ///   <para>Коробка (20 кг 47х40х43 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 470*400*430 мм. Максимальная вместимость - 20 кг.</para>
  ///   <para>Доступна для всех тарифов от склада(кроме режима "склад-постамат").</para>
  /// </summary>
  public static readonly AdditionalService CartonBox20Kg = new(code: "CARTON_BOX_20KG");

  /// <summary>
  ///   <para>Коробка (30 кг 69х39х42 см)</para>
  ///   <para>Коробка из трехслойного гофрокартона размером 690*390*420 мм. Максимальная вместимость - 30 кг.</para>
  ///   <para>Доступна для всех тарифов от склада(кроме режима "склад-постамат").</para>
  /// </summary>
  public static readonly AdditionalService CartonBox30Kg = new(code: "CARTON_BOX_30KG");

  /// <summary>
  ///   <para>Воздушно-пузырчатая пленка</para>
  ///   <para>Полиэтилен высокого давления, двухслойный. Является дополнительным упаковочным материалом для упаковки отправлений в транспортную упаковку.</para>
  ///   <para>Доступна для всех тарифов от склада.</para>
  /// </summary>
  public static readonly AdditionalService BubbleWrap = new(code: "BUBBLE_WRAP");

  /// <summary>
  ///   <para>Макулатурная бумага</para>
  ///   <para>Упаковочная бумага (макулатурная, класса Е). Ширина 0,42 м. Предназначена для упаковки различных видов отправлений (грузов) и заполнения пустот внутри упаковки</para>
  ///   <para>Доступные режимы: дверь-дверь, дверь склад, склад-дверь, склад-склад, дверь-постамат, склад-постамат</para>
  /// </summary>
  public static readonly AdditionalService WastePaper = new(code: "WASTE_PAPER");

  /// <summary>
  ///   <para>Прессованный картон "филлер" (55х14х2,3 см)</para>
  ///   <para>Вставка защитная из листового прессованного картона. Применяется для:</para>
  ///   <para>- внутренней обрешетки внутри гофрокороба</para>
  ///   <para>- оборачивания и разделения вложений внутри гофрокороба</para>
  ///   <para>- заполнения пустот.</para>
  ///   <para>Доступна для всех тарифов от склада.</para>
  /// </summary>
  public static readonly AdditionalService CartonFiller = new(code: "CARTON_FILLER");

  /// <summary>
  ///   <para>Фото документов</para>
  ///   <para>Предназначена для выполнения доставок продуктов (грузы, документы), с идентификацией получателя, фотографированием товара клиента/подписанных документов.</para>
  ///   <para>Услуга доступна при наличии услуги в Договоре и настроенном Фотопроекте/шаблоне заданий.</para>
  ///   <para>Услуга платная, условия уточняйте у своего менеджера.</para>
  /// </summary>
  public static readonly AdditionalService PhotoOfDocuments = new(code: "PHOTO_OF_DOCUMENTS");

  /// <summary>
  ///   <para>Товары 18+</para>
  ///   <para>Сервис проверки возраста получателя (товары 18+)</para>
  ///   <para>Услуга предлагается в доступных только при наличии в  договоре признака 18+.</para>
  /// </summary>
  public static readonly AdditionalService AdultGoods = new(code: "ADULT_GOODS");

  /// <summary>
  ///   <para>НЕГАБАРИТНЫЙ ГРУЗ</para>
  ///   <para>При доставке негабаритного отправления, размер одной из сторон которого превышает 1,5 м, тариф увеличивается на 60 % (если отправление рассчитывается не по объемному весу). При доставке негабаритного отправления, размер одной из сторон которого превышает 2,2 м, тариф увеличивается на 100 % (если отправление рассчитывается не по объемному весу). Самостоятельно добавлять запрещено, начисляется автоматически.</para>
  ///   <para>Не применяется, если расчет тарифа идет по объемному весу(когда расчетный вес — это объемный вес)</para>
  /// </summary>
  public static readonly AdditionalService OversizeCargo = new(code: "OVERSIZE_CARGO");

  /// <summary>
  ///   <para>ТЯЖЕЛЫЙ ГРУЗ</para>
  ///   <para>При отправке тяжелых грузов, - если вес 1 места составляет от 75 до 200 кг, то тариф увеличивается на 18 руб за каждый килограмм, - если вес 1 места более 200 кг, то тариф увеличивается на 25 руб. за каждый килограмм. Также возможен индивидуальный расчет стоимости доставки тяжелых грузов. Тарифы на такие отправления будут рассчитаны индивидуально и в короткие сроки (не более 1 рабочего дня) и могут быть значительно дешевле наших базовых тарифов. Самостоятельно добавлять запрещено, начисляется автоматически.</para>
  /// </summary>
  public static readonly AdditionalService HeavyCargo = new(code: "HEAVY_CARGO");

  /// <summary>
  ///   <para>Погрузо-разгрузочные работы у отправителя</para>
  ///   <para>Погрузка и разгрузка по адресу клиента, если вес грузовых мест не превышает 80 кг.</para>
  /// </summary>
  public static readonly AdditionalService LoadingOperationsAtSender = new(code: "LOADING_OPERATIONS_AT_THE_SENDER");

  /// <summary>
  ///   <para>Погрузо-разгрузочные работы у получателя</para>
  ///   <para>Погрузка и разгрузка по адресу клиента, если вес грузовых мест не превышает 80 кг.</para>
  /// </summary>
  public static readonly AdditionalService LoadOperationAtRecipient = new(code: "LOAD_THE_OPERATION_AT_THE_RECIPIENT");
}
