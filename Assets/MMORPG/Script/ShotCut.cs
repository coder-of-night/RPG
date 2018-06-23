using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCut : MonoBehaviour {
	public int id = 0;
	public UISprite icon;
	void Start () {
		
	}

	void Update () {
		
	}
	public void SetIconAndId(int id, string name)
	{
		this.id = id;
		this.icon.spriteName = name;
	}
}
