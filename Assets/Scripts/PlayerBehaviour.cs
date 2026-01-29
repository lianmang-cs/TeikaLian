using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    //variable for speed of the player
    public float speed = 0.01f; 
    public GameObject fruit; 
    public float offY = -0.6f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        //Fruit position below player
        if (fruit != null) {
            //current player position
            Vector3 playerPos = transform.position;
            //(x, y, z)
            Vector3 fruitOffset = new Vector3(0.0f, offY, 0.0f); 
            fruit.transform.position = playerPos + fruitOffset;
        }
        //Drop the fruit
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            Rigidbody2D body = fruit.GetComponent<Rigidbody2D>(); 
            body.gravityScale = 1.0f; 
            Collider2D collider = fruit.GetComponent<Collider2D>(); 
            collider.enabled = true; 
            fruit = null; 
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
