using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    //variable for speed of the player
    public float speed = 0.01f; 
    public float offY = -0.6f; 
    private GameObject currentFruit; 
    public GameObject[] fruits;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            int choice = Random.Range(0, fruits.Length); 
            currentFruit = Instantiate(fruits[choice], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
        //Drop the fruit
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            Rigidbody2D body = currentFruit.GetComponent<Rigidbody2D>(); 
            body.gravityScale = 1.0f; 
            Collider2D collider = currentFruit.GetComponent<Collider2D>(); 
            collider.enabled = true; 
            currentFruit = null; 
        }
        //Left move
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed; 
            transform.position = newPos; 
        }
        //Right move
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed; 
            transform.position = newPos; 
        }      
    }
}
