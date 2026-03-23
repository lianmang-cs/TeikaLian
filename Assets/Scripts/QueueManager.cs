using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public Sprite[] UISprites;
    public int[] queue;
    private SpriteRenderer[] childRenderers;
    public int maxFruit; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        queue = new int[6];
        childRenderers = new SpriteRenderer[4];
        for(int i = 0; i < transform.childCount; i++)
        {
            childRenderers[i] = transform.GetChild(i).GetComponent<SpriteRenderer>(); 
        } 
        for(int i = 0; i < queue.Length; i++)
        {
            //0 to 4 but not including 4
            queue[i] = Random.Range(0, maxFruit+1); 
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            childRenderers[i].sprite = UISprites[queue[i]];
        }
        
    }
    public int updateQueue()
    {
        int currentType = queue[0]; 
        for(int i = 1; i < queue.Length; i++)
        {
            queue[i-1] = queue[i]; 
        }
        queue[queue.Length-1] = Random.Range(0, maxFruit+1); 
        return currentType;
    }
}
