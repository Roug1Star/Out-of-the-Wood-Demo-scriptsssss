using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyNetworkManager : Photon.PunBehaviour {

    public int maxPlayerPerRoom;

	// Use this for initialization
	void Start () {

        PhotonNetwork.ConnectUsingSettings("1.0.0");
        
    }
	
	// Update is called once per frame
	void Update () {

        GameObject.Find("ConnectedInfo").GetComponent<Text>().text = PhotonNetwork.connectionStateDetailed.ToString();  //查看是否连接上服务器

        if (PhotonNetwork.connected)
        {
            GameObject.Find("ConnectedInfo").GetComponent<Text>().text = "你已成功连接服务器。";
        }
        if(PhotonNetwork.connecting)
        {
            GameObject.Find("ConnectedInfo").GetComponent<Text>().text = "正在连接，请稍后。";
        }
        if(!PhotonNetwork.connected && !PhotonNetwork.connecting)
        {
            GameObject.Find("ConnectedInfo").GetComponent<Text>().text = "连接失败，请重试。";
        }
       
        
    }

    public void RefreshRoom()
    {
        foreach (RoomInfo room in PhotonNetwork.GetRoomList())
        {
            GameObject.Find("RoomList").GetComponent<Text>().text = "房间：" + "  "+ room.Name + "                 " + "人数："+ " " + room.PlayerCount + " " + "/" + "4";
        }
    }


    public void StartMatching()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        PhotonNetwork.CreateRoom("皮皮星的测试");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("created room");
        PhotonNetwork.CreateRoom(GameObject.Find("InputField").GetComponentInChildren<Text>().text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("join room");
        PhotonNetwork.automaticallySyncScene = true;
        GameObject.Find("JoinRoomInfo").GetComponent<Text>().text = "你已加入  "+ PhotonNetwork.room.Name + " 的房间";
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        int playernumber = PhotonNetwork.playerList.Length;
        Debug.Log(playernumber + " players now in the Room");
        if (playernumber == maxPlayerPerRoom)
        {
            if (PhotonNetwork.isMasterClient)
            {
                PhotonNetwork.LoadLevel("Gaming");
            }
        }
    }


}
