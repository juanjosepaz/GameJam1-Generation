using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWinGarabato : MonoBehaviour
{
    public GameObject canvasYouWin;
    void Start()
    {
        canvasYouWin.SetActive(false);
    }

    public void YouWin()
    {
        canvasYouWin.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HomeButton()
    {
        SceneManagerObject.Instance.LoadScene(0);
    }
}
