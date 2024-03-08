using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private int mainSceneIndex;
    [SerializeField] private CanvasGroup backgroundCanvasGroup;
    [SerializeField] private CanvasGroup gameOverMenuItemsCanvasGroup;
    [SerializeField] private LeanTweenType gameOverMenuEaseType;
    [SerializeField] private float timeToSetBackground;
    [SerializeField] private float timeToSetItems;
    [SerializeField] private float timeBtwnTransitions;

    /*
    Test Input
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnableGameOverMenu();
        }
    }
    */

    public void EnableGameOverMenu()
    {
        StartCoroutine(EnableGameOverMenuRoutine());
    }

    private IEnumerator EnableGameOverMenuRoutine()
    {
        LeanTween.alphaCanvas(backgroundCanvasGroup, 1f, timeToSetBackground).setEase(gameOverMenuEaseType);

        yield return new WaitForSeconds(timeBtwnTransitions);

        LeanTween.alphaCanvas(gameOverMenuItemsCanvasGroup, 1f, timeToSetItems).setEase(gameOverMenuEaseType);

        CanvasGroupBlockRaycast(backgroundCanvasGroup);

        CanvasGroupBlockRaycast(gameOverMenuItemsCanvasGroup);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReplayButton()
    {
        SceneManagerObject.Instance.ReloadScene();
    }

    public void HomeButton()
    {
        SceneManagerObject.Instance.LoadScene(mainSceneIndex);
    }

    private void CanvasGroupBlockRaycast(CanvasGroup canvasGroup)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }
}
