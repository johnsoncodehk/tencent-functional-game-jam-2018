using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRound : MonoBehaviour
{
       public Transform aroundPoint;//围绕的物体
    public float angularSpeed;//角速度
    public float aroundRadius;//半径

    private float angled;
    void Start () {
      
        Vector3 p = aroundPoint.rotation * Vector3.forward * aroundRadius;
        transform.position = new Vector3(p.x, aroundPoint.position.y, p.z);
    }

    void Update () {
        angled += (angularSpeed * Time.deltaTime) % 360;//累加已经转过的角度
        float posX = aroundRadius * Mathf.Sin(angled * Mathf.Deg2Rad);//计算x位置
        float posY = aroundRadius * Mathf.Cos(angled * Mathf.Deg2Rad);//计算y位置

        transform.position = new Vector3(posX, posY, 0) + aroundPoint.position;//更新位置
    }

}
