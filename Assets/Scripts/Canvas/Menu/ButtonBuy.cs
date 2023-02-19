using UnityEngine;

public sealed class ButtonBuy : MonoBehaviour
{
    [SerializeField] private GameObject _successParticles;

    private const string ERROR_PARAMETER = "Error";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if (_successParticles == null)
            throw new System.Exception("Добавь партиклс в кнопку покупки коптеров");
    }

    public void TriggerErrorAnimate()
    {
        _animator.SetTrigger(ERROR_PARAMETER);
    }

    public void SpawnSuccessParticles()
    {
        Instantiate(_successParticles);
    }
}
