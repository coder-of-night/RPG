using UnityEngine;
using System.Collections;
/// <summary>
/// 摄像机功能类
/// </summary>
public class ARPGcameraC : MonoBehaviour {
	
	public Transform target;
	public Transform targetBody;
	public float targetHeight = 1.2f;
	public float distance = 4.0f;
	public float maxDistance = 6;
	public float minDistance = 1.0f;
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	public float yMinLimit = -40;
	public float yMaxLimit = 70;
	public float zoomRate = 70;
	public float rotationDampening = 3.0f;
	private float x = 20.0f;
	private float y = 0.0f;
	public Quaternion aim;
	public float aimAngle = 8;
	public bool  lockOn = false;
	RaycastHit hit;
	//public GameObject aimStick; //For Mobile
	public bool mobileMode = false;
	private Vector2 touchDeltaPosition;
	
	void Start(){
		if(!target){
			target = GameObject.FindWithTag("Player").transform;
		}
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		if(GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
		//Screen.lockCursor = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	void LateUpdate(){
		if(Input.GetKeyDown(KeyCode.LeftAlt))
		{
			Global.playerState = Global.State.TipState;
		}
		if(Input.GetKeyUp(KeyCode.LeftAlt))
		{
			Global.playerState = Global.State.NormalState;
		}
		if(!Global.CanControl){
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		else{
			ResetCursor();
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		if(!target)
			return;
		if(!targetBody){
      		targetBody = target;
      	}
		
		if(Time.timeScale == 0.0f){
			return;
		}
		if(Global.CanControl)
		{
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
		}
		
		
		distance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
		distance = Mathf.Clamp(distance, minDistance, maxDistance);
		
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		
		// Rotate Camera
		Quaternion rotation = Quaternion.Euler(y, x, 0);
		if(Global.CanControl){
			transform.rotation = rotation;
			aim = Quaternion.Euler(y- aimAngle, x, 0);
		}
	
		//Camera Position

		Vector3 positiona = target.position - (rotation * Vector3.forward * distance + new Vector3(0.0f,-targetHeight,0.0f));
		if(Global.CanControl){
			transform.position = positiona;
		}

		Vector3 trueTargetPosition = target.transform.position - new Vector3(0.0f,-targetHeight,0.0f);

		if (Physics.Linecast (trueTargetPosition, transform.position, out hit)) {
			if(hit.transform.tag == "Wall"){
				float tempDistance = Vector3.Distance (trueTargetPosition, hit.point) - 0.28f;
				
				positiona = target.position - (rotation * Vector3.forward * tempDistance + new Vector3(0,-targetHeight,0));
				transform.position = positiona;
			}
			
		}
	}
	
	static float ClampAngle(float angle , float min , float max){
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
		
	}
	public void ResetCursor()
	{
		
	}
}