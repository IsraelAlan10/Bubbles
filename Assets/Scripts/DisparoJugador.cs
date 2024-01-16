using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float tiempoEntreAtaques;
    private float tiempoSiguienteAtaque;

    // Update is called once per frame
    void Update()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2") && tiempoSiguienteAtaque <= 0)
        {
            Disparar();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }
    public void Disparar()
    {
        Instantiate(bullet ,controladorDisparo.position, controladorDisparo.rotation);
    }
}
