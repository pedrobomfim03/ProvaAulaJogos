using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaScript : MonoBehaviour
{

    
    public GameObject projetil;
    public GameObject projetil2;
    public GameObject positionl;
    public GameObject position2;
    public GameObject textoMunicao;
    public GameObject arma1;
    public GameObject arma2;
    public AudioSource somTiro;
    public int toogle = 1;
    public int municao;

    private int cooldown;
    private int contadorCooldown;
    private Camera mainCamera;

    void Start()
    {
        this.textoMunicao.GetComponent<Text>().text = "Munição: "+this.municao.ToString();
        this.mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        this.cooldown = 90;
        this.contadorCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        contadorCooldown++;
        if(Input.GetButton("Fire1")){
            
            if(contadorCooldown>=cooldown){
                if(this.municao>0){
                    this.somTiro.Play();
                    if(toogle==1){
                        Instantiate(projetil,positionl.transform.position,positionl.transform.rotation);
                    }else{
                        Instantiate(projetil2,position2.transform.position,position2.transform.rotation);
                    }
                    this.municao--;
                    this.textoMunicao.GetComponent<Text>().text = "Munição: "+this.municao.ToString();
                }
                contadorCooldown = 0;
            }

        }else if(Input.GetButtonDown("Fire2")){
            toogle++;
            if(toogle>3){
                toogle = 1;
            }

            Component[] comps = arma1.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer comp in comps){
                comp.enabled = toogle==1;
            }

            comps = arma2.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer comp in comps){
                comp.enabled = toogle==2 || toogle==3;
            }

            switch(toogle){
                case 1:
                    this.mainCamera.fieldOfView = 60f;
                    break;
                case 2:
                    this.mainCamera.fieldOfView = 45f;
                    break;
                case 3:
                    this.mainCamera.fieldOfView = 25f;
                    break;
            }
        }
    }
}
