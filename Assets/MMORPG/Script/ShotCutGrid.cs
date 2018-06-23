using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCutGrid : MonoBehaviour {
	public int id = 0;
	public SkillInfo info;
	void Start () {
		
	}
	
	void Update () {
		
	}
	public void SetThisGridShotCutById(int id)
	{
		this.id = id;
		this.info = SkillsInfo.Instance().GetSkillInfoById(id);
		ShotCut shotCut = this.GetComponentInChildren<ShotCut>();
		shotCut.SetIconAndId(id, info.icon_name);
		shotCut.transform.localPosition = Vector3.zero;
	}
	public void UnloadThisGridShotCut()
	{
		this.id = 0;
		this.info = null;
		DestroyImmediate(this.GetComponentInChildren<ShotCut>().transform.gameObject);
	}
	public bool UseSkill()
	{
		if(this.id == 0)
		{
			Debug.Log("没有快捷技能");
			return false;
		}
		else if(!SkillBoard.Instance().FindSkillById(id).GetSkillReadyState())
		{
			Debug.Log("CD未冷却");
			return false;
		}
		else if(!PlayerStatusManager.Instance().ReduceMp(this.info.mpSpend))
		{
			Debug.Log("蓝不够");
			return false;
		}
		else
		{
			SkillBoard.Instance().FindSkillById(id).SetSkillColdState();
			SkillShoot.Instance().ShootSkill(this.id,this.info);
			return true;
		}
	}
	
}
