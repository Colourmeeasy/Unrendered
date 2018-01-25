using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal"));
	}
}
