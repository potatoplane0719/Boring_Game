using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    private GameObject now_floor = null;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarBehaviourScript healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
          
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
          
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Pan")
        {
            //Debug.Log("fw Pan");
            if (other.contacts[0].normal.y > 0.5f)
            {
                //Debug.Log("Landed on Top of Pan");
                health(10);
                now_floor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Trap")
        {
            //Debug.Log("fw Trap");
            if (other.contacts[0].normal.y > 0.5f)
            {
                //Debug.Log("Landed on Top of Trap");
                health(-10);
                now_floor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "DeathFloor")
        {
            Debug.Log("_You Died_");
        }

    }
    void health(int point)
    {
        Debug.Log("health: " + point);
        Debug.Log("current Health: " + currentHealth);
        if (currentHealth + point <= maxHealth)
        {
            currentHealth += point;
        }
            
        healthBar.SetHealth(currentHealth);
    }
}
