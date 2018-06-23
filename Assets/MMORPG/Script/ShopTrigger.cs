using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// npc武器商店面板触发功能类
/// </summary>
public class ShopTrigger : MonoBehaviour {
void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			if(Input.GetKeyDown(KeyCode.Q))
			{
				BoardManager.Instance().SwitchShowBoard(BoardManager.BoardShow.SHOPBOARD);
			}
		}
	}
}
