using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUnrotate : MonoBehaviour
{
    private Transform transform = null;
    private Quaternion originalRotation;
    private void Start()
    {
        transform = GetComponent<Transform>();
        originalRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = originalRotation;
    }
}
