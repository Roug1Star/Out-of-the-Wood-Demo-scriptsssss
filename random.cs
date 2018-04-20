using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour {

    public GameObject stone;
	// Use this for initialization
	void Start () {

        for (int i = 0; i < 10; i++)
        {
            Instantiate(stone, new Vector3(Random.Range(0f, 30f), 1, Random.Range(0f, 30f)), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
