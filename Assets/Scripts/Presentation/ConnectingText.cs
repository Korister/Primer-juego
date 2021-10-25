using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectingText : MonoBehaviour
{
    [SerializeField]
    private GameObject connectingText;
    [SerializeField]
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectText()
    {
        connectingText.SetActive(true);
        panel.SetActive(false);
        StartCoroutine(Enter());
    }

    IEnumerator Enter()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(1);
    }
}
