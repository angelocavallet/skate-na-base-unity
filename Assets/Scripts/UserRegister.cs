using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Biblioteca necessária para usar TMP_InputField

public class UserRegister : MonoBehaviour
{
    // Substituímos InputField por TMP_InputField para compatibilidade com TextMesh Pro
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button registerButton;
    public Button goToLoginButton;
    public GameObject panelAtual;
    public GameObject panelAction;
    public bool isPanelVisible = false;

    ArrayList credentials;

    void Start()
    {
        registerButton.onClick.AddListener(writeStuffToFile);
        goToLoginButton.onClick.AddListener(goToLoginScene);

        if (File.Exists(Application.dataPath + "/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/credentials.txt", "");
        }
    }

    void goToLoginScene()
    {
        isPanelVisible = !isPanelVisible; // Inverte o estado de visibilidade
        panelAction.SetActive(isPanelVisible);  
        panelAtual.SetActive(isPanelVisible);
    }

    void writeStuffToFile()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(usernameInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Username '{usernameInput.text}' already exists");
        }
        else
        {
            credentials.Add(usernameInput.text + ":" + passwordInput.text);
            File.WriteAllLines(Application.dataPath + "/credentials.txt", (String[])credentials.ToArray(typeof(string)));
            Debug.Log("Account Registered");
        }
    }
}
