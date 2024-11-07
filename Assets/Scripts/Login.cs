using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Biblioteca necessária para usar TMP_InputField

public class Login : MonoBehaviour
{
    // Substituímos InputField por TMP_InputField para compatibilidade com TextMesh Pro
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button loginButton;
    public Button goToRegisterButton;
    public GameObject panelAtual;
    public GameObject panelAction;
    public GameObject panelReturn;
    public bool isPanelVisible = false;

    ArrayList credentials;

    void Start()
    {
        loginButton.onClick.AddListener(login);
        goToRegisterButton.onClick.AddListener(moveToRegister);

        if (File.Exists(Application.dataPath + "/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        }
        else
        {
            Debug.Log("Credential file doesn't exist");
        }
    }

    void login()
    {
        bool isExists = false;
        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));

        foreach (var i in credentials)
        {
            string line = i.ToString();
            string storedUsername = line.Substring(0, line.IndexOf(":"));
            string storedPassword = line.Substring(line.IndexOf(":") + 1);

            if (storedUsername.Equals(usernameInput.text) && storedPassword.Equals(passwordInput.text))
            {
                isExists = true;

                // Salva o nome do usuário logado usando PlayerPrefs
                PlayerPrefs.SetString("LoggedInUser", storedUsername);
                PlayerPrefs.Save();
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Logging in '{usernameInput.text}'");
            loadWelcomeScreen();
        }
        else
        {
            Debug.Log("Incorrect credentials");
        }
    
    }

    void moveToRegister()
    {
        isPanelVisible = !isPanelVisible; // Inverte o estado de visibilidade
        panelReturn.SetActive(isPanelVisible);  
        panelAtual.SetActive(isPanelVisible); 
    }

    void loadWelcomeScreen()
    {
        isPanelVisible = !isPanelVisible; // Inverte o estado de visibilidade
        panelAction.SetActive(isPanelVisible);  
        panelAtual.SetActive(isPanelVisible); 
    }
}
