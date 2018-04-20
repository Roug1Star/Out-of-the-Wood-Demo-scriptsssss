using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalCtl : MonoBehaviour {

    Transform m_transform, m_camera;//人物自己以及相机的对象
    CharacterController controller;//Charactor Controller组件
    public float MoveSpeed = 3f;//移动的速度
    public float RunSpeed = 4f;//跑步速度
    public float FallenSpeed = 2f;//倒地爬行速度
    private Animator animator;


    void Start()
    {
        m_transform = this.transform;
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").transform;//
        controller = GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);//获取当前动作
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            if (!stateinfo.IsName("Death"))//如果没有死亡，可以移动
            {
                if (Input.GetKey(KeyCode.W))
                {
                    //根据主相机的朝向决定人物的移动方向，下同
                    controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y, 0);
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 180f, 0);
                }

                else if (Input.GetKey(KeyCode.A))
                {
                    controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 270f, 0);
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 90f, 0);
                }

                isRuning();
                //controller.Move(m_transform.forward * Time.deltaTime * MoveSpeed);

            }
        }

        if (!controller.isGrounded)
        {
            //模拟简单重力，每秒下降10米，当然你也可以写成抛物线
            controller.Move(new Vector3(0, -10f * Time.deltaTime, 0));
        }
    }

    public void isRuning()
    {
        if (gameObject.GetComponent<SurvivalStatus>().humanHp > 50)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(m_transform.forward * Time.deltaTime * RunSpeed);
            }
            else
            {
                controller.Move(m_transform.forward * Time.deltaTime * MoveSpeed);
            }
        }

        else
        {
            controller.Move(m_transform.forward * Time.deltaTime * MoveSpeed);  //防止出现角色移动反向，必须添加该代码更正角色移动方向
            controller.Move(m_transform.forward * Time.deltaTime * -FallenSpeed);
        }
    }
}
