using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDragController : UIDragDropItem {
	public GameObject skillDragging;
	public int id = 0;
	private Vector3 regionPos = new Vector3(-142, 0, 0);
	void Start()
	{
		skillDragging = GameObject.Find("SkillDragging");
	}
	protected override void OnDragDropStart()
	{
		base.OnDragDropStart();
		this.transform.parent = skillDragging.transform;
		this.GetComponent<UISprite>().depth = 2;
	}
	protected override void OnDragDropRelease(GameObject surface)
	{
		base.OnDragDropRelease(surface);
		if(surface.tag == "ShotCutGrid" || surface.tag == "ShotCut")
		{
			ShotCutBoard.Instance().SetOneGridShotSkillByIdAndName(id, surface);
		}
		else
		{
			ResetPos();
		}
	}
	private void ResetPos()
	{
		this.transform.localPosition = regionPos;
	}
}
