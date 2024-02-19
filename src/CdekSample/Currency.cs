// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

/// <summary>
/// Валюта
/// </summary>
/// <param name="Code">Код</param>
/// <param name="CurrencyCode">Код валюты</param>
public readonly record struct Currency(int Code, string CurrencyCode)
{
  public Currency(): this(0, "None") { }

  public override string ToString() => CurrencyCode;

  /// <summary>
  /// Значение по умолчанию
  /// </summary>
  public static Currency None => new();

  /// <summary>
  /// Российский рубль
  /// </summary>
  public static Currency Rouble => new(Code: 1, CurrencyCode: "RUB");

  /// <summary>
  /// Тенге
  /// </summary>
  public static Currency Tenge => new(Code: 2, CurrencyCode: "KZT");

  /// <summary>
  /// Доллар США
  /// </summary>
  public static Currency Dollar => new(Code: 3, CurrencyCode: "Dollar");

  /// <summary>
  /// Евро
  /// </summary>
  public static Currency Euro => new(Code: 4, CurrencyCode: "EUR");

  /// <summary>
  /// Фунт Стерлингов
  /// </summary>
  public static Currency PoundSterling => new (Code: 5, CurrencyCode: "GBP");

  /// <summary>
  /// Китайский юань
  /// </summary>
  public static Currency Yuan => new(Code: 6, CurrencyCode: "CNY");

  /// <summary>
  /// Белорусский рубль
  /// </summary>
  public static Currency BelarusianRouble => new (Code: 7, CurrencyCode: "BYR");

  /// <summary>
  /// Гривна
  /// </summary>
  public static Currency Hryvnia => new(Code: 8, CurrencyCode: "UAH");

  /// <summary>
  /// Киргизский сом
  /// </summary>
  public static Currency KyrgyzstaniSom => new (Code: 9, CurrencyCode: "KGS");

  /// <summary>
  /// Армянский драм
  /// </summary>
  public static Currency ArmenianDram => new (Code: 10, CurrencyCode: "AMD");

  /// <summary>
  /// Турецкая лира
  /// </summary>
  public static Currency TurkishLira => new(Code: 11, CurrencyCode: "TRY");

  /// <summary>
  /// Тайский бат
  /// </summary>
  public static Currency ThaiBaht => new (Code: 12, CurrencyCode: "THB");

  /// <summary>
  /// Вон
  /// </summary>
  public static Currency Won => new(Code: 13, CurrencyCode: "KRW");

  /// <summary>
  /// Дирхам
  /// </summary>
  public static Currency Dirham => new(Code: 14, CurrencyCode: "AED");

  /// <summary>
  /// Узбекский сум
  /// </summary>
  public static Currency Sum => new(Code: 15, CurrencyCode: "UZS");

  /// <summary>
  /// Тугрик
  /// </summary>
  public static Currency Tugrik => new(Code: 16, CurrencyCode: "MNT");

  /// <summary>
  /// Злотый
  /// </summary>
  public static Currency Zloty => new(Code: 17, CurrencyCode: "PLN");

  /// <summary>
  /// Манат
  /// </summary>
  public static Currency Manat => new(Code: 18, CurrencyCode: "AZN");

  /// <summary>
  /// Лари
  /// </summary>
  public static Currency Lari => new(Code: 19, CurrencyCode: "GEL");

  /// <summary>
  /// Японская йена
  /// </summary>
  public static Currency JapaneseYen => new (Code: 55, CurrencyCode: "JPY");
}
