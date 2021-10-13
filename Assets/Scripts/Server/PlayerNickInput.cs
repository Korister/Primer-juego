using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerNickInput : MonoBehaviour
{
    #region Private Constants

    const string defaultPlayerNick = "PlayerName";
    private InputField _inputField;

    #endregion

    #region MonoBehaviour Callbacks

    // Start is called before the first frame update
    void Start()
    {
        string defaultName = string.Empty;
        _inputField = this.GetComponent<InputField>();
        if(_inputField = null)
        {
            if(PlayerPrefs.HasKey(defaultPlayerNick))
            {
                defaultName = PlayerPrefs.GetString(defaultPlayerNick);
                _inputField.text = defaultName;
            }
        }

        PhotonNetwork.NickName = defaultName;
    }

    #endregion

    #region Public Methods

    public void SetPlayerName(string value)
    {
        if(string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Nick is null or empty");
            return;
        }
        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString(defaultPlayerNick, value);
    }

    #endregion
}
