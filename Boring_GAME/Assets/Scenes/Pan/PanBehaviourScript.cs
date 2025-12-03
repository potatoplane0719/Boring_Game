using UnityEngine;

public class PanBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 2.0f;
    private float randomX = 0f;

    void Start()
    {
        
        randomX = Random.Range(-2.3f, 2.3f);
        transform.Translate(randomX,0, 0);
    }
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        if(transform.position.y > 6f)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<GameControl>().Spawn();
        }
    }

}
