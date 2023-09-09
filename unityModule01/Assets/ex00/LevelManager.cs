using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] characters; // Un array contenente i personaggi.
    public CameraFollow cameraFollow;
    private int activeCharacterIndex = 0; // Indice del personaggio attivo.
    

    private void Start()
    {
        // Inizialmente, nessun personaggio è attivo, ma sono tutti renderizzati.
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].GetComponent<CharacterMovement>().isControlEnabled = false;
            characters[i].GetComponent<Renderer>().enabled = true;
        }
                // Inizializza cameraFollow con il componente CameraFollow
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        // Imposta il personaggio attivo iniziale come target della camera
        cameraFollow.target = null;
    }

    private void Update()
    {
        // Controlla l'input dei tasti alfanumerici
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCharacter(0); // Cambia il controllo al personaggio 1
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCharacter(1); // Cambia il controllo al personaggio 2
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchCharacter(2); // Cambia il controllo al personaggio 3
        }

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetScene();
        }
    }

    private void SwitchCharacter(int characterIndex)
    {
        characters[activeCharacterIndex].GetComponent<CharacterMovement>().isControlEnabled = false;
        characters[characterIndex].GetComponent<CharacterMovement>().isControlEnabled = true;
        activeCharacterIndex = characterIndex;
        cameraFollow.target = characters[characterIndex].transform;
    }

    private void ResetScene()
    {
        // Reload the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
