// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Валюта
/// </summary>
/// <param name="Code">Код</param>
/// <param name="CurrencyCode">Код валюты</param>
[JsonConverter(typeof(CurrencyJsonConverter))]
public readonly record struct Currency
{
  private Currency(int code, string currency) => (Code, CurrencyCode) = (code, currency);

  private int Code { get; }

  /// <summary>
  /// Имя для логгирования
  /// </summary>
  private string CurrencyCode { get; }

  public override string ToString() => CurrencyCode;

  private static Currency From(int code)
  {
    if (code == Currency.RussianRouble.Code   ) return Currency.RussianRouble;
    if (code == Currency.Tenge.Code           ) return Currency.Tenge;
    if (code == Currency.Dollar.Code          ) return Currency.Dollar;
    if (code == Currency.Euro.Code            ) return Currency.Euro;
    if (code == Currency.PoundSterling.Code   ) return Currency.PoundSterling;
    if (code == Currency.Yuan.Code            ) return Currency.Yuan;
    if (code == Currency.BelarusianRouble.Code) return Currency.BelarusianRouble;
    if (code == Currency.Hryvnia.Code         ) return Currency.Hryvnia;
    if (code == Currency.KyrgyzstaniSom.Code  ) return Currency.KyrgyzstaniSom;
    if (code == Currency.ArmenianDram.Code    ) return Currency.ArmenianDram;
    if (code == Currency.TurkishLira.Code     ) return Currency.TurkishLira;
    if (code == Currency.ThaiBaht.Code        ) return Currency.ThaiBaht;
    if (code == Currency.Won.Code             ) return Currency.Won;
    if (code == Currency.Dirham.Code          ) return Currency.Dirham;
    if (code == Currency.Sum.Code             ) return Currency.Sum;
    if (code == Currency.Tugrik.Code          ) return Currency.Tugrik;
    if (code == Currency.Zloty.Code           ) return Currency.Zloty;
    if (code == Currency.Manat.Code           ) return Currency.Manat;
    if (code == Currency.Lari.Code            ) return Currency.Lari;
    if (code == Currency.JapaneseYen.Code     ) return Currency.JapaneseYen;

    throw new Exception($"Invalid CDEK code to create Currency: {code}");
  }

  public static implicit operator Currency(int code)     => Currency.From(code);
  public static implicit operator int(Currency currency) => currency.Code;

  /// <summary>
  /// Российский рубль
  /// </summary>
  public static readonly Currency RussianRouble = new(code: 1, currency: "RUB");

  /// <summary>
  /// Тенге
  /// </summary>
  public static readonly Currency Tenge = new(code: 2, currency: "KZT");

  /// <summary>
  /// Доллар США
  /// </summary>
  public static readonly Currency Dollar = new(code: 3, currency: "Dollar");

  /// <summary>
  /// Евро
  /// </summary>
  public static readonly Currency Euro = new(code: 4, currency: "EUR");

  /// <summary>
  /// Фунт Стерлингов
  /// </summary>
  public static Currency PoundSterling = new (code: 5, currency: "GBP");

  /// <summary>
  /// Китайский юань
  /// </summary>
  public static readonly Currency Yuan = new(code: 6, currency: "CNY");

  /// <summary>
  /// Белорусский рубль
  /// </summary>
  public static readonly Currency BelarusianRouble = new (code: 7, currency: "BYR");

  /// <summary>
  /// Гривна
  /// </summary>
  public static readonly Currency Hryvnia = new(code: 8, currency: "UAH");

  /// <summary>
  /// Киргизский сом
  /// </summary>
  public static readonly Currency KyrgyzstaniSom = new (code: 9, currency: "KGS");

  /// <summary>
  /// Армянский драм
  /// </summary>
  public static readonly Currency ArmenianDram = new (code: 10, currency: "AMD");

  /// <summary>
  /// Турецкая лира
  /// </summary>
  public static readonly Currency TurkishLira = new(code: 11, currency: "TRY");

  /// <summary>
  /// Тайский бат
  /// </summary>
  public static readonly Currency ThaiBaht = new (code: 12, currency: "THB");

  /// <summary>
  /// Вон
  /// </summary>
  public static readonly Currency Won = new(code: 13, currency: "KRW");

  /// <summary>
  /// Дирхам
  /// </summary>
  public static readonly Currency Dirham = new(code: 14, currency: "AED");

  /// <summary>
  /// Узбекский сум
  /// </summary>
  public static readonly Currency Sum = new(code: 15, currency: "UZS");

  /// <summary>
  /// Тугрик
  /// </summary>
  public static readonly Currency Tugrik = new(code: 16, currency: "MNT");

  /// <summary>
  /// Злотый
  /// </summary>
  public static readonly Currency Zloty = new(code: 17, currency: "PLN");

  /// <summary>
  /// Манат
  /// </summary>
  public static readonly Currency Manat = new(code: 18, currency: "AZN");

  /// <summary>
  /// Лари
  /// </summary>
  public static readonly Currency Lari = new(code: 19, currency: "GEL");

  /// <summary>
  /// Японская йена
  /// </summary>
  public static readonly Currency JapaneseYen = new (code: 55, currency: "JPY");
}
