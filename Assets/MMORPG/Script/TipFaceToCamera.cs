using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 使得物体始终与某物体旋转一致的脚本
/// </summary>
public class TipFaceToCamera : MonoBehaviour {
	private Transform c_transform;
	private float angles;
	// Use this for initialization
	void Start () {
		c_transform = GameObject.FindWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		angles = Quaternion.Angle(transform.rotation,c_transform.rotation);
		transform.rotation = c_transform.rotation;
	}
}
