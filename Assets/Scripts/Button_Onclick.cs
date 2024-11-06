using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Button_Onclick : MonoBehaviour
{
    public GameObject panelAtual;
    public GameObject panelAction;
    public bool isPanelVisible = false;

    public void Start()
    {
        panelAction.SetActive(isPanelVisible);
    }

    // Método para abrir e fechar o painel
    public void TogglePanelVisibility()
    {
        isPanelVisible = !isPanelVisible; // Inverte o estado de visibilidade
        panelAction.SetActive(isPanelVisible);  
        panelAtual.SetActive(isPanelVisible);
    }
}
