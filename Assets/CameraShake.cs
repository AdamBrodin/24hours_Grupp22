using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void DoCameraShake(float shakeMagnitude, int shakes)
    {
        StartCoroutine(PlayCameraShake(shakeMagnitude, shakes));
    }

    private IEnumerator PlayCameraShake(float shakeMagnitude, int shakes)
    {
        for (int i = 0; i < shakes; i++)
        {
            yield return null;
            transform.position = new Vector3(Random.Range(-shakeMagnitude, shakeMagnitude), Random.Range(-shakeMagnitude, shakeMagnitude)) + transform.parent.position;
            yield return null;
            transform.position = Vector3.zero + transform.parent.position;
        }
    }
}
