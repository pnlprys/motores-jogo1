using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class NewBehaviourScript : MonoBehaviour
{
    private TextMeshProUGUI componentetexto;
    private AudioSource _audioSource;
    private string mensagemOriginal;
    public bool imprimindo;
    public float tempoentreletras = 0.08f;

    private void Awake()
    {
        TryGetComponent(out componentetexto);
        TryGetComponent(out _audioSource);
        mensagemOriginal = componentetexto.text;
        componentetexto.text = "";
    }

    private void OnEnable()
    {
        ImprimirMensagem(mensagemOriginal);
    }

    private void OnDisable()
    {
        componentetexto.text = mensagemOriginal;
        StopAllCoroutines();
    }


    public void ImprimirMensagem(string mensagem)
    {
        if (gameObject.activeInHierarchy)
        {
            if (imprimindo) return;
            imprimindo = true;
            StartCoroutine(LetraPorLetra(mensagem));
        }
    }

    IEnumerator LetraPorLetra(string mensagem)
    {
        string msg = "";
        foreach (var letra in mensagem)
        {
            msg += letra;
            componentetexto.text = msg;
            _audioSource.Play();
            yield return new WaitForSeconds(tempoentreletras);
        }

        imprimindo = false;
        StopAllCoroutines();
    }
}
