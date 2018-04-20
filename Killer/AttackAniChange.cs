using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAniChange : MonoBehaviour {

    private Animator player;

   
	// Use this for initialization
	void Start () {
        
        player = GameObject.Find("killer").GetComponent<Animator>();    //获取杀手动画控制组件
        player.SetBool("attack", false);    //默认为非攻击状态
        player.SetBool("walk", false);
        
    }
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo stateinfo = player.GetCurrentAnimatorStateInfo(0);//获取当前动作
        if (!stateinfo.IsName("Attack") && Input.GetMouseButtonDown(0))   //如果当前没有执行攻击动作，并且按下鼠标左键则可以进行攻击
           {
               player.SetBool("attack", true); //鼠标左键攻击
           }

        if (Input.GetMouseButtonUp(0))
            {
                player.SetBool("attack", false);    //只执行一次攻击动作
            }

        if (Input.GetKey(KeyCode.W)|| Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            player.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.D))   //防止用户按多个按键导致行走动画出现播放错误问题
        {
            player.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.SetBool("walk", true);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) )
        {
            player.SetBool("walk", false);
        }

    }




}
