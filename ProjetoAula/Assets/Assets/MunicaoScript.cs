using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunicaoScript : MonoBehaviour
{
    public int velocidade;
    private float velocidadeMunicao;
    private int contador;
    private int contadorLife;

    private int toogle;
    // Start is called before the first frame update
    void Start()
    {
        this.toogle = GameObject.FindWithTag("Arma").GetComponent<ArmaScript>().toogle;
        this.contador = 0;
        this.contadorLife = 0;
        this.velocidade = 1;
        this.velocidadeMunicao = 10 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        contador++;
        if(contador==velocidade){
            if(this.toogle==1){
                transform.Translate(-0.0070f,0.01f,velocidadeMunicao);
            }else{
                transform.Translate(0.005f,0.01f,velocidadeMunicao);
            }
            contador = 0;
            contadorLife++;
            if(contadorLife>=40){
                Destroy(gameObject);
            }
        }
        
    }
    void OnCollisionEnter(Collision collision){
        Destroy(gameObject);
    }
}
