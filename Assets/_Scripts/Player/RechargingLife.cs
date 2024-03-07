using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargingLife : MonoBehaviour
{
    public int increaseLife = 1;
    public int maxLife = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifePlayer lifePlayer = other.GetComponent<LifePlayer>();

            if (lifePlayer != null)
            {
                lifePlayer.RechargingLife(increaseLife, maxLife);
            }
        }

        if (other.TryGetComponent(out ControlDedisparo playerShoot))
        {
            playerShoot.Recharge();
        }
    }
}
