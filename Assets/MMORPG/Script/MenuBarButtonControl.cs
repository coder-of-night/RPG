using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 菜单栏按钮功能类
/// </summary>
public class MenuBarButtonControl : MonoBehaviour {
	/// <summary>
	/// 背包单击触发函数
	/// </summary>
	public void BagButtonClick()
	{
		SetTipState();
		BoardManager.Instance().SwitchShowBoard(BoardManager.BoardShow.BAGBOARD);
	}
	public void EquipButtonClick()
	{
		SetTipState();
		BoardManager.Instance().SwitchShowBoard(BoardManager.BoardShow.EQUIPBOARD);
	}
	public void SkillButtonClick()
	{
		SetTipState();
		BoardManager.Instance().SwitchShowBoard(BoardManager.BoardShow.SKILLBOARD);
	}
	public void StatusButtonClick()
	{
		SetTipState();
		BoardManager.Instance().SwitchShowBoard(BoardManager.BoardShow.STATUSBOARD);
	}
	public void SettingButtonClick()
	{
		
	}
	public void SetTipState()
	{
		Global.playerState = Global.State.TipState;
	}
}
