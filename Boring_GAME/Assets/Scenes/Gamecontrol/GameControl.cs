using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PanBehaviourScript panScript;
    public Transform PanOffset;
    public PanOffset panOffsetScript;

    public TrapBehaviourScript trapScript;
    public Transform TrapOffset;
    public TrapOffset trapOffsetScript;

    public CoinBehaviourScript coinScript;
    public Transform CoinOffset;
    float CoinSpawning = 0f;
    public float CoinSpawnInterval = 1.5f;
    void Start()
    {
     

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CoinSpawning += Time.deltaTime;
        Debug.Log(CoinSpawning);
        if(CoinSpawning >= CoinSpawnInterval)
        {
            SpawnCoin();
            CoinSpawning = 0f;
        }
        if (Input.GetKey(KeyCode.P))
        {
            SpawnCoin();
        }
        
    }
    public void Spawn()
    {

        Instantiate(panScript, PanOffset.position, PanOffset.rotation, transform);
    }
    public void SpawnTrap()
    {
        //Debug.Log("Spawn Trap Called");
        Instantiate(trapScript, TrapOffset.position, TrapOffset.rotation, transform);
    }
    public void SpawnCoin()
    {
        
        Instantiate(coinScript, CoinOffset.position, CoinOffset.rotation, transform);
    }
}
