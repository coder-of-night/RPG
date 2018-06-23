using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBoard : MonoBehaviour {
	private static SkillBoard _instance = null;
	public static SkillBoard Instance()
	{
		return _instance;
	}
	private TweenPosition tweenPos;
	public SkillItem skillItem;
	public GameObject uigrid;
	private Vector3 thispos = new Vector3(43, 48, 0);
	void Awake()
	{
		_instance = this;
	}
	void Start()
	{
		tweenPos = this.GetComponent<TweenPosition>();
	}
	public void ListenToUnlockSkill()
	{
		switch(PlayerStatusInfo.Instance().rank)
		{
			case 2 : AddOneSkillById(4001); AddOneSkillById(4002); AddOneSkillById(4003); break;
		}
	}
	public void AddOneSkillById(int id)
	{
		skillItem.SetThisSkillById(id);
		GameObject thisItem = NGUITools.AddChild(uigrid,skillItem.gameObject);
		thisItem.transform.localPosition = thispos;
		thispos += new Vector3(0, -119, 0);
	}
	/// <summary>
	/// 从技能列表中寻找施放的对应技能
	/// </summary>
	/// <param name="id"></param>
	public SkillItem FindSkillById(int id)
	{
		SkillItem[] tempSkillItems = this.GetComponentsInChildren<SkillItem>();
		foreach(SkillItem tempSkill in tempSkillItems)
		{
			if(tempSkill.id == id)
			{
				return tempSkill;
			}
		}

		Debug.Log("没找到对应技能");
		return null;
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
