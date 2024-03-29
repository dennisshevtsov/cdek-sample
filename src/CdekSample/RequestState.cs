// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

public readonly struct RequestState
{
  private RequestState(string code) => Code = code;

  private string Code { get; }

  public override string ToString() => Code;

  private static RequestState From(string? code)
  {
    if (code == RequestState.Accepted.Code  ) return RequestState.Accepted;
    if (code == RequestState.Waiting.Code   ) return RequestState.Waiting;
    if (code == RequestState.Successful.Code) return RequestState.Successful;
    if (code == RequestState.Invalid.Code   ) return RequestState.Invalid;

    throw new Exception($"Invalid code {code} to create RequestState");
  }

  public static explicit operator RequestState(string? code) => RequestState.From(code);
  public static implicit operator string(RequestState value) => value.Code;

  public static readonly RequestState Accepted   = new(code: "ACCEPTED");
  public static readonly RequestState Waiting    = new(code: "WAITING");
  public static readonly RequestState Successful = new(code: "SUCCESSFUL");
  public static readonly RequestState Invalid    = new(code: "INVALID");
}
