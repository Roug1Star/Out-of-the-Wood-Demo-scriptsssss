using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControll : MonoBehaviour {

    Transform m_transform, m_camera;//人物自己以及相机的对象
    CharacterController controller;//Charactor Controller组件
    public float MoveSpeed = 20.0f;//移动的速度
    float lasttime;
    public float attackCoolTime = 5;
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
            if (!stateinfo.IsName("Attack"))//如果不在攻击，则可以移动，否则禁止移动
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

                controller.Move(m_transform.forward * Time.deltaTime * MoveSpeed);
                

            }
        }

        if (!controller.isGrounded)
        {
            //模拟简单重力，每秒下降10米，当然你也可以写成抛物线
            controller.Move(new Vector3(0, -10f * Time.deltaTime, 0));
        }
    }
}

