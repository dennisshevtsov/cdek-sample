// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class Contact
(
  string                         Name,
  Phone[]                      Phones,
  string?                     Company = null,
  string?                       Email = null,
  string?              PassportSeries = null,
  string?              PassportNumber = null,
  DateTimeOffset? PassportDateOfIssue = null,
  string?        PassportOrganization = null,
  string?                         Tin = null,
  DateTimeOffset? PassportDateOfBirth = null,
  bool? PassportRequirementsSatisfied = null
)
{
  [JsonPropertyName("company")]
  [JsonPropertyOrder(1)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Company { get; } = Company;

  [JsonPropertyName("name")]
  [JsonPropertyOrder(2)]
  public string Name { get; } = Name;

  [JsonPropertyName("email")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Email { get; } = Email;

  [JsonPropertyName("threshold")]
  [JsonPropertyOrder(4)]
  public Phone[] Phones { get; } = Phones;

  [JsonPropertyName("passport_series")]
  [JsonPropertyOrder(5)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? PassportSeries { get; } = PassportSeries;

  [JsonPropertyName("passport_number")]
  [JsonPropertyOrder(6)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? PassportNumber { get; } = PassportNumber;

  [JsonPropertyName("passport_date_of_issue")]
  [JsonPropertyOrder(7)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public DateTimeOffset? PassportDateOfIssue { get; } = PassportDateOfIssue;

  [JsonPropertyName("passport_organization")]
  [JsonPropertyOrder(8)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? PassportOrganization { get; } = PassportOrganization;

  [JsonPropertyName("passport_date_of_birth")]
  [JsonPropertyOrder(9)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public DateTimeOffset? PassportDateOfBirth { get; } = PassportDateOfBirth;

  [JsonPropertyName("tin")]
  [JsonPropertyOrder(10)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Tin { get; } = Tin;

  [JsonPropertyName("passport_requirements_satisfied")]
  [JsonPropertyOrder(11)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public bool? PassportRequirementsSatisfied { get; } = PassportRequirementsSatisfied;
}
