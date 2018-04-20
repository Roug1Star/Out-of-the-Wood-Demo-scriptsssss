using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalStatus : MonoBehaviour {

    public int humanHp = 150;   //逃生者有150血，分别代表四种状态：150健康状态、100负伤状态、50趴地状态、0死亡，屠夫伤害数值每次50
    public int maxHp = 150;
    public int minHp = 0;
    public float hurtCoolDown;  //被攻击后获得加速状态的冷却时间
    public float hurtCurrentCoolDown;   //记录当前的冷却时间

	// Use this for initialization
	void Start () {

        hurtCurrentCoolDown = hurtCoolDown; //开局即可以被触发

	}
	
	// Update is called once per frame
	void Update () {

        if (humanHp > 150)
        {
            humanHp = maxHp;
        }
        if (humanHp < 0)
        {
            humanHp = minHp;
        }
        if (hurtCurrentCoolDown > hurtCoolDown)
        {
            hurtCurrentCoolDown = hurtCoolDown;     //deltatime不是完全的整数，所以要添加一个函数来强制变回设置的冷却时间
        }

        if (hurtCurrentCoolDown < hurtCoolDown)
        {
            hurtCurrentCoolDown += Time.deltaTime;  //当前冷却时间增加
        }

        if(hurtCurrentCoolDown == hurtCoolDown) //如果当前冷却时间等于冷却时间，加速状态结束
        {
            gameObject.GetComponent<SurvivalCtl>().MoveSpeed = 3;
            gameObject.GetComponent<SurvivalCtl>().RunSpeed = 4;
        }
	}

    [PunRPC]    //因为是远程调用，photon中进行，不然造成伤害无法同步，只会在本地进行
    public void GetDamage(int _damage)
    {
        humanHp -= _damage;    
        if(hurtCurrentCoolDown >= hurtCoolDown  && humanHp > 50) //如果当前冷却时间等于冷却时间，可以触发受伤加速状态
        {
            hurtCurrentCoolDown = 0;    //当前冷却时间设置为0
            gameObject.GetComponent<SurvivalCtl>().MoveSpeed += 5;
            gameObject.GetComponent<SurvivalCtl>().RunSpeed += 4;   
        }
    }
}
