using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAni : MonoBehaviour
{

    private Animator player;
    public float attackrate = 0.1f; //攻击频率
    float lasttime;

    public Transform attackPoint;   //攻击点判定
    public float attackDistance = 20f;  //攻击距离
    public int damage = 50;


    // Use this for initialization
    void Start()
    {

        player = GetComponent<Animator>();    //获取杀手动画控制组件
        player.SetBool("walk", false);  //默认为idle不是走路

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lasttime > attackrate)
        {
            if (Input.GetMouseButtonDown(0))   //如果当前没有执行攻击动作，并且按下鼠标左键则可以进行攻击
            {
                attack();
                lasttime = Time.time;
            }

        }

        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
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

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            player.SetBool("walk", false);
        }

    }

    void attack()
    {
        player.SetTrigger("isAttack");  //trigger触发攻击
        //player.Play("Attack", 0);   //直接播放攻击动画
        RaycastHit hit;
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit, attackDistance))
        {
            Debug.Log(hit.transform.name + "found");//测试是否攻击到
            if(hit.transform.tag == "Survival") //判断如果攻击的目标是生存者
            {
                PhotonView pv = hit.transform.GetComponent<PhotonView>();
                pv.RPC("GetDamage", PhotonTargets.Others, damage);
                //GameObject.FindGameObjectWithTag("Survival").GetComponent<SurvivalStatus>().humanHp -= 50;
            }
        }
        
    }



}