using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour {
	public Camera minimapCamera;
	private Transform p_transform;
	private Vector3 offset = new Vector3(0, 25, 0);
	private Vector3 c_rotation = new Vector3(90, 0, 0);
	private float nowSize = 6.0f;
	private float minSize = 3.0f;
	private float maxSize = 25.0f;
	public bool canResize = false;
	void Start()
	{
		canResize = false;
		p_transform = GameObject.FindWithTag("Player").transform;
	}
	void Update()
	{
		UpdatePosition();
		if(canResize)
		{
			nowSize -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * 50 * Mathf.Abs(nowSize);
			nowSize = Mathf.Clamp(nowSize, minSize, maxSize);
			minimapCamera.orthographicSize = nowSize;
		}
	}
	public void UpdatePosition()
	{
		minimapCamera.transform.position = p_transform.position + offset;
		minimapCamera.transform.eulerAngles = c_rotation;
	}
	public void OnMouseHover()
	{
		canResize = true;
	}
	public void OnMouseOut()
	{
		canResize = false;
	}
}
