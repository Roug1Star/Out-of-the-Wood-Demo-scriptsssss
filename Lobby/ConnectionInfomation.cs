using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionInfomation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponentInChildren<Text>().text = PhotonNetwork.connectionStateDetailed.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
