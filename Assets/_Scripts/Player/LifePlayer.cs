using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    public int actualLife = 3;

    public int maxLife =5;
    public Slider slider;

    public GameOverMenu gameOver;

    public Animator animator;

    private void Start() {
        actualLife=maxLife;
        slider.value = actualLife;
        slider.maxValue = maxLife;
    }
    public void RechargingLife(int increaseLife, int maxLife)
    {
        actualLife += increaseLife;

        // Asegúrate de que la vida no supere la vida máxima
        actualLife = Mathf.Min(actualLife, maxLife);

        // Puedes agregar aquí cualquier lógica adicional, como actualizar la interfaz de usuario, etc.
    }

    public void TomarDano(){
        actualLife --;
        slider.value = actualLife;

        if (actualLife <=0){
            animator.SetTrigger("Death");
            gameOver.EnableGameOverMenu();

        }
    }

    
}
