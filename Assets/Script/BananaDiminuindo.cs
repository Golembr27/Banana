using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaDiminuindo : MonoBehaviour
{
    float velocidadeDiminuir = 2f;
    public float tempoParaDiminuir = 1.5f;
    Transform irposicao;
    public float velocidade = 5.0f;
    public float velocidadeDiminuicao = 1.0f;
    private bool diminuindo = false;
    private Vector3 tamanhoOriginal;
    private float tempoInicial;

    // Start is called before the first frame update
    void Start()
    {
        irposicao = GameObject.Find("Posicao").GetComponent<Transform>();
        tamanhoOriginal = transform.localScale;
        tempoInicial = tempoParaDiminuir;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direcao = (irposicao.position - transform.position).normalized;
        float distancia = Vector3.Distance(transform.position, irposicao.position);

        if (tempoParaDiminuir > 0)
        {
            tempoParaDiminuir -= Time.deltaTime;
        }
        else
        {
            tempoParaDiminuir = 0;
        }

        if (tempoParaDiminuir <= 0f)
        {
            if (!diminuindo && distancia <= 0.2f) // Quando estiver próximo da posição irposicao
            {
                diminuindo = true;
            }

            if (diminuindo == true)
            {
                // Diminui o tamanho do objeto
                transform.localScale -= Vector3.one * velocidadeDiminuicao * Time.deltaTime;
                // Se o tamanho for menor que um limite, destrói o objeto
                if (transform.localScale.x <= 0.1f)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                // Move em direção à posição irposicao
                transform.Translate(direcao * velocidade * Time.deltaTime);
            }
        }
    }

    void OnDestroy()
    {
        tempoParaDiminuir = tempoInicial;
    }
}