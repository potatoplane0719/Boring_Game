using UnityEngine;

public class PanOffset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PanOffsetMove(float y)
    {
        transform.Translate(0, y, 0);
    } 
}
