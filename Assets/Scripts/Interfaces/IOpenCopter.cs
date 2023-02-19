using UnityEngine;

public interface IOpenCopter
{
    public bool GetDeath();

    public GameObject GetGameObject();

    public GameObject GetHeadGameObject();

    public Rigidbody2D GetHeadRgidBody();

    public ConfigCopters GetCurrentCopterInfo();

    public IInputHandler GetInputHandler();

    public CopterDamages GetCopterDamages();

    public void SetCopterDamage(CopterDamages damages);

    public void SetCopterHealth(float health);
}
