using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVisualLerp : MonoBehaviour
{
    [SerializeField]
    private Light lightSource;

    public float duration = 3f;

    private void Update() {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 10f + 0.5F;
        lightSource.intensity = Mathf.Clamp(amplitude, 5f, 8f);
    }
}
