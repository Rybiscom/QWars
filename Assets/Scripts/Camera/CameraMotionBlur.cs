using UnityEngine;

public sealed class CameraMotionBlur : MonoBehaviour
{
    [SerializeField] private Material _material;

    private RenderTexture _prevFrame;

    private float _pauseCounter = 0;
    private bool _motionBlurActive = true;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (_motionBlurActive)
        {
            // Создаем временный буфер

            if (_prevFrame == null)
                _prevFrame = new RenderTexture(source.width, source.height, 0);

            // Передаем параметры в шейдер

            _material.SetTexture("_PrevFrame", _prevFrame);

            // Отдаем в материал текстуру с камеры, получаем результирующую текстуру

            Graphics.Blit(source, destination, _material);

            // Запоминаем предыдущий фрейм

            Graphics.Blit(RenderTexture.active, _prevFrame);

            if (_pauseCounter < 5)
            {
                Graphics.Blit(source, destination);
                _pauseCounter++;
            }
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    public void SlowMotion(bool activate)
    {
        _motionBlurActive = activate;

        if (!_motionBlurActive)
        {
            _pauseCounter = 0;
            //_prevFrame = null;
        }
    }
}
