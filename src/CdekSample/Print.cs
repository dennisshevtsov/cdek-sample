// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public readonly struct Print
{
  private Print(string code) => Code = code;

  private string Code { get; }

  public override string ToString() => Code;

  private static Print From(string? code)
  {
    if (code == Print.Barcode.Code) return Print.Barcode;
    if (code == Print.Waybill.Code) return Print.Waybill;

    throw new Exception("Invalid code to create Print");
  }

  public static explicit operator Print(string? code)   => Print.From(code);
  public static implicit operator string(Print printer) => printer.Code;

  /// <summary>
  /// ШК мест (число копий - 1)
  /// </summary>
  public static readonly Print Barcode = new(code: "barcode");

  /// <summary>
  /// квитанция (число копий - 2)
  /// </summary>
  public static readonly Print Waybill = new(code: "waybill ");
}
