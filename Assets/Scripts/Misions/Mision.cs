using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mision : MonoBehaviour
{
    public GameObject button;
    public GameObject missionPrefab;
    public bool playerClose;
    public bool mission;
    public bool missionButton;

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
            playerClose = false;
        }
    }

    public void ActivateMission()
    {
            Instantiate(missionPrefab);
    }

    private bool isMissionActive()
    {
        return playerClose && !GameObject.FindWithTag("Mission");
    }
}
