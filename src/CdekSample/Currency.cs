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
public readonly record struct Currency(int Code, string CurrencyCode)
{
  public Currency() : this(0, "None") { }

  public static Currency From(int code)
  {
    if (code == Currency.None.Code            ) return Currency.None;
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

    throw new Exception("Invalid code");
  }

  public static implicit operator Currency(int code) => Currency.From(code);

  public override string ToString() => CurrencyCode;

  /// <summary>
  /// Значение по умолчанию
  /// </summary>
  public static readonly Currency None = new();

  /// <summary>
  /// Российский рубль
  /// </summary>
  public static readonly Currency RussianRouble = new(Code: 1, CurrencyCode: "RUB");

  /// <summary>
  /// Тенге
  /// </summary>
  public static readonly Currency Tenge = new(Code: 2, CurrencyCode: "KZT");

  /// <summary>
  /// Доллар США
  /// </summary>
  public static readonly Currency Dollar = new(Code: 3, CurrencyCode: "Dollar");

  /// <summary>
  /// Евро
  /// </summary>
  public static readonly Currency Euro = new(Code: 4, CurrencyCode: "EUR");

  /// <summary>
  /// Фунт Стерлингов
  /// </summary>
  public static Currency PoundSterling = new (Code: 5, CurrencyCode: "GBP");

  /// <summary>
  /// Китайский юань
  /// </summary>
  public static readonly Currency Yuan = new(Code: 6, CurrencyCode: "CNY");

  /// <summary>
  /// Белорусский рубль
  /// </summary>
  public static readonly Currency BelarusianRouble = new (Code: 7, CurrencyCode: "BYR");

  /// <summary>
  /// Гривна
  /// </summary>
  public static readonly Currency Hryvnia = new(Code: 8, CurrencyCode: "UAH");

  /// <summary>
  /// Киргизский сом
  /// </summary>
  public static readonly Currency KyrgyzstaniSom = new (Code: 9, CurrencyCode: "KGS");

  /// <summary>
  /// Армянский драм
  /// </summary>
  public static readonly Currency ArmenianDram = new (Code: 10, CurrencyCode: "AMD");

  /// <summary>
  /// Турецкая лира
  /// </summary>
  public static readonly Currency TurkishLira = new(Code: 11, CurrencyCode: "TRY");

  /// <summary>
  /// Тайский бат
  /// </summary>
  public static readonly Currency ThaiBaht = new (Code: 12, CurrencyCode: "THB");

  /// <summary>
  /// Вон
  /// </summary>
  public static readonly Currency Won = new(Code: 13, CurrencyCode: "KRW");

  /// <summary>
  /// Дирхам
  /// </summary>
  public static readonly Currency Dirham = new(Code: 14, CurrencyCode: "AED");

  /// <summary>
  /// Узбекский сум
  /// </summary>
  public static readonly Currency Sum = new(Code: 15, CurrencyCode: "UZS");

  /// <summary>
  /// Тугрик
  /// </summary>
  public static readonly Currency Tugrik = new(Code: 16, CurrencyCode: "MNT");

  /// <summary>
  /// Злотый
  /// </summary>
  public static readonly Currency Zloty = new(Code: 17, CurrencyCode: "PLN");

  /// <summary>
  /// Манат
  /// </summary>
  public static readonly Currency Manat = new(Code: 18, CurrencyCode: "AZN");

  /// <summary>
  /// Лари
  /// </summary>
  public static readonly Currency Lari = new(Code: 19, CurrencyCode: "GEL");

  /// <summary>
  /// Японская йена
  /// </summary>
  public static readonly Currency JapaneseYen = new (Code: 55, CurrencyCode: "JPY");
}
