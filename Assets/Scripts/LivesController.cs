using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesController : MonoBehaviour
{
    public TMP_Text livesTxt;

    private void Start() {
        livesTxt = FindFirstObjectByType<TMP_Text>();

        UpdateLives();
    }
    
    public void UpdateLives(){
        livesTxt.SetText($"Lives: {GameManager.instance.lives}");
    }
}
