using System.Collections.Generic;
using System.Linq;

using Assets.Utils;

using UnityEngine;

public static class BaseballTeamNameGenerator
{
    // ReSharper disable StringLiteralTypo
    public static readonly string[] Teams =
    {
        "108 Stitches", "12 Angry Men", "12 Angry Mets", "18 Legs", "7th Inning Stretchers", "Aces Of Bases",
        "All Star Team Runner Ups", "Angels In The Outfield", "Around-the-Horn", "Backup Relief Pitchers",
        "Balk and Key", "Balk and Roll", "Balk Bottom", "Balk Choy", "Balk Dirty To Me", "Balk Like An Egyptian",
        "Balk Monkeys", "Balk Naked", "Balk of Ages", "Balk Paper Scissors", "Balk Stars", "Balk the Casbah",
        "Balking Dead", "Balkingbirds", "Balkingjays", "Balkturnal Animals", "Ball Breakers", "Ball of Duty",
        "Ballas", "Ballers", "Balls To The Walls", "Barbed Wire Baseball Bats", "Base Explorers", "Base Invaders",
        "Base Odyssey", "Base Stealers", "Base-ic Instincts", "Base-ic Pitches", "Bat and Boujee", "Bat Attitudes",
        "Bat Country", "Bat Crackers", "Bat Guys", "Bat Intentions", "Bat Simpsons", "Bat To The Bones",
        "Bat-ra Kadabra", "Batmen", "Battering Rams", "Beauty and The Cleats", "Belles of The Ball",
        "Belly Itchers", "Benchwarmers", "Between A Walk And Hard Place", "Big Gloves", "Bloody Sox",
        "Blue Ballers", "Blurred Foul Lines", "Brokebat Mountains", "Built it, They Never Came", "Bullpen Busters",
        "Bunt Cakes", "Bunt Force Trauma", "Bunt Objects", "Catchers In the Rye", "Caught Looking", "Changeups",
        "Checked Swings", "Chin Musicians", "Clean Up Hitters", "Cleat and Tidy", "Cleat Around The Bush",
        "Cleat Yo’Self", "Cleats Of Fire", "Comfortably Gloved", "Corked Bats", "Cut Off Men", "Designated Hitters",
        "Diamond Cutters", "Diamond Thieves", "Dingers", "Dirt Bags", "Dirt Devils", "Dirt Dogs", "Dirt Magnets",
        "Dirty Dozen", "Dirty Sox", "Don’t Stop Ballieving", "Double Plays", "Dugout Demons", "Expendaballs",
        "Extra Bases With Happy Faces", "Eyelash Batters", "Farm System Fans", "Fastballs", "Fever Pitches",
        "Field of Memes", "Field of Nightmares", "Field of Seams", "Flame-Throwers", "Fly Balls", "Fly Guys",
        "Foul Balls", "Foul Poles", "Foul Tips", "Friendly Confines", "Full Counts", "Game Throwers",
        "Girls Just Want To Have Runs", "Glove Bugs", "Glove Handles", "Glove Of The Game", "Glove Potion #9",
        "Glovers", "Gone Batty", "Gone With The Win", "Grand Salamis", "Grand Slams", "Great Balls of Fire",
        "Greatest Game On Dirt", "Ground Ballers", "Hall of Shamers", "Happy Feet", "Hit and Runs",
        "Hit By Pitches", "Hit For Brains", "Hit Talkers", "Hitmen", "Homerun Simpsons", "Ice Cold Pitchers",
        "Inglorious Batters", "Intentional Walkers", "It’s All About That Base", "Just A Bit Outsiders",
        "Laser Show", "Leather Flashers", "Light Sabermetrics", "Line Drivers", "Long Ballers", "Mad Batters",
        "Master Batters", "McGlovin", "Meet The Balkers", "Men of Steal", "Minor Leaguers", "No Hit Sherlocks",
        "On Deck Circles", "One Hit Wonders", "Pancake Batters", "Pass The Balk", "Performance Enhancing Hugs",
        "Pinch Hitters", "Pinch Runners", "Pink Sox", "Pitch Better Have My Money", "Pitch Perfect",
        "Play At The Plates", "Popup Flies", "Relief Pitchers", "Ribbies – RBIs", "Runners At The Corners",
        "Running Dead", "Sac Flies", "Sacrifice Bunts", "Sandlot B-Team", "Saved By The Balls", "Scared Hitless",
        "Screwballs", "Sign Stealers", "Sliders", "Smack My Pitch Up", "Smelly Sox", "Smoking Bunts", "Sole Mates",
        "Sole Sisters", "Sons of Pitches", "Special K’s", "Spitballs", "Splinters", "Stain Removers",
        "Stick Wielders", "Strangegloves", "Strike Zones", "Sultans of Swat", "Sultans Of Swing",
        "Swing And A Miss", "Swingers", "Teach Me How To Dugout", "The Balk Stops Here", "The Three Up Three Downs",
        "The Unusual Suspects", "There’s No Base Like Home", "Triple A All-Stars", "Umpire Strikes Back",
        "Untouchaballs", "We Got The Runs", "We Were Giants", "We Will Balk You", "We’re On Strike",
        "Weakened Warriors", "Web Gems", "Webmasters", "Wet Sox", "Wood Chuckers", "Yager Bombers",
        "Your Base or Mine?"
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