using UnityEngine;
using UnityEngine.UI;

public class ToggleImages : MonoBehaviour
{
    public Button toggleButton;  // Botão que será usado para alternar as imagens
    public GameObject image1;    // Primeiro objeto de imagem
    public GameObject image2;    // Segundo objeto de imagem
    public GameObject image3;    // Terceiro objeto de imagem
    // Adicione mais campos de imagem se precisar

    private int currentImageIndex = 0; // Índice da próxima imagem a ser ativada

    void Start()
    {
        toggleButton.onClick.AddListener(ShowNextImage);

        // Certifique-se de que todas as imagens estão inicialmente desativadas
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
    }

    void ShowNextImage()
    {
        // Ativa a próxima imagem com base no índice atual
        switch (currentImageIndex)
        {
            case 0:
                image1.SetActive(true);
                break;
            case 1:
                image2.SetActive(true);
                break;
            case 2:
                image3.SetActive(true);
                break;
            // Adicione mais casos, caso tenha mais imagens
        }

        // Avança o índice para a próxima imagem
        currentImageIndex++;

        // Verifica se o índice ultrapassou o número de imagens
        // Se sim, para de avançar (ou você pode resetar para o início se quiser um loop)
        if (currentImageIndex >= 3)
        {
            toggleButton.onClick.RemoveListener(ShowNextImage);
            Debug.Log("Todas as imagens foram ativadas.");
        }
    }
}
