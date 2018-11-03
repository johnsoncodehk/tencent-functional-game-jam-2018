using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerScroll : MonoBehaviour
{

    [Range(0, 1)] public float p;

    float startX;
    float startCameraX;

    void Awake()
    {
        startX = transform.localPosition.x;
        startCameraX = Camera.main.transform.localPosition.x;
    }
    void FixedUpdate() {
        float cameraX = Camera.main.transform.localPosition.x;
        float d = cameraX - startCameraX;
        d *= p;
        Vector3 pos = transform.localPosition;
        pos.x = startX + d;
        transform.localPosition = pos;
    }
}
