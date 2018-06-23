using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShoot : MonoBehaviour 
{
	private static SkillShoot _instance = null;
	public static SkillShoot Instance()
	{
		return _instance;
	}
	public GameObject player;
	public GameObject cureHpFx;
	public GameObject buffAtkFx;
	public GameObject multiAtk1Fx;

	public SkillController[] skillControllers;
	void Awake()
	{
		_instance = this;
	}
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			ShotCutBoard.Instance().UseOneGridSkill(1);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			ShotCutBoard.Instance().UseOneGridSkill(2);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			ShotCutBoard.Instance().UseOneGridSkill(3);
		}
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			ShotCutBoard.Instance().UseOneGridSkill(4);
		}
		if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			ShotCutBoard.Instance().UseOneGridSkill(5);
		}
	}
	public void ShootSkill(int id, SkillInfo info)
	{
		switch(info.skillType)
		{
			case SkillInfo.SkillType.Cure : 	   CureDo(info);    break;
			case SkillInfo.SkillType.Buff :        BuffDo(info);    break;
			case SkillInfo.SkillType.MultiTarget : MultiAttackDo(info); break;
		}
	}
	private void CureDo(SkillInfo info)
	{
		GameObject fx =  Instantiate(cureHpFx);
		fx.transform.parent = player.transform;
		fx.transform.localPosition = new Vector3(0,0.05f,0);
		fx.GetComponent<ParticleSystem>().Play(true);
		Destroy(fx,2.5f);
		switch(info.skillEffectType)
		{
			case SkillInfo.SkillEffectType.HP : PlayerStatusManager.Instance().AddHp(info.amount); break;
			case SkillInfo.SkillEffectType.MP : PlayerStatusManager.Instance().AddMp(info.amount); break;
		}
	}
	private void BuffDo(SkillInfo info)
	{
		StartCoroutine(BuffDoEnumerator(info));
	}
	IEnumerator BuffDoEnumerator(SkillInfo info)
	{
		Debug.Log("buff加持中");
		GameObject fx =  Instantiate(buffAtkFx);
		fx.transform.parent = player.transform;
		fx.transform.localPosition = new Vector3(0,0.05f,0);
		fx.GetComponent<ParticleSystem>().Play(true);
		PlayerStatusManager.Instance().AddProperties(info.skillEffectType, info.amount);
		yield return new WaitForSeconds(info.timeDuration);
		Debug.Log("buff加持结束");
		Destroy(fx);
		PlayerStatusManager.Instance().ReduceProperties(info.skillEffectType, info.amount);
	}
	private void MultiAttackDo(SkillInfo info)
	{
		skillControllers[0].damageNum = info.amount;
		Vector3 initPos = player.transform.TransformPoint(player.GetComponentInChildren<FollowPos>().transform.localPosition + Vector3.forward * 3.3f);
		GameObject fx = Instantiate(multiAtk1Fx,initPos,player.transform.rotation);
		
		Destroy(fx,1);
	}
}
