using UnityEngine;
using UnityEngine.UI;

public class ToggleObject : MonoBehaviour
{
    [SerializeField] private GameObject _objectToToggle;
    [SerializeField] private Button _button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _button.onClick.AddListener(Toggle);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Toggle()
    {
        _objectToToggle.SetActive(!_objectToToggle.activeSelf);
    }
}
