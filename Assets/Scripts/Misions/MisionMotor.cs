using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionMotor : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    private GameObject canvasPlayer;
    private GameObject canvasJoysticks;
    private Animator anim;
    
    public Slider slider;
    public float sliderValue;
    public bool playerClose;
    public bool reparing;
    public bool isComplete;

    // Start is called before the first frame update
    void Start()
    {
        canvasPlayer = GameObject.FindWithTag("CanvasPlayer");
        canvasJoysticks = canvasPlayer.transform.GetChild(1).gameObject;
        button = canvasPlayer.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            OnPress();
        }
        //button.gameObject.SetActive(playerClose);
        if(reparing == true && isComplete == false)
        {
            //canvasJoysticks.gameObject.SetActive(false);
            StartCoroutine(Cont());
            if(slider.value == 100f)
            {
                isComplete = true;
                reparing = false;
                anim.SetBool("Reparing", reparing);
            }
        }
        if(reparing == false && isComplete == false)
        {
            //canvasJoysticks.gameObject.SetActive(true);
            StopCoroutine(Cont());
        }
        if(isComplete == true)
        {
            reparing = false;
            StopCoroutine(Cont());
            //canvasJoysticks.gameObject.SetActive(true);
            //button.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerClose = true;
            anim = other.GetComponent<Animator>();
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
            anim.SetBool("Reparing", reparing);
        }
        else
        {
            reparing = false;
            anim.SetBool("Reparing", reparing);
        }
    }

    IEnumerator Cont()
    {
        yield return new WaitForSeconds(0.1f);
        sliderValue += 0.1f;
        slider.value = sliderValue;
    }
}
