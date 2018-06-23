using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBoard : MonoBehaviour {
	private static ShopBoard _instance = null;
	public static ShopBoard Instance()
	{
		return _instance;
	}
	private TweenPosition tweenPos;
	public ShopItem shopItem;
	public GameObject uigrid;
	private Vector3 thispos = new Vector3(43, 48, 0);
	void Awake()
	{
		_instance = this;
		thispos = new Vector3(43, 48, 0);
	}
	void Start ()
	{
		tweenPos = this.GetComponent<TweenPosition>();
	}
	public void AddOneShopItemById(int id)
	{
		shopItem.SetThisShopItemById(id);
		GameObject thisItem = NGUITools.AddChild(uigrid,shopItem.gameObject);
		thisItem.transform.localPosition = thispos;
		thispos += new Vector3(0, -119, 0);
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
	/// <summary>
	/// 弹出商店面板
	/// </summary>
	public void Show()
	{
		Global.playerState = Global.State.TipState;
		tweenPos.PlayForward();
	}
}
