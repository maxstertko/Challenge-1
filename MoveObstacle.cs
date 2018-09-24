using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour {

    public float speed;
    public Transform EndPositionGO;
    public Transform StartPositionGO;

    private bool opposite;

	// Use this for initialization
	void Start () {
        opposite = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (opposite == false) {
            transform.position = Vector3.MoveTowards(transform.position, EndPositionGO.position, speed * Time.deltaTime);
            if(transform.position == EndPositionGO.position) {
                opposite = true;
            }
        } else if(opposite == true) {
            transform.position = Vector3.MoveTowards(transform.position, StartPositionGO.position, speed * Time.deltaTime);
            if(transform.position == StartPositionGO.position) {
                opposite = false;
            }
        }
	}
}
