using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI的TweenPosition动画初始化
/// </summary>
public class TweenPosCtrl : MonoBehaviour {


    public TweenPosition tweenPos;
    public void Init()
    {
        tweenPos = this.GetComponent<TweenPosition>();
        tweenPos.from = new Vector3(Screen.width/2 + 250,0,0);
        tweenPos.to = new Vector3(0,0,0);
    }
}
