using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private int score;
    //private int overall;
    private bool movelvl;

    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetAllText();
        winText.text = "";
        movelvl = false;
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit(); //quit game
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false); //removes pick ups on collision
            count++;
            score++;
            SetAllText();
        } else if(other.gameObject.CompareTag("Avoid")){
            other.gameObject.SetActive(false); //removes picks ups on collsion
            score--;
            SetAllText();
        }
        if(movelvl == true) {
            StartCoroutine(MoveToLevel2(10));
            movelvl = false;
        }
    }
    void SetAllText() { //keeps count of pick up
        countText.text = "Count: " + count.ToString(); //keeps count of pick up
        scoreText.text = "Score: " + score.ToString(); //keeps count of score
        if (count == 12) {
            winText.text = "You finished with a score of: " + score.ToString(); //win condition for level 1
            movelvl = true;
         }
        if (count == 24) {
            winText.text = "You finished with a score of: " + score.ToString(); //win condition for level 2
        }
    }
    IEnumerator MoveToLevel2(float time) {
        yield return new WaitForSeconds(time); //delays start of new level
        transform.position = new Vector3(17.0f, 0.5f, 0.0f); //when calling Player.transform.position.y an error was given
        winText.text = "";
    }
}
