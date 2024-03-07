using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    public int actualLife = 3;

    public void RechargingLife(int increaseLife, int maxLife)
    {
        actualLife += increaseLife;

        // Asegúrate de que la vida no supere la vida máxima
        actualLife = Mathf.Min(actualLife, maxLife);

        // Puedes agregar aquí cualquier lógica adicional, como actualizar la interfaz de usuario, etc.
    }
}
