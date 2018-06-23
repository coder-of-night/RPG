using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// camera面向方向在水平方向的投影
/// </summary>
public class CameraZHor : MonoBehaviour
{
	
	public Transform c_transform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localEulerAngles = new Vector3(0,c_transform.localEulerAngles.y,0);
	}
	
}
