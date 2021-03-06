using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mision : MonoBehaviour
{
    public GameObject button;
    public GameObject missionPrefab;
    public GameObject playerCanvas;
    public bool playerClose;

    void Awake()
    {
        playerCanvas = GameObject.FindWithTag("CanvasPlayer");
        button = playerCanvas.transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isMissionActive())
        {
            button.gameObject.SetActive(playerClose);
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
            button.gameObject.SetActive(false);
            playerClose = false;
        }
    }

    private bool isMissionActive()
    {
        return playerClose && !GameObject.FindWithTag("Mission");
    }

    public void ActivateCanvas()
    {
        playerCanvas.gameObject.SetActive(true);
        button.gameObject.SetActive(false);
    }

    public void ActivatorMission()
    {
        Instantiate(missionPrefab);
    }
}
