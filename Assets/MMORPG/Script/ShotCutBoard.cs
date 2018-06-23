using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCutBoard : MonoBehaviour 
{
	private static ShotCutBoard _instance = null;
	public static ShotCutBoard Instance()
	{
		return _instance;
	}
	public List<ShotCutGrid> shotCutGrids = new List<ShotCutGrid>();
	
	public GameObject newSkill;	

	void Awake()
	{
		_instance = this;
	}
	void Start () 
	{
		
	}
	public void SetOneGridShotSkillByIdAndName(int id, GameObject surface)
	{
		ShotCutGrid findGrid = null;
		if(surface.tag == "ShotCutGrid")
		{
			findGrid = surface.GetComponent<ShotCutGrid>();
		}
		else
		{
			findGrid = surface.GetComponentInParent<ShotCutGrid>();
		}
		Debug.Log(findGrid.name);
		if(findGrid.id != 0)
		{
			findGrid.UnloadThisGridShotCut();
			Debug.Log("除");
		}
		Debug.Log("添");
		GameObject createNewSkill = NGUITools.AddChild(findGrid.gameObject, newSkill);
		createNewSkill.GetComponent<UISprite>().depth = 1;
		findGrid.SetThisGridShotCutById(id);
	}
	public void UseOneGridSkill(int index)
	{
		if(shotCutGrids[index - 1].UseSkill())
		{
			Debug.Log("施放了");
		}
		else
		{
			Debug.Log("没施放");
		}
	}
}
