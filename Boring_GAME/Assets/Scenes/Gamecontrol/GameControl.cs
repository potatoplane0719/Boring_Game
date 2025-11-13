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
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
