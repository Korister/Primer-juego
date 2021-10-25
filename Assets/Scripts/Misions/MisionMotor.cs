using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionMotor : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject canvasJoysticks;
    public GameObject slider;
    public float sliderValue;
    public bool playerClose;
    public bool reparing;
    public bool isComplete;

    // Start is called before the first frame update
    void Start()
    {
        canvasJoysticks = GameObject.FindWithTag("Joysticks");
        button = GameObject.FindWithTag("MissionButton");
    }

    // Update is called once per frame
    void Update()
    {
        button.gameObject.SetActive(playerClose);
        if(reparing == true && isComplete == false)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerClose = false;
        }
    }

    public void OnPress()
    {
        if(reparing == false)
        {
            reparing = true;
        }
        else
        {
            reparing = false;
        }
    }
}
