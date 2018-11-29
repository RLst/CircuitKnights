using System.Collections;
using UnityEngine;

namespace CircuitKnights
{
    public class PlayerCameraShake : MonoBehaviour
    {
        public IEnumerator Shake(float duration, float magnitude)
        {
            Vector3 originalPos = transform.localPosition;

			float finishTime = Time.time + duration;
            // float elapsed = 0.0f;

			while (finishTime > Time.time)
            // while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);

                // elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPos;
        }
    }
}