using System.Collections.Generic;

public sealed class ConfigLevels
{
    public ConfigLevels()
    {
        Levels[0] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 0, Good luck!",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 10, rubins: 0);

        Levels[1] = new Level(new LevelWave[]
        {
            new LevelWave(
                "It's a good start!",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "But it's not that simple.",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 20, rubins: 1);

        Levels[2] = new Level(new LevelWave[]
        {
            new LevelWave(
                "I have a gift!",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini) }
                )
        }, coins: 15, rubins: 2);

        Levels[3] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Keep practicing",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "Feel this control",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini) }
                )
        }, coins: 20, rubins: 4);

        Levels[4] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Okay, let's try this",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini), new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
        }, coins: 25, rubins: 5);

        Levels[5] = new Level(new LevelWave[]
        {
            new LevelWave(
                "You almost saved up for a copter!",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini), new OneCopter(Config.CoptersInfo.Names.Mini) }
                ),
            new LevelWave(
                "Final push",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 30, rubins: 10);

        Levels[6] = new Level(new LevelWave[]
        {
            new LevelWave(
                "I hope you upgraded the copter",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Quady) }
                )
        }, coins: 30, rubins: 20);

        Levels[7] = new Level(new LevelWave[]
        {
            new LevelWave(
                "I've been good to you",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Quady) }
                ),
            new LevelWave(
                "Isn't it?",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini) }
                )
        }, coins: 50, rubins: 30);

        Levels[8] = new Level(new LevelWave[]
        {
            new LevelWave(
                "But it's time for you to stop",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.K99) }
                )
        }, coins: 45, rubins: 15);

        Levels[9] = new Level(new LevelWave[]
        {
            new LevelWave(
                "I'm serious",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.K99), new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "Wow, you made it through the game!",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 60, rubins: 30);

        Levels[10] = new Level(new LevelWave[]
        {
            new LevelWave(
                "I told you you passed",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Quady) }
                ),
            new LevelWave(
                "Why do you go on?",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.K99) }
                ),
            new LevelWave(
                "Only pain awaits from here on out",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 100, rubins: 50);

        Levels[11] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Well..",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.UralX4) }
                ),
            new LevelWave(
                "You won't pass anyway)",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 70, rubins: 30);

        Levels[12] = new Level(new LevelWave[]
        {
            new LevelWave(
                "With each level...",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Esinturo) }
                ),
            new LevelWave(
                "Your skill is growing",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.UralX4) }
                )
        }, coins: 110, rubins: 45);

        Levels[13] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Is that really what you want?",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini), new OneCopter(Config.CoptersInfo.Names.UralX4) }
                )
        }, coins: 90, rubins: 30);

        Levels[14] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Okay, go ahead",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Esinturo) }
                ),
            new LevelWave(
                "Want more?",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.UralX4) }
                ),
            new LevelWave(
                "WANT MORE???",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 165, rubins: 40);

        Levels[15] = new Level(new LevelWave[]
        {
            new LevelWave(
                "(-_-)",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.K99), new OneCopter(Config.CoptersInfo.Names.UralX4) }
                )
        }, coins: 120, rubins: 50);

        Levels[16] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Good luck with this guy.",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Gruver) }
                )
        }, coins: 110, rubins: 20);

        Levels[17] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Your last level)",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.UralX4), new OneCopter(Config.CoptersInfo.Names.Gruver), new OneCopter(Config.CoptersInfo.Names.Nexter) }
                )
        }, coins: 175, rubins: 40);

        Levels[18] = new Level(new LevelWave[]
        {
            new LevelWave(
                "4",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Nexter) }
                ),
            new LevelWave(
                "Good job!",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.K99) }
                )
        }, coins: 150, rubins: 30);

        Levels[19] = new Level(new LevelWave[]
        {
            new LevelWave(
                "It's not serious",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "I will break you",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Quady) }
                ),
            new LevelWave(
                "No matter how good you are..",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini) }
                ),
            new LevelWave(
                "You're not ready enough.",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.UralX4) }
                )
        }, coins: 320, rubins: 40);

        Levels[20] = new Level(new LevelWave[]
        {
            new LevelWave(
                "You're only saved by balls, right?",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.UralX4), new OneCopter(Config.CoptersInfo.Names.Gruver) }
                ),
            new LevelWave(
                "And I don't mean your balls -_-",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.K99), new OneCopter(Config.CoptersInfo.Names.Mini) }
                )
        }, coins: 275, rubins: 40);

        Levels[21] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Skrill is waiting for you",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP), new OneCopter(Config.CoptersInfo.Names.MXP), new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 290, rubins: 20);

        Levels[22] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Okay, let's forget the whole thing",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Frenhi) }
                ),
            new LevelWave(
                "In fact, you're good",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Gruver) }
                )
        }, coins: 395, rubins: 40);

        Levels[23] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Wow",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Zeptocrust) }
                )
        }, coins: 470, rubins: 30);

        Levels[24] = new Level(new LevelWave[]
        {
            new LevelWave(
                "...",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Frenhi), new OneCopter(Config.CoptersInfo.Names.Zeptocrust) }
                )
        }, coins: 595, rubins: 20);

        Levels[25] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 25",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Zeptocrust) }
                ),
            new LevelWave(
                "Waves 2",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Nexter) }
                )
        }, coins: 565, rubins: 60);

        Levels[26] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 26",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Gpower), new OneCopter(Config.CoptersInfo.Names.Gpower) }
                )
        }, coins: 850, rubins: 40);

        Levels[27] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Hi!",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Frenhi) }
                ),
            new LevelWave(
                "It's me",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Esinturo) }
                ),
            new LevelWave(
                "Your old friend",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Gpower) }
                )
        }, coins: 1050, rubins: 60);

        Levels[28] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Did you miss my meaningless texts?",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.UralX4) }
                ),
            new LevelWave(
                "Ahahahahahhahahahahaaaha",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Gpower), new OneCopter(Config.CoptersInfo.Names.Mini) }
                ),
            new LevelWave(
                "Bye",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Quady) }
                )
        }, coins: 1670, rubins: 20);

        Levels[29] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 29",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Gpower), new OneCopter(Config.CoptersInfo.Names.Mini), new OneCopter(Config.CoptersInfo.Names.Mini) }
                ),
            new LevelWave(
                "Waves 2",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 1450, rubins: 60);

        Levels[30] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 30",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP), new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "Waves 2",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP), new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "Waves 3",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Gpower), new OneCopter(Config.CoptersInfo.Names.Gpower) }
                )
        }, coins: 2700, rubins: 30);

        Levels[31] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 30",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 10, rubins: 1);

        Levels[32] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 29",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini), new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 40, rubins: 40);

        Levels[33] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Ha ha okay just kidding",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Ghost), new OneCopter(Config.CoptersInfo.Names.Ghost), new OneCopter(Config.CoptersInfo.Names.Ghost) }
                )
        }, coins: 4400, rubins: 60);

        Levels[34] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Looks like you're already a dead inside",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Wruver) }
                ),
            new LevelWave(
                "But you're still hanging in there",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Ghost) }
                )
        }, coins: 3950, rubins: 20);

        Levels[35] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 35",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Quady) }
                ),
            new LevelWave(
                "Do you want a joke?",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Nexter) }
                ),
            new LevelWave(
                "'TODO: add a joke'",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Ghost), new OneCopter(Config.CoptersInfo.Names.Ghost) }
                )
        }, coins: 4500, rubins: 40);

        Levels[36] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 36",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.DDY930) }
                ),
            new LevelWave(
                "I'm just stalling for time",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.K99) }
                ),
            new LevelWave(
                "We have a lot of time",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Frenhi) }
                ),
            new LevelWave(
                "__..--..__..--..__",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 5200, rubins: 30);

        Levels[37] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 37",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.PurpleGuy) }
                ),
            new LevelWave(
                "Simple Text.",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.PhantomQ) }
                )
        }, coins: 5850, rubins: 50);

        Levels[38] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Why am I writing this lol",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.PurpleGuy), new OneCopter(Config.CoptersInfo.Names.Ghost), new OneCopter(Config.CoptersInfo.Names.Gpower) }
                )
        }, coins: 7500, rubins: 20);

        Levels[39] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Okay, I'm lazy",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.PhantomQ), new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "Try to make it to the end, bye!",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.PhantomQ), new OneCopter(Config.CoptersInfo.Names.Gruver) }
                )
        }, coins: 8900, rubins: 10);

        Levels[40] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 40",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "Wave 2",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini) }
                ),
            new LevelWave(
                "Wave 3",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.K99) }
                ),
            new LevelWave(
                "Wave 4",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Esinturo) }
                ),
            new LevelWave(
                "Wave 5",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.PurpleGuy) }
                )
        }, coins: 9999, rubins: 40);

        Levels[41] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 41",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Asuno) }
                )
        }, coins: 7500, rubins: 60);

        Levels[42] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 42",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini) }
                ),
            new LevelWave(
                "Wave 2",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Wonzo) }
                )
        }, coins: 8350, rubins: 10);

        Levels[43] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 43",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Zeptocrust) }
                ),
            new LevelWave(
                "Wave 2",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Asuno) }
                ),
            new LevelWave(
                "Wave 3",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Wonzo) }
                )
        }, coins: 13500, rubins: 30);

        Levels[44] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 44",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP), new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "Hi, I hope you're ready)",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Wonzo), new OneCopter(Config.CoptersInfo.Names.Quady) }
                ),
            new LevelWave(
                "Next level = death",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Wonzo), new OneCopter(Config.CoptersInfo.Names.Asuno) }
                )
        }, coins: 20500, rubins: 40);

        Levels[45] = new Level(new LevelWave[]
        {
            new LevelWave(
                "LEVEL 45..",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP), new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "Wave 2",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini), new OneCopter(Config.CoptersInfo.Names.Mini) }
                ),
            new LevelWave(
                "Ohhh lets go",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Skrill) }
                )
        }, coins: 42900, rubins: 80);

        Levels[46] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Isn't he beautiful?",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Skrill) }
                ),
            new LevelWave(
                "I'm proud of you *-*",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 45000, rubins: 60);

        Levels[47] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 47",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Gruver) }
                ),
            new LevelWave(
                "Our relationship wasn't easy",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Asuno) }
                ),
            new LevelWave(
                "But you were able to do it",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Nexter) }
                ),
            new LevelWave(
                "I was a fool",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Skrill) }
                )
        }, coins: 58050, rubins: 50);

        Levels[48] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Now you get everything",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Skrill), new OneCopter(Config.CoptersInfo.Names.Wonzo) }
                )
        }, coins: 60000, rubins: 60);

        Levels[49] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Level 49",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP), new OneCopter(Config.CoptersInfo.Names.MXP) , new OneCopter(Config.CoptersInfo.Names.MXP) }
                ),
            new LevelWave(
                "You will become a god",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.MXP), new OneCopter(Config.CoptersInfo.Names.MXP) , new OneCopter(Config.CoptersInfo.Names.MXP) }
                )
        }, coins: 40500, rubins: 80);

        Levels[50] = new Level(new LevelWave[]
        {
            new LevelWave(
                "Final Level!",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini) }
                ),
            new LevelWave(
                "Wave 2",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Mini), new OneCopter(Config.CoptersInfo.Names.Ghost) }
                ),
            new LevelWave(
                "Wave 3",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Asuno), new OneCopter(Config.CoptersInfo.Names.Wonzo) }
                ),
            new LevelWave(
                "Wave 4",
                new OneCopter[] { new OneCopter(Config.CoptersInfo.Names.Skrill) }
                )
        }, coins: 100000, rubins: 1000);
    }

    public readonly Dictionary<int, Level> Levels = new Dictionary<int, Level>();

    public class Level
    {
        public Level(LevelWave[] levelWaves, int coins, int rubins)
        {
            LevelWaves = levelWaves;
            Coins = coins;
            Rubins = rubins;
        }

        public readonly LevelWave[] LevelWaves;
        public readonly int Coins;
        public readonly int Rubins;
    }

    public class LevelWave
    {
        public LevelWave(string name, OneCopter[] copters)
        {
            Name = name;
            Copters = copters;
        }

        public readonly string Name;
        public readonly OneCopter[] Copters;
    }

    public class OneCopter
    {
        public OneCopter(Config.CoptersInfo.Names name)
        {
            Name = name;
        }

        public readonly Config.CoptersInfo.Names Name;
    }

}
