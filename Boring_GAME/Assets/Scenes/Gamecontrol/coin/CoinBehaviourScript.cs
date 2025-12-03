using UnityEngine;

public class CoinBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float randomX = 0f;
    private float randomY = 0f;
    public Animator animator;
    void Start()
    {
        randomX = Random.Range(-3.6f, 3.6f);
        randomY = Random.Range(-1.2f, 3.0f);
        transform.Translate(randomX, randomY, 0);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //GetComponent<Collider2D>().enabled = false;
            //animator.SetTrigger("CoinCollected");
            DestoryCoin();
            //transform.parent.GetComponent<GameControl>().SpawnCoin();
        }
        if(other.gameObject.tag == "DeathFloor")
        {
            DestoryCoin();
        }
    }
    void DestoryCoin()
    {
        Destroy(gameObject);
    }
}
