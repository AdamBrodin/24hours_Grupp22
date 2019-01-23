using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
    public int shakes = 3;

    public void DoCameraShake(float shakeMagnitude)
    {
        StartCoroutine(PlayCameraShake(shakeMagnitude));
    }

    private IEnumerator PlayCameraShake(float shakeMagnitude)
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
