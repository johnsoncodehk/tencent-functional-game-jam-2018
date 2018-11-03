using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixLayerPosY : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector3 localPos = transform.localPosition;
        localPos.y = -transform.parent.localPosition.y;
        transform.localPosition = localPos;
    }
}
