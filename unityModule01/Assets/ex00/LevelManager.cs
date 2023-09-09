using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] exits;
    public CameraFollow cameraFollow;
    public bool allExitsActive = false;
    private int activeCharacterIndex = 0;
    

    private void Start()
    {
        // Inizialmente, nessun personaggio è attivo, ma sono tutti renderizzati
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].GetComponent<CharacterMovement>().isControlEnabled = false;
            characters[i].GetComponent<Renderer>().enabled = true;
        }
        // Inizializza cameraFollow con il componente CameraFollow
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        cameraFollow.target = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchCharacter(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchCharacter(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SwitchCharacter(2);
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
            ResetScene();
        Debug.Log("CheckExits: " + allExitsActive);
        if (CheckExits())
            Debug.Log("Level Complete!");
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
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // controlla se tutte le exits sono attive
    private bool CheckExits()
    {
        for (int i = 0; i < exits.Length; i++)
        {
            if (exits[i].GetComponent<Exits>().isActive)
                allExitsActive = true;
            else
            {
                allExitsActive = false;
                break;
            }
        }
        return allExitsActive;
    }
}
