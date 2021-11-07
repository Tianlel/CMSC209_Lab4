using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBehavior : MonoBehaviour
{
    public Text end_result_text;
    public GameObject hud;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetMessage(string message) {
        end_result_text.text = message;
        hud.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
        hud.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
