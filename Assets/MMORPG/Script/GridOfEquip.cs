using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOfEquip : MonoBehaviour {
	public int id = 0;
	private ObjectInfo info = null;
	public void SetThisGridEquipById(int id, ObjectInfo info)
	{
		this.id = id;
		this.info = info;
		Item equip = this.GetComponentInChildren<Item>();
		equip.SetIconAndId(id,this.info.icon_name);
		equip.equiping = true;
		//赋予玩家装备的属性
		PlayerStatusManager.Instance().AddProperties(info);
	}
	public void UnloadThisGridEquip()
	{
		//移除装备赋予玩家的属性
		PlayerStatusManager.Instance().ReduceProperties(info);
		//物品栏添加该物品
		BagBoard.Instance().PickOneItemById(this.id);
		//此栏装备清空
		this.id = 0;
		this.info = null;
		DestroyImmediate(this.GetComponentInChildren<Item>().transform.gameObject);
	}
}
