using System.Collections.Generic;

public sealed class ConfigCopters
{
    public ConfigCopters(string name, int price, float health, float speed, float baseSpeed, float maxSpeed, float orthographicSize, float maxOrthographicSize, RaycastSettings raycastSettings, SavingSystemSettings savingSystemSettings, Dictionary<string, ConfigCopters> copters)
    {
        Name = name;
        Price = price;
        Health = health;
        Speed = speed;
        BaseSpeed = baseSpeed;
        MaxSpeed = maxSpeed;
        OrthographicSize = orthographicSize;
        MaxOrthographicSize = maxOrthographicSize;
        RaycastSettings = raycastSettings;
        SavingSystemSettings = savingSystemSettings;

        copters.Add(Name, this);
    }

    public readonly string Name; // Имя коптера
    public readonly int Price; // Цена покупки
    public readonly float Health; // Жизней индивидуально для каждого из 5 обьектов коптера
    public readonly float Speed; // Скорость движения
    public readonly float BaseSpeed; // Скорость движения вверх при отпущенном контроллере
    public readonly float MaxSpeed; // Максимальная скорость движения
    public readonly float OrthographicSize; // Стандартный размер камеры
    public readonly float MaxOrthographicSize; // Максимальный размер камеры
    public readonly RaycastSettings RaycastSettings; // Настройки рейкаста для CopterSavingSystem
    public readonly SavingSystemSettings SavingSystemSettings; // Настройки для CopterSavingSystem
}
