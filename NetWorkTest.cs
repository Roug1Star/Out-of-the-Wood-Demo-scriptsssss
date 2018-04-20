using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWorkTest : Photon.PunBehaviour {

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("1.0.0");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
