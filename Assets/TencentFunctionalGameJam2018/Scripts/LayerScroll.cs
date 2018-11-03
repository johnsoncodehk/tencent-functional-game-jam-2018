using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerScroll : MonoBehaviour
{

    [Range(-1, 1)] public float p;
    float startCameraX;

    float startX;

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
