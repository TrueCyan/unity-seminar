using UnityEngine;
using UnityEngine.UI;
public class ButtonAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
    {
        Debug.Log("Button clicked");
    }

    public void Click2()
    {
        Debug.Log("Button clicked 2");
    }
}
