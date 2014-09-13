using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		gameObject.layer = 8;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space) && gameObject.layer == 8)
				gameObject.layer = 0;
		else if (Input.GetKeyDown (KeyCode.Space) && gameObject.layer == 0)
				gameObject.layer = 8;
	}
}
