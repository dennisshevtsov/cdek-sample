// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Язык вывода информации о тарифах
/// </summary>
[JsonConverter(typeof(LanguageJsonConverter))]
public readonly record struct Language
{
  private Language(string code) => Code = code;

  private string Code { get; }

  public override string ToString() => Code;

  private static Language From(string? code)
  {
    if (code == Language.Russian.Code) return Language.Russian;
    if (code == Language.English.Code) return Language.English;
    if (code == Language.Chinese.Code) return Language.Chinese;

    throw new Exception($"Invalid code to create Language: {code}");
  }

  public static implicit operator Language(string? code)    => Language.From(code);
  public static implicit operator string(Language language) => language.Code;

  /// <summary>
  /// Русский язык
  /// </summary>
  public static readonly Language Russian = new(code: "rus");

  /// <summary>
  /// Английский язык
  /// </summary>
  public static readonly Language English = new(code: "eng");

  /// <summary>
  /// Китайский язык
  /// </summary>
  public static readonly Language Chinese = new(code: "zho");
}
