using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBoard : MonoBehaviour {
	private static UpgradeBoard _instance = null;
	public static UpgradeBoard Instance()
	{
		return _instance;
	}
	private TweenScale tweenScale;
	void Awake()
	{
		_instance = this;
	}
	void Start () 
	{
		tweenScale = this.GetComponent<TweenScale>();
	}
	
	void Update () 
	{
		
	}
	public void CloseButtonClick()
	{
		BoardManager.Instance().SwitchShowBoard(BoardManager.BoardShow.NONE);
		Hide();
	}
	public void Hide()
	{
		Global.playerState = Global.State.NormalState;
		tweenScale.PlayReverse();
	}
	/// <summary>
	/// 弹出升级信息面板
	/// </summary>
	public void Show()
	{
		this.gameObject.SetActive(true);
		StartCoroutine(WaitThenCloseAuto(3));
	}
	IEnumerator WaitThenCloseAuto(float t)
	{
		yield return new WaitForSeconds(t);
		Hide();
	}
}
