using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunicaoScript : MonoBehaviour
{
    private float velocidadeMunicao;
    private int contadorLife;
    private int toogle;

    // Start is called before the first frame update
    void Start()
    {
        this.toogle = GameObject.FindWithTag("Arma").GetComponent<ArmaScript>().toogle;

        this.contadorLife = 0;
        this.velocidadeMunicao = 40 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.toogle==1){
            transform.Translate(-0.0070f,0.01f,velocidadeMunicao);
        }else{
            transform.Translate(0.005f,0.01f,velocidadeMunicao);
        }

        contadorLife++;
        if(contadorLife>=40){
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision){
        Destroy(gameObject);
    }
}
