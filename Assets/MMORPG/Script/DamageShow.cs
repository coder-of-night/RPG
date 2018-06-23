using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 伤害数值显示功能类
/// </summary>
public class DamageShow : MonoBehaviour {

	public TweenPosition tweenPos;
	public TweenScale tweenScale;
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject,0.5f);
	}
}
