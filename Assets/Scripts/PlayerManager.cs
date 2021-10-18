using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    #region Private Fields

    [SerializeField]
    private GameObject weapon;
    bool isAttacking;

    #endregion

    #region MonoBehaviour Callbacks

    void Awake()
    {
        weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        weapon.SetActive(isAttacking);  
    }

    #endregion

    #region Custom

    public void Process()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
            isAttacking = true;
            yield return new WaitForSeconds(0.5f);
            isAttacking = false;
    }

    #endregion
}