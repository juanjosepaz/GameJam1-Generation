using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class cont : MonoBehaviour
{
    public static cont Instance;
    public int conta=0;
    public TextMeshProUGUI texto;
    private void Awake(){
        if(Instance==null){
            Instance= this;
        }else{
            Destroy(gameObject);
        }
    }
    public void Enemigo(){
        conta++;
        texto.text="	"+conta.ToString() + "/15";
    }
}
