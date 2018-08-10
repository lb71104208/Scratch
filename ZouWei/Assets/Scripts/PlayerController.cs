using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform Player;
    private float speed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float moveY = translation * Time.deltaTime;

        translation = Input.GetAxis("Horizontal") * speed;
        float moveX = translation * Time.deltaTime;

        Player.Translate(moveX, moveY, 0);
    }
}
