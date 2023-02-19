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

    public readonly string Name; // ��� �������
    public readonly int Price; // ���� �������
    public readonly float Health; // ������ ������������� ��� ������� �� 5 �������� �������
    public readonly float Speed; // �������� ��������
    public readonly float BaseSpeed; // �������� �������� ����� ��� ���������� �����������
    public readonly float MaxSpeed; // ������������ �������� ��������
    public readonly float OrthographicSize; // ����������� ������ ������
    public readonly float MaxOrthographicSize; // ������������ ������ ������
    public readonly RaycastSettings RaycastSettings; // ��������� �������� ��� CopterSavingSystem
    public readonly SavingSystemSettings SavingSystemSettings; // ��������� ��� CopterSavingSystem
}
