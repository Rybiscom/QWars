using UnityEngine;

public interface ICopterSystem
{
    public void Iterate(Rigidbody2D target);

    public void SetActive(bool active);
}
