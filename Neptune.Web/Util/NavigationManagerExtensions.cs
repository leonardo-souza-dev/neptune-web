﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Web.Util
{
    public static class NavigationManagerExtensions
    {
        public static bool TryGetQueryString<T>(this NavigationManager navManager, string key, out T value)
        {
            var uri = navManager.ToAbsoluteUri(navManager.Uri);

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(key, out var valueFromQueryString))
            {
                if (typeof(T) == typeof(int) && int.TryParse(valueFromQueryString, out var valueAsInt))
                {
                    value = (T)(object)valueAsInt;
                    return true;
                }

                if (typeof(T) == typeof(string))
                {
                    value = (T)(object)valueFromQueryString.ToString();
                    return true;
                }

                if (typeof(T) == typeof(decimal) && decimal.TryParse(valueFromQueryString, out var valueAsDecimal))
                {
                    value = (T)(object)valueAsDecimal;
                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}
