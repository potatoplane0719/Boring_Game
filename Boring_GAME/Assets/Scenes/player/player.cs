using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    private GameObject now_floor = null;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarBehaviourScript healthBar;
    public Score scorescript;

    private Animator animator;
    [SerializeField] GameObject button;
    public AudioSource audioSource;
    public AudioClip coinaudioClip;
    public AudioClip hurtAudio;
    public AudioClip stepAudio;
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        button.SetActive(false); 
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            
            transform.Translate(speed * Time.deltaTime, 0, 0);

            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * 1;
            transform.localScale = scale;
            animator.SetBool("Walk",true);
            if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("Walk",false);
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walk",false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
          
            transform.Translate(-speed * Time.deltaTime, 0, 0);

            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.localScale = scale;
            animator.SetBool("Walk",true);
            if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("Walk",false);
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Walk",false);
        }
        

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Pan")
        {
            //Debug.Log("fw Pan");
            if (other.contacts[0].normal.y > 0.5f)
            {
                //Debug.Log("Landed on Top of Pan");
                health(10);
                audioSource.PlayOneShot(stepAudio,1);
                now_floor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Trap")
        {
            //Debug.Log("fw Trap");
            if (other.contacts[0].normal.y > 0.5f)
            {
                //Debug.Log("Landed on Top of Trap");
                audioSource.PlayOneShot(hurtAudio,1);
                health(-20);
                now_floor = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Ceiling")
        {
            
            health(-20);
            now_floor.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (other.gameObject.tag == "DeathFloor")
        {
            Debug.Log("_You Died_");
            
            Time.timeScale = 0;
            button.SetActive(true); 
        }
        

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == now_floor)
        {
            now_floor = null;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("Coin Collected");
            audioSource.PlayOneShot(coinaudioClip,1);
            scorescript.ScoreIncrease(10);
            
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
        if(currentHealth <= 0)
        {
            Time.timeScale = 0;
            button.SetActive(true); 
        }
            
        healthBar.SetHealth(currentHealth);
    }

    
}
