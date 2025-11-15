using UnityEngine;

public class CoinBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float randomX = 0f;
    private float randomY = 0f;
    void Start()
    {
        randomX = Random.Range(-1.9f, 1.9f);
        randomY = Random.Range(-1.5f, 1.2f);
        transform.Translate(randomX, randomY, 0);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            transform.parent.GetComponent<GameControl>().SpawnCoin();
        }
    }
}
