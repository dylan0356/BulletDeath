using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private Transform stransform;

    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.3f;

    private float dampingSpeed = 1.0f;

    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        stransform = GetComponent(typeof(Transform)) as Transform;
        initialPosition = stransform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            stransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            stransform.localPosition = initialPosition;
        }
    }

    public void TriggerShake()
    {
        shakeDuration = 0.3f;
    }
}
