using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    private void Start() {
        SoundManager sound =SoundManager.Instance;
        if (sound != null){
            Destroy(sound);
        }
        
    }
    // Start is called before the first frame update
    public void Jugar()
    {
        SceneManagerObject.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
