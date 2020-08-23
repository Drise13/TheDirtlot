using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public static class LeagueNameGenerator
{
    // ReSharper disable StringLiteralTypo
    public static readonly string[] Teams =
    {
        "Algiers",
        "Atlanta",
        "Baghdad",
        "Bangkok",
        "Beijing",
        "Bogota",
        "Buenos Aries",
        "Cairo",
        "Chennai",
        "Chicago",
        "Delhi",
        "Essen",
        "Ho Chi Minh City",
        "Hong Kong",
        "Istanbul",
        "Jakarta",
        "Johannesburg",
        "Karachi",
        "Khartoum",
        "Kinshasa",
        "Kolkata",
        "Lagos",
        "Lima",
        "London",
        "Los Angeles",
        "Madrid",
        "Manila",
        "Mexico City",
        "Miami",
        "Milan",
        "Montreal",
        "Moscow",
        "Mumbai",
        "New York",
        "Osaka",
        "Paris",
        "Riyadh",
        "San Francisco",
        "Santiago",
        "Sao Paulo",
        "Seoul",
        "Shanghai",
        "St. Petersburg",
        "Sydney",
        "Taipei",
        "Tehran",
        "Tokyo",
        "Washington"
    };

    // ReSharper enable StringLiteralTypo

    public static IEnumerable<string> GetNames(int count)
    {
        var selected = new List<int>();

        return Enumerable.Range(0, count).Select(i =>
        {
            // TODO revisit this for performance
            int selection;

            do
            {
                selection = Random.Range(0, Teams.Length);
            } while (selected.Contains(selection));

            selected.Add(selection);

            return Teams[selection];
        });
    }
}