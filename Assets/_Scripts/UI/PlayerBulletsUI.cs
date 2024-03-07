using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletsUI : MonoBehaviour
{
    [SerializeField] private ControlDedisparo playerShoot;
    [SerializeField] private Image[] hearthImages;
    [SerializeField] private Sprite hearthFull;
    [SerializeField] private Sprite hearthEmpty;
    private int nextBulletIndex;

    private void Awake()
    {
        nextBulletIndex = hearthImages.Length - 1;

        playerShoot.OnPlayerShoot.AddListener(UseBullet);

        playerShoot.OnPlayerRecharge.AddListener(ChargeBullet);
    }

    private void UseBullet()
    {
        hearthImages[nextBulletIndex].sprite = hearthEmpty;
        nextBulletIndex -= 1;
    }

    private void ChargeBullet()
    {
        nextBulletIndex += 1;
        hearthImages[nextBulletIndex].sprite = hearthFull;
    }

}
