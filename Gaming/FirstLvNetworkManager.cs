using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLvNetworkManager : Photon.PunBehaviour {

    public GameObject playerPrefab;
    public GameObject survivalPrefab1;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnScenceLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnScenceLoaded;
    }

    void OnScenceLoaded(Scene scene,LoadSceneMode mode)
    {
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 5, 0), Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(survivalPrefab1.name, new Vector3(0, 5, 0), Quaternion.identity, 0);
        }

        
    }


}
