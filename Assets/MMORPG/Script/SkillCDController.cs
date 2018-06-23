using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCDController : MonoBehaviour {

	private static SkillCDController _instance = null;
	public static SkillCDController Instance()
	{
		return _instance;
	}
	void Awake()
	{
		_instance = this;
	}
	void Start () {
		
	}
	
	void Update () {
		
	}
	
}
