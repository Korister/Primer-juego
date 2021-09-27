using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordPanel : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TextMeshProUGUI password;
    
    private Mision canvas;

    public void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("MissionPanel").GetComponent<Mision>();
    }

    public void Start()
    {
        GeneratePassword();
    }

    public void AddNumber(string number)
    {
        if(display.text.Length >=6)
        {
            return;
        }
        display.text += number;
    }

    public void EraseDisplay()
    {
        display.text = "";
    }

    public void GeneratePassword()
    {
        password.text = "";

        for(int i = 0 ; i<6 ; i++)
        {
            int randNumber = UnityEngine.Random.Range(0, 9);
            password.text += randNumber;
        }
    }

    public void CheckPassword()
    {
        if(display.text.Equals(password.text))
        {
            display.color = Color.green;
            display.text = "APROVED";
            canvas.ActivateCanvas();
            Destroy(gameObject, 1.0f);
        }
        else
        {
            StartCoroutine(Error());
        }
    }

    IEnumerator Error()
    {
        display.color = Color.red;
        display.text = "ERROR";
        yield return new WaitForSeconds(1.0f);
        display.color = Color.white;
        display.text = "";
    }
}
