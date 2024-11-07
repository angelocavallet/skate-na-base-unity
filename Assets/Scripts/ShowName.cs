using UnityEngine;
using TMPro;

public class ShowName : MonoBehaviour
{
    public TextMeshProUGUI loggedInUserText;

    void Start()
    {
        DisplayUsername();
    }

    void DisplayUsername()
    {
        // Carrega o nome do usuário logado do PlayerPrefs
        string loggedInUser = PlayerPrefs.GetString("LoggedInUser", "Guest");

        // Exibe o nome na tela
        loggedInUserText.text = $"Bem-vindo, {loggedInUser}!";
    }
}
