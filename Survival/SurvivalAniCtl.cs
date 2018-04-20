using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalAniCtl : MonoBehaviour {

    private Animator player;
    

    // Use this for initialization
    void Start () {

        player = GetComponent<Animator>();
        player.SetBool("walk", false);
        player.SetBool("run", false);
        player.SetBool("isinjure", false);
        player.SetBool("isfallen", false);
        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.GetComponent<SurvivalStatus>().humanHp -= 3;
        }
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.GetComponent<SurvivalStatus>().humanHp += 3;
        }

        if (gameObject.GetComponent<SurvivalStatus>().humanHp != 0)
        {
            
            if (gameObject.GetComponent<SurvivalStatus>().humanHp == 150)
            {
                player.SetBool("isinjure", false);
                player.SetBool("isfallen", false);
            }

            if (gameObject.GetComponent<SurvivalStatus>().humanHp > 50 && gameObject.GetComponent<SurvivalStatus>().humanHp < 150)
            {
                player.SetBool("walk", false);
                player.SetBool("run", false);
                player.SetBool("isfallen", false);
                player.SetBool("isinjure", true);
            }

            if (gameObject.GetComponent<SurvivalStatus>().humanHp > 0 && gameObject.GetComponent<SurvivalStatus>().humanHp <= 50)
            {
                player.SetBool("injurewalk", false);
                player.SetBool("injurerun", false);
                player.SetBool("isinjure", false);
                player.SetBool("isfallen", true);
            }


            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                if (gameObject.GetComponent<SurvivalStatus>().humanHp == 150)
                {
                    walk();
                }
                else if (gameObject.GetComponent<SurvivalStatus>().humanHp > 50 && gameObject.GetComponent<SurvivalStatus>().humanHp < 150)
                {
                    injureWalk();
                }
                else if (gameObject.GetComponent<SurvivalStatus>().humanHp > 0 && gameObject.GetComponent<SurvivalStatus>().humanHp <= 50)
                {
                    fallenWalk();
                }

            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
            {
                player.SetBool("walk", false);
                player.SetBool("injurewalk", false);
                player.SetBool("fallenwalk", false);
            }

            if (gameObject.GetComponent<SurvivalStatus>().humanHp == 150 && Input.GetKey(KeyCode.LeftShift))
            {
                player.SetBool("run", true);
            }

            if (gameObject.GetComponent<SurvivalStatus>().humanHp > 50 && gameObject.GetComponent<SurvivalStatus>().humanHp < 150 && Input.GetKey(KeyCode.LeftShift))
            {
                player.SetBool("run", false);
                player.SetBool("injurerun", true);
            }

            if (gameObject.GetComponent<SurvivalStatus>().humanHp > 0 && gameObject.GetComponent<SurvivalStatus>().humanHp <= 50 && Input.GetKey(KeyCode.LeftShift))
            {
                player.SetBool("run", false);
                player.SetBool("injurerun", false);
                player.SetBool("injurewalk", false);
                player.SetBool("fallenwalk", true);
            }


            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                player.SetBool("run", false);
                player.SetBool("injurerun", false);
            }
        }
        else
        {
            player.SetBool("isfallen", false);
            player.SetTrigger("isdeath");
        }
    }

    public void walk()
    {
        player.SetBool("walk", true);
    }

    public void injureWalk()
    {
        player.SetBool("injurewalk", true);
    }

    public void fallenWalk()
    {
        player.SetBool("fallenwalk", true);
    }
}
