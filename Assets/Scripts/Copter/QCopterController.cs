using UnityEngine;

public sealed class QCopterController : CopterInfo, IDamageable
{
    [HideInInspector] public RotationController RotationController;

    private const string LEFT_COPTER_SIDE_NAME = "Left";
    private const string RIGHT_COPTER_SIDE_NAME = "Right";
    private const string MOTOR_NAME = "Motor";
    private const string LEG_NAME = "Leg";
    private const string HEAD_NAME = "Head";
    private const string GHOST_HEAD_NAME = "GhostHead";
    private const string MOTOR_VINT_NAME = "Vint";
    private const string MOTOR_BLADE_NAME = "Blade";

    private GameObject _leftSide;
    private GameObject _rightSide;
    private GameObject _leftMotor;
    private GameObject _rightMotor;
    private GameObject _leftLeg;
    private GameObject _rightLeg;
    private GameObject _head;

    private Destructible2D.D2dDamage _leftMotor_D2dDamage;
    private Destructible2D.D2dDamage _rightMotor_D2dDamage;
    private Destructible2D.D2dDamage _leftLeg_D2dDamage;
    private Destructible2D.D2dDamage _rightLeg_D2dDamage;
    private Destructible2D.D2dDamage _head_D2dDamage;

    private Destructible2D.D2dRequirements _leftMotor_D2dRequirements;
    private Destructible2D.D2dRequirements _rightMotor_D2dRequirements;
    private Destructible2D.D2dRequirements _leftLeg_D2dRequirements;
    private Destructible2D.D2dRequirements _rightLeg_D2dRequirements;
    private Destructible2D.D2dRequirements _head_D2dRequirements;

    private Destructible2D.D2dFracturer _leftMotor_D2dFracturer;
    private Destructible2D.D2dFracturer _rightMotor_D2dFracturer;
    private Destructible2D.D2dFracturer _leftLeg_D2dFracturer;
    private Destructible2D.D2dFracturer _rightLeg_D2dFracturer;
    private Destructible2D.D2dFracturer _head_D2dFracturer;

    private MotorController _leftMotorController;
    private MotorController _rightMotorController;

    private GhostHead _ghostHead;

    private void Awake()
    {
        _leftSide = gameObject.transform.Find(LEFT_COPTER_SIDE_NAME).gameObject;
        _rightSide = gameObject.transform.Find(RIGHT_COPTER_SIDE_NAME).gameObject;
        _leftMotor = _leftSide.transform.Find(MOTOR_NAME).gameObject;
        _rightMotor = _rightSide.transform.Find(MOTOR_NAME).gameObject;
        _leftLeg = _leftSide.transform.Find(LEG_NAME).gameObject;
        _rightLeg = _rightSide.transform.Find(LEG_NAME).gameObject;
        _head = gameObject.transform.Find(HEAD_NAME).gameObject;

        _leftMotor_D2dDamage = _leftMotor.GetComponent<Destructible2D.D2dDamage>();
        _rightMotor_D2dDamage = _rightMotor.GetComponent<Destructible2D.D2dDamage>();
        _leftLeg_D2dDamage = _leftLeg.GetComponent<Destructible2D.D2dDamage>();
        _rightLeg_D2dDamage = _rightLeg.GetComponent<Destructible2D.D2dDamage>();
        _head_D2dDamage = _head.GetComponent<Destructible2D.D2dDamage>();

        _leftMotor_D2dRequirements = _leftMotor.GetComponent<Destructible2D.D2dRequirements>();
        _rightMotor_D2dRequirements = _rightMotor.GetComponent<Destructible2D.D2dRequirements>();
        _leftLeg_D2dRequirements = _leftLeg.GetComponent<Destructible2D.D2dRequirements>();
        _rightLeg_D2dRequirements = _rightLeg.GetComponent<Destructible2D.D2dRequirements>();
        _head_D2dRequirements = _head.GetComponent<Destructible2D.D2dRequirements>();

        _leftMotor_D2dFracturer = _leftMotor.GetComponent<Destructible2D.D2dFracturer>();
        _rightMotor_D2dFracturer = _rightMotor.GetComponent<Destructible2D.D2dFracturer>();
        _leftLeg_D2dFracturer = _leftLeg.GetComponent<Destructible2D.D2dFracturer>();
        _rightLeg_D2dFracturer = _rightLeg.GetComponent<Destructible2D.D2dFracturer>();
        _head_D2dFracturer = _head.GetComponent<Destructible2D.D2dFracturer>();

        _leftMotorController = _leftMotor.GetComponent<MotorController>();
        _rightMotorController = _rightMotor.GetComponent<MotorController>();

        _ghostHead = gameObject.transform.Find(GHOST_HEAD_NAME).gameObject.GetComponent<GhostHead>();

        RotationController = _head.GetComponent<RotationController>();
    }
    
    public override void InitCopterInfo(ConfigCopters currentCopterInfo)
    {
        base.InitCopterInfo(currentCopterInfo);

        _leftMotorController.InitCopterInfo(CurrentCopterInfo);
        _rightMotorController.InitCopterInfo(CurrentCopterInfo);

        _leftMotorController.InitVintAnimator(_leftSide.transform.Find(MOTOR_VINT_NAME).gameObject.transform.Find(MOTOR_BLADE_NAME).gameObject.GetComponent<Animator>());
        _rightMotorController.InitVintAnimator(_rightSide.transform.Find(MOTOR_VINT_NAME).gameObject.transform.Find(MOTOR_BLADE_NAME).gameObject.GetComponent<Animator>());

        InitCopterHealth(CurrentCopterInfo.Health);
    }

    public void ApplyDamage(float damage)
    {
        _leftMotor_D2dDamage.Damage += damage;
        _rightMotor_D2dDamage.Damage += damage;
        _leftLeg_D2dDamage.Damage += damage;
        _rightLeg_D2dDamage.Damage += damage;
        _head_D2dDamage.Damage += damage;
    }

    public void DisableMotor(bool right)
    {
        if (right)
            _rightMotorController.DisableMotor();
        else
            _leftMotorController.DisableMotor();
    }

    public void SetMotorsMoveDirection(Vector2 direction)
    {
        _leftMotorController.SetMoveDirection(direction);
        _rightMotorController.SetMoveDirection(direction);
    }

    public bool CheckHealthWarning()
    {
        const float factor = 2f;
        float healthFactor = CurrentCopterInfo.Health / factor;

        bool healthWarningActive = false;

        CopterDamages copterDamages = GetCopterDamages();

        if (copterDamages.LeftLegDamage      >= healthFactor ||
            copterDamages.LeftMotorDamage    >= healthFactor ||
            copterDamages.RightLegDamage     >= healthFactor ||
            copterDamages.RightMotorDamage   >= healthFactor ||
            copterDamages.HeadDamage         >= healthFactor)
        {
            healthWarningActive = true;
        }

        return healthWarningActive;
    }

    public void HealthWarning(bool active)
    {
        _ghostHead.HealthWarning(active);
    }

    public void UpdateMotorsActiveState()
    {
        CopterStates copterStates;

        AppointCopterStates(out copterStates);

        if (copterStates.LeftLegDeath || copterStates.LeftMotorDeath || copterStates.HeadDeath)
            DisableMotor(right: false);

        if (copterStates.RightLegDeath || copterStates.RightMotorDeath || copterStates.HeadDeath)
            DisableMotor(right: true);
    }

    public bool CheckCopterRotationLegal()
    {
        bool rotationLegal = true;

        CopterStates copterStates;

        AppointCopterStates(out copterStates);

        if (copterStates.LeftMotorDeath || copterStates.LeftLegDeath)
            rotationLegal = false;

        if (copterStates.RightMotorDeath || copterStates.RightLegDeath)
            rotationLegal = false;

        if (copterStates.HeadDeath)
            rotationLegal = false;

        return rotationLegal;
    }

    public bool CheckDeathState()
    {
        bool death = false;

        CopterStates copterStates;

        AppointCopterStates(out copterStates);

        if (copterStates.LeftMotorDeath && copterStates.RightMotorDeath)
            death = true;

        if (copterStates.LeftLegDeath && copterStates.RightLegDeath)
            death = true;

        if (copterStates.LeftLegDeath && copterStates.RightMotorDeath)
            death = true;

        if (copterStates.RightLegDeath && copterStates.LeftMotorDeath)
            death = true;

        if (copterStates.HeadDeath)
            death = true;

        return death;
    }

    public void InitCopterDamage(CopterDamages damages)
    {
        if (_leftMotor_D2dDamage != null)
            _leftMotor_D2dDamage.Damage = damages.LeftMotorDamage;

        if (_rightMotor_D2dDamage != null)
            _rightMotor_D2dDamage.Damage = damages.RightMotorDamage;

        if (_leftLeg_D2dDamage != null)
            _leftLeg_D2dDamage.Damage = damages.LeftLegDamage;

        if (_rightLeg_D2dDamage != null)
            _rightLeg_D2dDamage.Damage = damages.RightLegDamage;

        if (_head_D2dDamage != null)
            _head_D2dDamage.Damage = damages.HeadDamage;
    }

    public void InitCopterHealth(float health)
    {
        if (_leftMotor_D2dRequirements != null)
            _leftMotor_D2dRequirements.DamageMin = health;

        if (_rightMotor_D2dRequirements != null)
            _rightMotor_D2dRequirements.DamageMin = health;

        if (_leftLeg_D2dRequirements != null)
            _leftLeg_D2dRequirements.DamageMin = health;

        if (_rightLeg_D2dRequirements != null)
            _rightLeg_D2dRequirements.DamageMin = health;

        if (_head_D2dRequirements != null)
            _head_D2dRequirements.DamageMin = health;

        if (_leftMotor_D2dFracturer != null)
            _leftMotor_D2dFracturer.DamageRequired = health;

        if (_rightMotor_D2dFracturer != null)
            _rightMotor_D2dFracturer.DamageRequired = health;

        if (_leftLeg_D2dFracturer != null)
            _leftLeg_D2dFracturer.DamageRequired = health;

        if (_rightLeg_D2dFracturer != null)
            _rightLeg_D2dFracturer.DamageRequired = health;

        if (_head_D2dFracturer != null)
            _head_D2dFracturer.DamageRequired = health;
    }

    public CopterDamages GetCopterDamages()
    {
        return new CopterDamages(
            leftMotorDamage: _leftMotor_D2dDamage.Damage,
            rightMotorDamage: _rightMotor_D2dDamage.Damage,
            leftLegDamage: _leftLeg_D2dDamage.Damage,
            rightLegDamage: _rightLeg_D2dDamage.Damage,
            headDamage: _head_D2dDamage.Damage);
    }

    private void AppointCopterStates(out CopterStates copterStates)
    {
        copterStates = new CopterStates();

        CopterDamages copterDamages = GetCopterDamages();

        if (copterDamages.LeftMotorDamage >= CurrentCopterInfo.Health)
            copterStates.LeftMotorDeath = true;

        if (copterDamages.RightMotorDamage >= CurrentCopterInfo.Health)
            copterStates.RightMotorDeath = true;

        if (copterDamages.LeftLegDamage >= CurrentCopterInfo.Health)
            copterStates.LeftLegDeath = true;

        if (copterDamages.RightLegDamage >= CurrentCopterInfo.Health)
            copterStates.RightLegDeath = true;

        if (copterDamages.HeadDamage >= CurrentCopterInfo.Health)
            copterStates.HeadDeath = true;
    }
}
