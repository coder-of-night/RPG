using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLook : MonoBehaviour {

	public GameObject player;
	public GameObject head;
	private Quaternion initrotation;
	void Start()
	{
		initrotation = head.transform.rotation;
	}
	void OnTriggerStay(Collider other)
	{
		head.transform.LookAt(player.transform);
	}
	void OnTriggerExit(Collider other)
	{
		head.transform.rotation = initrotation;
	}
}