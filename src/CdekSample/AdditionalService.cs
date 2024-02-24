// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public readonly record struct AdditionalService
{
  public AdditionalService(): this(code: "NONE") { }

  private AdditionalService(string code) => Code = code;

  private string Code { get; }

  public override string ToString() => Code;

  private static readonly Dictionary<string, AdditionalService> _services = new()
  {
    { AdditionalService.None.Code                    , AdditionalService.None                     },
    { AdditionalService.Insurance.Code               , AdditionalService.Insurance                },
    { AdditionalService.TakeFromSender.Code          , AdditionalService.TakeFromSender           },
    { AdditionalService.DeliveryToReceiver.Code      , AdditionalService.DeliveryToReceiver       },
    { AdditionalService.TryingOn.Code                , AdditionalService.TryingOn                 },
    { AdditionalService.PartialDelivery.Code         , AdditionalService.PartialDelivery          },
    { AdditionalService.BanAttachmentInsperation.Code, AdditionalService.BanAttachmentInsperation },
    { AdditionalService.Reverse.Code                 , AdditionalService.Reverse                  },
    { AdditionalService.DangerCargo.Code             , AdditionalService.DangerCargo              },
    { AdditionalService.Sms.Code                     , AdditionalService.Sms                      },
    { AdditionalService.GetUpFloorByHand.Code        , AdditionalService.GetUpFloorByHand         },
    { AdditionalService.GetUpFloorByElevator.Code    , AdditionalService.GetUpFloorByElevator     },
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
}
