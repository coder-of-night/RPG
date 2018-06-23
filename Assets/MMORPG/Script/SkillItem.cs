using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItem : MonoBehaviour {
	public enum SkillCDState
	{
		Ready,
		Cold
	}
	public SkillCDState skillCdState = SkillCDState.Ready;
	public int id = 0;
	public  SkillInfo info;
	public UISprite icon;
	public UILabel infoText;
	public SkillDragController skillDragController;
	public float maxCD;
	public float currentCD;
	void Update()
	{
		
		if(skillCdState == SkillCDState.Cold)
		{
			currentCD -= Time.deltaTime;
			if(currentCD <= 0)
			{
				currentCD = maxCD;
				skillCdState = SkillCDState.Ready;
			}
		}
	}

	public void SetThisSkillById(int id)
	{
		this.id = id;
		info = SkillsInfo.Instance().GetSkillInfoById(id);
		maxCD = info.cd;
		currentCD = maxCD;
		icon.spriteName = info.icon_name;
		skillDragController.id = id;
		string message = "";
		switch(info.skillType)
		{
			case SkillInfo.SkillType.Cure :	 	   message = GetCureMessage(); 		  break;
			case SkillInfo.SkillType.Buff : 	   message = GetBuffMessage(); 		  break; 
			case SkillInfo.SkillType.MultiTarget : message = GetMultiAttackMessage(); break;
		}
		infoText.text = message;
	}
	public string GetCureMessage()
	{
		string str = "";
		str += "名称:  " + info.name + "\n";
		str += "效果:  " + info.description + "\n";
		str += "CD:  " + info.cd + "s   " + "魔法消耗:  " + info.mpSpend + "\n";
		str += "职业:  ";
		switch(info.qualifyRole)
		{
			case PlayerStatusInfo.Playertype.Swordman : str += "剑士   ";   break;
			case PlayerStatusInfo.Playertype.Magician : str += "魔法师   "; break;
		}
		str += "解锁:  " + info.unlockRank + "级";
		return str;
	}
	public string GetBuffMessage()
	{
		string str = "";
		str += "名称:  " + info.name + "\n";
		str += "效果:  " + info.description + "   持续时间:  " + info.timeDuration + "s\n";
		str += "CD:  " + info.cd + "s   " + "魔法消耗:  " + info.mpSpend + "\n";
		str += "职业:  ";
		switch(info.qualifyRole)
		{
			case PlayerStatusInfo.Playertype.Swordman : str += "剑士   ";   break;
			case PlayerStatusInfo.Playertype.Magician : str += "魔法师   "; break;
		}
		str += "解锁:  " + info.unlockRank + "级";
		return str;
	}
	public string GetMultiAttackMessage()
	{
		string str = "";
		str += "名称:  " + info.name + "\n";
		str += "效果:  " + info.description + "   范围:  多\n";
		str += "CD:  " + info.cd + "s   " + "魔法消耗:  " + info.mpSpend + "\n";
		str += "职业:  ";
		switch(info.qualifyRole)
		{
			case PlayerStatusInfo.Playertype.Swordman : str += "剑士   ";   break;
			case PlayerStatusInfo.Playertype.Magician : str += "魔法师   "; break;
		}
		str += "解锁:  " + info.unlockRank + "级";
		return str;
	}
	public void SetSkillColdState()
	{
		skillCdState = SkillCDState.Cold;
	}
	public bool GetSkillReadyState()
	{
		return (skillCdState == SkillCDState.Ready ? true : false);
	}
}
