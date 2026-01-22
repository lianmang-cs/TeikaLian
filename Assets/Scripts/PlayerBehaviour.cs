using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    //variable for speed of the player
    public float speed; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        //Left arrow key
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed; 
            transform.position = newPos; 
        }
        //Right arrow key
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed; 
            transform.position = newPos; 
        }
        
        
    }
}
