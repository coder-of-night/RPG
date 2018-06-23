using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {
	public int damageNum = 0;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
			other.gameObject.SendMessage("BeDamage",damageNum,SendMessageOptions.DontRequireReceiver);
		}
	}
}
