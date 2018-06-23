using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGame : MonoBehaviour {
	int c = 1001,z = 2001;
	void Start ()
	{
		c = 1001;
		z = 2001;
	}
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			int x = 0;
			BagBoard.Instance().PickOneItemById(x = Random.Range(1001,1004));
			Debug.Log(x);
		}
		if(Input.GetKeyDown(KeyCode.O))
		{
			int x = 0;
			BagBoard.Instance().PickOneItemById(x = Random.Range(2001,2023));
			Debug.Log(x);
		}
		if(Input.GetKeyDown(KeyCode.L))
		{
			ShopBoard.Instance().AddOneShopItemById(c++);
			Debug.Log(c);
		}
		if(Input.GetKeyDown(KeyCode.K))
		{
			ShopBoard.Instance().AddOneShopItemById(z++);
			Debug.Log(z);
		}
		if(Input.GetKeyDown(KeyCode.M))
		{
			PlayerStatusManager.Instance().ReduceHp(50);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			CoinManager.Instance().AddCoin(50);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			CoinManager.Instance().ReduceCoin(50);
		}
		if(Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			PlayerStatusManager.Instance().AddPoint();
		}
		if(Input.GetKeyDown(KeyCode.B))
		{
			SkillBoard.Instance().AddOneSkillById(4001);
			SkillBoard.Instance().AddOneSkillById(4002);
			SkillBoard.Instance().AddOneSkillById(4003);
		}
	}
}
