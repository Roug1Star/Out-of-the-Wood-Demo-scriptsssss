using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetUp : MonoBehaviour {

    public Camera myCamera;
    public Behaviour[] stuffNeedDisable;

    PhotonView pv;

	// Use this for initialization
	void Start () {
        pv = GetComponent<PhotonView>();
        if (!pv.isMine)
        {
            myCamera.enabled = false;   //关闭摄像机
            for(int i =0;i<stuffNeedDisable.Length; i++)    //遍历不用的组件
            {
                stuffNeedDisable[i].enabled = false;    //将不要的组件关闭，避免photon同步出现可以控制他人角色的问题
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
