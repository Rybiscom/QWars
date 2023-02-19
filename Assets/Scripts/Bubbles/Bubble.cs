using UnityEngine;

public abstract class Bubble : MonoBehaviour
{
    protected Rigidbody2D Target;
    protected IOpenCopter Copter;

    protected float LifeTime = 3f;

    protected virtual void Start()
    {

    }

    protected virtual void FixedUpdate()
    {
        Move();
        UpdateLifeTime();
    }

    protected virtual void OnDestroy()
    {

    }

    protected virtual void InitBubble(Rigidbody2D target, IOpenCopter copter)
    {
        Target = target;
        Copter = copter;
    }

    protected virtual void UpdateLifeTime()
    {
        if (LifeTime <= 0)
            Destroy(gameObject);
        else
            LifeTime -= Time.fixedDeltaTime;
    }

    private void Move()
    {
        if (Target != null)
            gameObject.transform.position = Target.transform.position;
    }
}
