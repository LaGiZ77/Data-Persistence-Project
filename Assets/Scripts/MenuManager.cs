using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour {
    [SerializeField] TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        GameManager.Instance.playerName = nameInput.text;
    }

    public void Play() {
        SceneManager.LoadScene("main");
    }
}
