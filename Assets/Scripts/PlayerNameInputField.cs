using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    #region Private Constants
    const string playerNameKey = "PlayerName";//Almacena la clave PlayerPref para evitar errores tipograficos
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        string defaultName = "DefaultName";
        TMP_InputField _InputField = GetComponent<TMP_InputField>();//para poner el texto

        if (_InputField)//para control de errores
        {
            if (PlayerPrefs.HasKey(playerNameKey))//sirve para encontrar la key del nombre
            {

                defaultName = PlayerPrefs.GetString(playerNameKey);//traemos el nombre
                _InputField.name = defaultName;
            }//esto es para saber si el jugador te ha dicho el nomnbre


        }
        PhotonNetwork.NickName = defaultName;//para sincronizar el nombre con los demas

    }

    public void SetPlayerName()
    {
        TMP_InputField _InputField = GetComponent<TMP_InputField>();//acedo al componente
        string playerName = _InputField.text;//el texto que ha puesto el user
        if (string.IsNullOrEmpty(playerName))
        {
           PlayerPrefs.SetString(playerNameKey, playerName);//si el campo de inputfield  se ha rellenado con string y no esta vacio le estableces la key del diccionario
        }
    }
