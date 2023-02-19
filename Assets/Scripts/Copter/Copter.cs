using UnityEngine;

[RequireComponent(typeof(QCopterController))]
[RequireComponent(typeof(CopterConfigurator))]

public abstract class Copter : MonoBehaviour, IDamageable, IOpenCopter
{
    protected const string HEAD_NAME = "Head";

    protected bool DeathCheker;
    protected bool Death;

    protected ConfigCopters CurrentCopterInfo;

    protected QCopterController QCopterController;
    protected CopterConfigurator CopterConfigurator;
    protected GameObject HeadGameObject;
    protected Rigidbody2D HeadRigidBody;

    protected IInputHandler InputHandler;

    protected CopterSavingSystem CopterSavingSystem;

    protected virtual void Start()
    {
        QCopterController = GetComponent<QCopterController>();
        CopterConfigurator = GetComponent<CopterConfigurator>();
        HeadGameObject = gameObject.transform.Find(HEAD_NAME).gameObject;
        HeadRigidBody = HeadGameObject.GetComponent<Rigidbody2D>();

        CopterSavingSystem = new CopterSavingSystem();
    }

    public bool GetDeath() => Death;

    public GameObject GetGameObject() => gameObject;

    public GameObject GetHeadGameObject() => HeadGameObject;

    public Rigidbody2D GetHeadRgidBody() => HeadRigidBody;

    public ConfigCopters GetCurrentCopterInfo() => CurrentCopterInfo;

    public IInputHandler GetInputHandler() => InputHandler;

    public CopterDamages GetCopterDamages()
    {
        return QCopterController.GetCopterDamages();
    }

    public void SetCopterDamage(CopterDamages damages)
    {
        QCopterController.InitCopterDamage(damages);
    }

    public void SetCopterHealth(float health)
    {
        QCopterController.InitCopterHealth(health);
    }

    public void ApplyDamage(float damage)
    {
        QCopterController.ApplyDamage(damage);
    }

    protected abstract void ImDeath();

    protected virtual void InitCopterInfo(ConfigCopters copterInfo)
    {
        CurrentCopterInfo = copterInfo;

        QCopterController.InitCopterInfo(CurrentCopterInfo);
        CopterSavingSystem.InitCopterInfo(CurrentCopterInfo);
    }

    protected virtual void InitInputHandler(IInputHandler inputHandler)
    {
        InputHandler = inputHandler;
    }

    protected virtual void UpdateDeathState()
    {
        Death = QCopterController.CheckDeathState();
    }

    protected virtual void UpdateHealthWarning()
    {
        bool healthWarning = QCopterController.CheckHealthWarning();

        QCopterController.HealthWarning(healthWarning);
        CopterSavingSystem.HealthWarning(healthWarning);
    }

    protected virtual void UpdateMotorsActiveState()
    {
        QCopterController.UpdateMotorsActiveState();
    }

    protected virtual void MovementControl()
    {
        QCopterController.SetMotorsMoveDirection(InputHandler.GetAxis());

        LimitSpeed(HeadRigidBody, CurrentCopterInfo.MaxSpeed);
    }

    protected virtual void UpdateAccelerometer()
    {
        if (QCopterController.CheckCopterRotationLegal())
            QCopterController.RotationController.UpdateAccelerometer(InputHandler.GetAxis());
    }

    protected virtual void ActivateSavingSystem(LayerMask layerMask)
    {
        CopterSavingSystem.InitLayerMask(layerMask);
        CopterSavingSystem.SetActive(true);
    }

    protected virtual void UpdateSavingSystem()
    {
        if (HeadRigidBody == null)
            return;

        CopterSavingSystem.Iterate(HeadRigidBody);
    }

    private void LimitSpeed(Rigidbody2D rigidBody, float maxSpeed)
    {
        if (rigidBody.velocity.x > maxSpeed)
            rigidBody.velocity = new Vector2(maxSpeed, rigidBody.velocity.y);

        if (rigidBody.velocity.x < -maxSpeed)
            rigidBody.velocity = new Vector2(-maxSpeed, rigidBody.velocity.y);

        if (rigidBody.velocity.y > maxSpeed)
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, maxSpeed);
    }
}
