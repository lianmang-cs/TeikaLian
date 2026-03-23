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
            //Game Over 
            if(timeThusFar > timeout) {
                gameOver.SetActive(true);
                //disable the player behaviour script
                GameObject player = GameObject.FindGameObjectWithTag("Player"); 
                player.GetComponent<PlayerBehaviour>().enabled = false; 
                //play game over audio
                gameOver.GetComponent<AudioSource>().Play(); 
            }
        }   
    }
    private void OnTriggerExit2D(Collider2D other) {
        
    }


}
