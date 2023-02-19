using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessLayer))]
[RequireComponent(typeof(PostProcessVolume))]

public sealed class CameraPostProcessing : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;

    private float _postProcessVolumeFactor;

    private void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();

        _postProcessVolumeFactor = GameStorage.Settings.GetPostProcessVolumeFactor();
    }

    public void SetWeight(float weight)
    {
        ValidateWeight(ref weight, _postProcessVolumeFactor);

        _postProcessVolume.weight = weight;
    }

    public void SetWeight(float weight, float postProcessVolumeFactor)
    {
        ValidateWeight(ref weight, postProcessVolumeFactor);

        _postProcessVolume.weight = weight;
    }

    private void ValidateWeight(ref float weight, float postProcessVolumeFactor)
    {
        if (weight > 1)
            weight = 1;

        if (weight < 0)
            weight = 0;

        if (postProcessVolumeFactor > 0)
            weight /= postProcessVolumeFactor;
    }
}
