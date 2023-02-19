using System;
using System.Collections.Generic;

public static class Config
{
    public static readonly bool DebbugMode = false;
    public static readonly int DelayMsForLoadingWindow = 500;
    public static readonly int DelayMsForDestroyBotDeadCopter = 5000;

    public static readonly ConfigLevels LevelsInfo = new ConfigLevels();
    public static readonly ConfigBubbles Bubbles = new ConfigBubbles(bubbleGodPrice: 20, bubbleDamagePrice: 20);

    public static class Scenes
    {
        static Scenes()
        {
            Game = new ConfigScenes("Game");
            Menu = new ConfigScenes("Menu");
        }

        public static readonly ConfigScenes Game;
        public static readonly ConfigScenes Menu;
    }

    public static class CoptersInfo
    {
        static CoptersInfo()
        {
            new ConfigCopters(
                name: GetStringName(Names.MXP),
                price: 0,
                health: 20,
                speed: 2.7f,
                baseSpeed: 1.5f,
                maxSpeed: 18,
                orthographicSize: 6,
                maxOrthographicSize: 8,
                raycastSettings: new RaycastSettings(6, 100, 36),
                savingSystemSettings: new SavingSystemSettings(150f, 0.023f, 0.05f, 1.5f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Quady),
                price: 100,
                health: 35,
                speed: 3f,
                baseSpeed: 1.5f,
                maxSpeed: 20,
                orthographicSize: 6,
                maxOrthographicSize: 9,
                raycastSettings: new RaycastSettings(6.1f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(100f, 0.032f, 0.052f, 1.5f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Esinturo),
                price: 260,
                health: 40,
                speed: 3.2f,
                baseSpeed: 1.5f,
                maxSpeed: 22,
                orthographicSize: 6,
                maxOrthographicSize: 10,
                raycastSettings: new RaycastSettings(6.2f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.03f, 0.055f, 1.3f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Nexter),
                price: 565,
                health: 45,
                speed: 3.2f,
                baseSpeed: 1.5f,
                maxSpeed: 23,
                orthographicSize: 7,
                maxOrthographicSize: 11,
                raycastSettings: new RaycastSettings(6.2f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(110f, 0.04f, 0.06f, 1.5f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Frenhi),
                price: 1050,
                health: 62,
                speed: 3.8f,
                baseSpeed: 1.5f,
                maxSpeed: 22,
                orthographicSize: 7,
                maxOrthographicSize: 10,
                raycastSettings: new RaycastSettings(6.3f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(110f, 0.042f, 0.065f, 1.4f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.DDY930),
                price: 2230,
                health: 75,
                speed: 3.3f,
                baseSpeed: 1.6f,
                maxSpeed: 26,
                orthographicSize: 8,
                maxOrthographicSize: 11,
                raycastSettings: new RaycastSettings(6.7f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.055f, 0.08f, 1.3f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Wruver),
                price: 7360,
                health: 80,
                speed: 4.2f,
                baseSpeed: 1.6f,
                maxSpeed: 30,
                orthographicSize: 8,
                maxOrthographicSize: 10,
                raycastSettings: new RaycastSettings(6.3f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.045f, 0.085f, 1.5f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.PhantomQ),
                price: 13330,
                health: 88,
                speed: 5f,
                baseSpeed: 1.6f,
                maxSpeed: 26,
                orthographicSize: 9,
                maxOrthographicSize: 12,
                raycastSettings: new RaycastSettings(6.6f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.048f, 0.076f, 1.6f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Asuno),
                price: 31215,
                health: 100,
                speed: 4.6f,
                baseSpeed: 1.7f,
                maxSpeed: 27,
                orthographicSize: 11,
                maxOrthographicSize: 14,
                raycastSettings: new RaycastSettings(6.6f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.055f, 0.095f, 1.25f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.PronX),
                price: 9999,
                health: 1,
                speed: 1,
                baseSpeed: 1f,
                maxSpeed: 2,
                orthographicSize: 3,
                maxOrthographicSize: 3,
                raycastSettings: new RaycastSettings(6, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.025f, 0.05f, 1.5f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Mini),
                price: 100,
                health: 25,
                speed: 3.2f,
                baseSpeed: 1.5f,
                maxSpeed: 18,
                orthographicSize: 7,
                maxOrthographicSize: 10,
                raycastSettings: new RaycastSettings(6, 100, 36),
                savingSystemSettings: new SavingSystemSettings(100f, 0.025f, 0.05f, 1.5f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.K99),
                price: 100,
                health: 33,
                speed: 2.8f,
                baseSpeed: 1.5f,
                maxSpeed: 20,
                orthographicSize: 7,
                maxOrthographicSize: 10,
                raycastSettings: new RaycastSettings(6.1f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(100f, 0.03f, 0.05f, 1.5f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.UralX4),
                price: 100,
                health: 45,
                speed: 3.1f,
                baseSpeed: 1.5f,
                maxSpeed: 22,
                orthographicSize: 7,
                maxOrthographicSize: 10,
                raycastSettings: new RaycastSettings(6.2f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(100f, 0.03f, 0.055f, 1.3f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Gruver),
                price: 100,
                health: 50,
                speed: 3.3f,
                baseSpeed: 1.5f,
                maxSpeed: 24,
                orthographicSize: 7,
                maxOrthographicSize: 10,
                raycastSettings: new RaycastSettings(6.3f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(110f, 0.04f, 0.06f, 1.5f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Zeptocrust),
                price: 100,
                health: 65,
                speed: 3.7f,
                baseSpeed: 1.5f,
                maxSpeed: 24,
                orthographicSize: 7,
                maxOrthographicSize: 10,
                raycastSettings: new RaycastSettings(6.4f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.05f, 0.07f, 1.4f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Gpower),
                price: 100,
                health: 70,
                speed: 3.6f,
                baseSpeed: 1.5f,
                maxSpeed: 26,
                orthographicSize: 8,
                maxOrthographicSize: 10,
                raycastSettings: new RaycastSettings(6.5f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.06f, 0.08f, 1.6f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Ghost),
                price: 100,
                health: 60,
                speed: 4.4f,
                baseSpeed: 1.6f,
                maxSpeed: 32,
                orthographicSize: 8,
                maxOrthographicSize: 11,
                raycastSettings: new RaycastSettings(6.7f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.072f, 0.09f, 1.3f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.PurpleGuy),
                price: 100,
                health: 80,
                speed: 4.6f,
                baseSpeed: 1.6f,
                maxSpeed: 25,
                orthographicSize: 9,
                maxOrthographicSize: 12,
                raycastSettings: new RaycastSettings(6.7f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.05f, 0.08f, 1.4f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Wonzo),
                price: 100,
                health: 90,
                speed: 5,
                baseSpeed: 1.8f,
                maxSpeed: 28,
                orthographicSize: 10,
                maxOrthographicSize: 12,
                raycastSettings: new RaycastSettings(6.8f, 100, 36),
                savingSystemSettings: new SavingSystemSettings(120f, 0.075f, 0.10f, 1.3f),
                copters: Copters);

            new ConfigCopters(
                name: GetStringName(Names.Skrill),
                price: 72600,
                health: 120,
                speed: 8,
                baseSpeed: 2.2f,
                maxSpeed: 30,
                orthographicSize: 10,
                maxOrthographicSize: 14,
                raycastSettings: new RaycastSettings(7, 100, 36),
                savingSystemSettings: new SavingSystemSettings(150f, 0.085f, 0.14f, 1.6f),
                copters: Copters);
        }

        public static readonly Dictionary<string, ConfigCopters> Copters = new Dictionary<string, ConfigCopters>();

        public enum Names
        {
            MXP,
            Quady,
            Esinturo,
            Nexter,
            Frenhi,
            DDY930,
            Wruver,
            PhantomQ,
            Asuno,
            PronX,
            Mini,
            K99,
            UralX4,
            Gruver,
            Zeptocrust,
            Gpower,
            Ghost,
            PurpleGuy,
            Wonzo,
            Skrill
        }

        public static string GetStringName(Names name)
        {
            switch (name)
            {
                case Names.MXP:
                    return "MXP";
                case Names.Quady:
                    return "Quady";
                case Names.Esinturo:
                    return "Esinturo";
                case Names.Nexter:
                    return "Nexter";
                case Names.Frenhi:
                    return "Frenhi";
                case Names.DDY930:
                    return "DDY930";
                case Names.Wruver:
                    return "Wruver";
                case Names.PhantomQ:
                    return "PhantomQ";
                case Names.Asuno:
                    return "Asuno";
                case Names.PronX:
                    return "PronX";
                case Names.Mini:
                    return "Mini";
                case Names.K99:
                    return "K99";
                case Names.UralX4:
                    return "UralX4";
                case Names.Gruver:
                    return "Gruver";
                case Names.Zeptocrust:
                    return "Zeptocrust";
                case Names.Gpower:
                    return "Gpower";
                case Names.Ghost:
                    return "Ghost";
                case Names.PurpleGuy:
                    return "PurpleGuy";
                case Names.Wonzo:
                    return "Wonzo";
                case Names.Skrill:
                    return "Skrill";
                default:
                    throw new Exception($"(GetStringName) Коптер {name} не найден, добавь его в switch");
            }
        }

        public static Names GetEnumName(string name)
        {
            foreach (Names currentName in Enum.GetValues(typeof(Names)))
            {
                if (GetStringName(currentName) == name)
                    return currentName;
            }

            throw new Exception("(GetEnumName) Коптер с таким именем не найден");
        }
    }
}
