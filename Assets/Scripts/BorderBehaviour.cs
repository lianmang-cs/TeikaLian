using UnityEngine;
using UnityEngine.InputSystem;

public class BorderBehaviour : MonoBehaviour
{
    public float timeout; 
    public float timeStart; 
    public GameObject gameOver; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Fruit")) {
            timeStart = Time.time; 
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Fruit")) {
            float currentTime = Time.time;
            float timeThusFar = currentTime - timeStart; 

            if(timeThusFar > timeout) {
                gameOver.SetActive(true);
                print("Game Over!");
            }
        }   
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Fruit")) {
            timeStart = 0.0f; 
        }  
    }


}
