// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Xunit;

namespace System.Globalization.Tests
{
    public class NumberFormatInfoCurrencyPositivePattern
    {
        public static IEnumerable<object[]> CurrencyPositivePattern_TestData()
        {
            yield return new object[] { NumberFormatInfo.InvariantInfo, 0 };
            yield return new object[] { CultureInfo.GetCultureInfo("en-US").NumberFormat, 0 };
            yield return new object[] { CultureInfo.GetCultureInfo("fr-FR").NumberFormat, 3 };
        }

        [Theory]
        [MemberData(nameof(CurrencyPositivePattern_TestData))]
        public void CurrencyPositivePattern_Get_ReturnsExpected(NumberFormatInfo format, int expected)
        {
            Assert.Equal(expected, format.CurrencyPositivePattern);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void CurrencyPositivePattern_Set_GetReturnsExpected(int newCurrencyPositivePattern)
        {
            NumberFormatInfo format = new NumberFormatInfo();
            format.CurrencyPositivePattern = newCurrencyPositivePattern;
            Assert.Equal(newCurrencyPositivePattern, format.CurrencyPositivePattern);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(4)]
        public void CurrencyPositivePattern_SetInvalid_ThrowsArgumentOutOfRangeException(int value)
        {
            var format = new NumberFormatInfo();
            AssertExtensions.Throws<ArgumentOutOfRangeException>("value", "CurrencyPositivePattern", () => format.CurrencyPositivePattern = value);
        }

        [Fact]
        public void CurrencyPositivePattern_SetReadOnly_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => NumberFormatInfo.InvariantInfo.CurrencyPositivePattern = 1);
        }
    }
}
