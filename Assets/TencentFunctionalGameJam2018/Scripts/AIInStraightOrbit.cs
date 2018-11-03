using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInStraightOrbit : MonoBehaviour {
	public Vector3 StartPoint;
	public Vector3 EndPoint;
	public bool IsLoop;
	public float Speed;
	Vector3 _direction{
		get{
			return (EndPoint - StartPoint).normalized;
		}
	}
	int _directionSign = 1;
	float _minDistance = 0.1f;
	// Use this for initialization
	void Start () {
		transform.position = StartPoint;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(StartPoint,EndPoint) <= _minDistance )
			return;
		if(!IsLoop )
		{
			if((Vector3.Distance(transform.position,EndPoint)<= _minDistance))
			{
				_directionSign = 0;
			}
		}else
		if((Vector3.Distance(transform.position,EndPoint) <= _minDistance) && _directionSign>0)
		{
			_directionSign = -1;
		}else
		if((Vector3.Distance(transform.position,StartPoint) <= _minDistance) && _directionSign<0)
		{
			_directionSign = 1;
		}
		transform.Translate(_direction*Speed*_directionSign);
	}
}
