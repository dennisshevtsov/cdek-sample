// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Buffers;

namespace CdekSample;

/// <summary>
/// Запрос на получение списка населенных пунктов
/// </summary>
/// <param name="CountryCodes">Массив кодов стран в формате  ISO_3166-1_alpha-2</param>
/// <param name="RegionCode">Код региона СДЭК</param>
/// <param name="FiasGuid">Уникальный идентификатор ФИАС населенного пункта</param>
/// <param name="PostalCode">Почтовый индекс</param>
/// <param name="Code">Код населенного пункта СДЭК</param>
/// <param name="City">Название населенного пункта. Должно соответствовать полностью</param>
/// <param name="Size">Ограничение выборки результата. По умолчанию 1000</param>
/// <param name="Page">Номер страницы выборки результата. По умолчанию 0</param>
/// <param name="Language">Язык локализации ответа</param>
/// <param name="PaymentLimit">
///   <para>Ограничение на сумму наложенного платежа:</para>
///   <para>-1 - ограничения нет;</para>
///   <para>0 - наложенный платеж не принимается;</para>
/// </param>
public sealed record class CityRequest
(
  string[]?     CountryCodes = default,
  int?            RegionCode = default,
  Guid?             FiasGuid = default,
  string?         PostalCode = default,
  int?                  Code = default,
  string?               City = default,
  int?                  Size = default,
  int?                  Page = default,
  Language          Language = default,
  PaymentLimit? PaymentLimit = default
)
{
  public Uri ToUri()
  {
    int count = 1 // 1 route
                + CountParameters()
                * 3 // each parameter = name + value + & = 3
                - 1; // last parameter witout &

    if (count == 0)
    {
      return new Uri(string.Empty);
    }

    string[] segments = ArrayPool<string>.Shared.Rent(count);
    int index = 0;

    segments[index++] = "v2/location/cities";

    if (CountryCodes is not null)
    {
      segments[index++] = "country_codes=";
      segments[index++] = CountryCodes[0];
      segments[index++] = "&";
    }

    if (RegionCode is not null)
    {
      segments[index++] = "region_code=";
      segments[index++] = RegionCode.Value.ToString();
      segments[index++] = "&";
    }

    if (FiasGuid is not null)
    {
      segments[index++] = "fias_guid=";
      segments[index++] = FiasGuid.Value.ToString();
      segments[index++] = "&";
    }

    if (PostalCode is not null)
    {
      segments[index++] = "postal_code=";
      segments[index++] = PostalCode.ToString();
      segments[index++] = "&";
    }

    if (Code is not null)
    {
      segments[index++] = "code=";
      segments[index++] = Code.Value.ToString();
      segments[index++] = "&";
    }

    if (City is not null)
    {
      segments[index++] = "city=";
      segments[index++] = City.ToString();
      segments[index++] = "&";
    }

    if (Size is not null)
    {
      segments[index++] = "size=";
      segments[index++] = Size.Value.ToString();
      segments[index++] = "&";
    }

    if (Page is not null)
    {
      segments[index++] = "page=";
      segments[index++] = Page.Value.ToString();
      segments[index++] = "&";
    }

    if (Language != Language.None)
    {
      segments[index++] = "lang=";
      segments[index++] = Language.ToString();
      segments[index++] = "&";
    }

    if (PaymentLimit is not null)
    {
      segments[index++] = "payment_limit=";
      segments[index++] = PaymentLimit.Value.ToString();
      segments[index++] = "&";
    }

    segments = segments[..(index - 2)];
    return new Uri(string.Concat(segments));
  }

  private int CountParameters()
  {
    int count = 0;

    if (CountryCodes is not null)
    {
      count += CountryCodes.Length;
    }

    if (RegionCode   is not null     ) count++;
    if (FiasGuid     is not null     ) count++;
    if (PostalCode   is not null     ) count++;
    if (Code         is not null     ) count++;
    if (City         is not null     ) count++;
    if (Size         is not null     ) count++;
    if (Page         is not null     ) count++;
    if (Language     != Language.None) count++;
    if (PaymentLimit is not null     ) count++;

    return count;
  }
}
