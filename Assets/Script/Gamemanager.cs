using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;//Canvas

public class Gamemanager : MonoBehaviour
{
    public GameObject PrefabBanana1;
    public GameObject PrefabBanana2;
    public GameObject PrefabBanana3;
    int bananaPontos  = 0;
    int toqueBanan = 0;
    public TextMeshProUGUI pontosText;

    // Start is called before the first frame update
    void Start()
    {
        AtualizarTextoPontos();
    }
    void Update()
    {
        // Verifica se houve um toque na tela
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            toqueBanan = 1;
            Debug.Log(Input.touchCount);
             Touch touch = Input.GetTouch(0);
            if (Input.touchCount == 1 & toqueBanan == 1)
            {
                toqueBanan = 2;
                //Vector3 mousePosition = Input.mousePosition;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                Instantiate(PrefabBanana1, worldPosition, Quaternion.identity);
            }
            if (Input.touchCount == 2 & toqueBanan == 2)
            {
                toqueBanan = 3;
                //Vector3 mousePosition = Input.mousePosition;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                Instantiate(PrefabBanana2, worldPosition, Quaternion.identity);
            }
            if (Input.touchCount == 3 & toqueBanan == 3)
            {
                toqueBanan = 1;
                //Vector3 mousePosition = Input.mousePosition;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                Instantiate(PrefabBanana3, worldPosition, Quaternion.identity);
            }
            // Incrementa os pontos de banana
            bananaPontos++;

            // Atualiza o texto para refletir os novos pontos de banana
            AtualizarTextoPontos();
        }
    }
    void AtualizarTextoPontos()
    {
        pontosText.text = bananaPontos.ToString();
    }

}
