// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

[JsonConverter(typeof(RequestTypeJsonConverter))]
public readonly struct RequestType
{
  private RequestType(string code) => Code = code;

  private string Code { get; }

  public override string ToString() => Code;

  private static RequestType From(string? code)
  {
    if (code == RequestType.Create.Code) return RequestType.Create;
    if (code == RequestType.Update.Code) return RequestType.Update;
    if (code == RequestType.Delete.Code) return RequestType.Delete;
    if (code == RequestType.Auth.Code  ) return RequestType.Auth;
    if (code == RequestType.Get.Code   ) return RequestType.Get;

    throw new Exception($"Invalid code {code} to create RequestType");
  }

  public static explicit operator RequestType(string? code) => RequestType.From(code);
  public static implicit operator string(RequestType value) => value.Code;

  public static readonly RequestType Create = new(code: "CREATE");
  public static readonly RequestType Update = new(code: "UPDATE");
  public static readonly RequestType Delete = new(code: "DELETE");
  public static readonly RequestType Auth = new(code: "AUTH");
  public static readonly RequestType Get = new(code: "GET");
}
