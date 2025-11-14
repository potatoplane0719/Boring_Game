using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RestartBotton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject button;
    public void Start()
    {
        
        Button Button = this.GetComponent<Button>();
        Button.onClick.AddListener(Restart);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0");
    }
}
