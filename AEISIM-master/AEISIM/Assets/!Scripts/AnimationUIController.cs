using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUIController : MonoBehaviour
{
    [System.Serializable]
    private struct LightData {
        [SerializeField]
        public RectTransform spotLightTransform;

        [SerializeField]
        public Light spotLightSource;
        
        [SerializeField]
        public GameObject spotLightGameObject;
    }

    [SerializeField]
    private LightData spotLightData;

    [SerializeField]
    [Range(1,3f)]
    private float speedOfLight;

    public void AnimateLightSourceToLevels() {
        StopAllCoroutines();
        StartCoroutine(AnimateLight(80f));
    }

    private IEnumerator AnimateLight(float valueToLerp) {
        for(float i = 0f; i < 10f; i += Time.deltaTime) {
            spotLightData.spotLightSource.spotAngle = Mathf.Lerp(spotLightData.spotLightSource.spotAngle, valueToLerp, speedOfLight * Time.deltaTime);
            yield return null;
        }
    }

    public void AnimateLightSourceToMainMenu() {
        StopAllCoroutines();
        StartCoroutine(AnimateLight(48f));
    }

    public void AnimateLightSourceToQuitMenu() {
        StopAllCoroutines();
        StartCoroutine(AnimateLight(35f));
    }
}
