using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
	private static BoardManager _instance = null;
	public static BoardManager Instance()
	{
		return _instance;
	}
	public QuestBoardButtonControl questBoardFox;
	public ShopBoard shopBoard;
	public BagBoard	bagBoard;
	public EquipBoard equipBoard;
	public StatusBoard statusBoard;	
	public UpgradeBoard upgradeBoard;
	public SkillBoard skillBoard;

	void Awake()
	{
		_instance = this;
	}
	public enum BoardShow
	{
		NONE,
		QUESTBOARD_FOX,
		SHOPBOARD,
		BAGBOARD,
		EQUIPBOARD,
		STATUSBOARD,
		SKILLBOARD,
		UPGRADEBOARD
	}
	/// <summary>
	/// 前一个显示的面板
	/// </summary>
	public BoardShow beforeShowBoard = BoardShow.NONE;
	void Start()
	{
		beforeShowBoard = BoardShow.NONE;
	}
	public void SwitchShowBoard(BoardShow nowShowBoard)
	{
		switch(beforeShowBoard)
		{
			case BoardShow.NONE :				      break;
			case BoardShow.QUESTBOARD_FOX :	questBoardFox.Hide(); break;
			case BoardShow.SHOPBOARD :	shopBoard.Hide();     break;
			case BoardShow.BAGBOARD :  	bagBoard.Hide();      break;
			case BoardShow.EQUIPBOARD :   	equipBoard.Hide();    break;
			case BoardShow.STATUSBOARD :   	statusBoard.Hide();   break;
			case BoardShow.UPGRADEBOARD :   upgradeBoard.Hide();  break;
			case BoardShow.SKILLBOARD :     skillBoard.Hide();    break;
		}
		switch(nowShowBoard)
		{
			case BoardShow.NONE :				      beforeShowBoard = BoardShow.NONE; break;
			case BoardShow.QUESTBOARD_FOX :	questBoardFox.Show(); beforeShowBoard = nowShowBoard;   break;
			case BoardShow.SHOPBOARD :	shopBoard.Show();     beforeShowBoard = nowShowBoard;	break;
			case BoardShow.BAGBOARD :  	bagBoard.Show();      beforeShowBoard = nowShowBoard; 	break;
			case BoardShow.EQUIPBOARD :   	equipBoard.Show();    beforeShowBoard = nowShowBoard; 	break;
			case BoardShow.STATUSBOARD :   	statusBoard.Show();   beforeShowBoard = nowShowBoard; 	break;
			case BoardShow.UPGRADEBOARD :   upgradeBoard.Show();  beforeShowBoard = nowShowBoard;   break;
			case BoardShow.SKILLBOARD :     skillBoard.Show();    beforeShowBoard = nowShowBoard;   break;
		}
	}
}
