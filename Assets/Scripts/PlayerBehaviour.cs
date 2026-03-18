using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class PlayerBehaviour : MonoBehaviour
{
    //variable for speed of the player
    public float speed = 0.01f; 
    public float offY = -0.6f; 
    private GameObject currentFruit; 
    public GameObject[] fruits;
    public float min; 
    public float max;  
    public int move;
    public int[] points; 
    public int totalScore;
    public TMP_Text scoreText; 
    public AudioSource playerAudio; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        move = 0; //0 means you can move both ways
        totalScore = 0; 
    }
    // Update is called once per frame
    void Update() {
        //Fruit position below player
        if (currentFruit != null) {
            //current player position
            Vector3 playerPos = transform.position;
            //(x, y, z)
            Vector3 fruitOffset = new Vector3(0.0f, offY, 0.0f); 
            currentFruit.transform.position = playerPos + fruitOffset;
        }
        else {

            int choice = GameObject.FindGameObjectWithTag("Queue").GetComponent<QueueManager>().updateQueue();
            currentFruit = Instantiate(fruits[choice], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
        //Drop the fruit
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            playerAudio.Play(); 
            Rigidbody2D body = currentFruit.GetComponent<Rigidbody2D>(); 
            body.gravityScale = 1.0f; 
            Collider2D collider = currentFruit.GetComponent<Collider2D>(); 
            collider.enabled = true; 
            currentFruit = null; 
        }
        float offset = 0.0f; 
        //Left move
        //bool left = (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) && move != 1;
        //if (left == true) {
            //offset = -speed;
        //}
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) {
            //Vector3 newPos = transform.position;
            //newPos.x = newPos.x - speed; 
            //transform.position = newPos; 
            offset = -speed;
        }
        //Right move
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) {
            //Vector3 newPos = transform.position;
            //newPos.x = newPos.x + speed; 
            //transform.position = newPos; 
            offset = speed; 
        } 
        Vector3 newPos = transform.position;
        newPos.x = newPos.x + offset; 
        //prevent movement to far right
        if (newPos.x > max) {
            newPos.x = max; 
        }  
        //prevent movement to far left
        if (newPos.x < min) {
            newPos.x = min; 
        }
        transform.position = newPos; 
    }

    public void updateScore(int index) {
        totalScore = totalScore + points[index]; 
        scoreText.SetText("Score: " + totalScore); 
    }
}
