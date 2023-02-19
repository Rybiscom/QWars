using UnityEngine;

public sealed class SlowMotion
{
    public SlowMotion()
    {
        FIXED_DELTA_TIME = Time.fixedDeltaTime;
    }

    private const float DELTA_TIME_EXPOSURE_TRESHOLD = 0.99f;
    private const float SLOW_MOTION_ENTER_SPEED = 0.2f;
    private const float SLOW_MOTION_EXIT_SPEED = 0.15f;
    private const float SLOW_MOTION_VALUE = 0.2f;

    private readonly float FIXED_DELTA_TIME;

    private float _invertTimeSale;

    private bool _slowMotionActive = false;

    public float GetInvertTimeScale() => _invertTimeSale;

    public void Iteration(bool active)
    {
        _slowMotionActive = active;

        if (_slowMotionActive)
        {
            Time.timeScale = Mathf.SmoothStep(Time.timeScale, SLOW_MOTION_VALUE, SLOW_MOTION_ENTER_SPEED);
            Time.fixedDeltaTime = FIXED_DELTA_TIME * Time.timeScale;
        }
        else
        {
            if (Time.timeScale > DELTA_TIME_EXPOSURE_TRESHOLD)
            {
                Time.timeScale = 1f;
                Time.fixedDeltaTime = FIXED_DELTA_TIME;

                return;
            }

            float slowMotionExitSpeedOffset = SLOW_MOTION_EXIT_SPEED;

            Time.timeScale = Mathf.SmoothStep(Time.timeScale, 1f, slowMotionExitSpeedOffset);
            Time.fixedDeltaTime = FIXED_DELTA_TIME * Time.timeScale;

        }

        _invertTimeSale = 1f - Time.timeScale;
    }
}
