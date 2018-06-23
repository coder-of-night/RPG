using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBoard : MonoBehaviour {
	private static StatusBoard _instance = null;
	public static StatusBoard Instance()
	{
		return _instance;
	}
	public UILabel hpNum,mpNum,atkNum,defNum,spNum,pointNum;
	public GameObject[] addPointButtons;
	private TweenPosition tweenPos;
	void Awake()
	{
		_instance = this;
	}
	void Start () 
	{
		tweenPos = this.GetComponent<TweenPosition>();
		UpdateStatusShow();
	}
	/// <summary>
	/// 更新一次面板信息显示
	/// </summary>
	public void UpdateStatusShow()
	{
		hpNum.text = PlayerStatusInfo.Instance().maxHp.ToString();
		mpNum.text = PlayerStatusInfo.Instance().maxMp.ToString();
		atkNum.text = PlayerStatusInfo.Instance().attack.ToString();
		defNum.text = PlayerStatusInfo.Instance().def.ToString();
		spNum.text = PlayerStatusInfo.Instance().speed.ToString();
		pointNum.text = PlayerStatusInfo.Instance().point.ToString();
		
		if(PlayerStatusInfo.Instance().point > 0)
		{
			foreach(GameObject eachButton in addPointButtons)
			{
				eachButton.SetActive(true);
			}
		}
		else
		{
			foreach(GameObject eachButton in addPointButtons)
			{
				eachButton.SetActive(false);
			}
		}
	}
	public void PointAddButtonClick(GameObject go)
	{
		PlayerStatusManager.Instance().AddProperties(go.name);
		PlayerStatusManager.Instance().ReducePoint(1);
		UpdateStatusShow();
	}
	public void CloseButtonClick()
	{
		BoardManager.Instance().SwitchShowBoard(BoardManager.BoardShow.NONE);
		Hide();
	}
	public void Hide()
	{
		Global.playerState = Global.State.NormalState;
		tweenPos.PlayReverse();
	}
	public void Show()
	{
		Global.playerState = Global.State.TipState;
		tweenPos.PlayForward();
	}
}
