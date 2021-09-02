using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpUI : MonoBehaviour
{
    public string[] floor;
    public Text floorText;
    public GameObject floorPanel;

    public PlayerInput input;
    public bool isOpen = false;

    public void HelpT() {
        if(!isOpen) {
            floorPanel.SetActive(true);
            int a = (int)SaveManager.instance.save.floor;
            floorText.text = floor[a].Replace("\\n","\n");
            
        }
        else {
            floorPanel.SetActive(false);
        }
        isOpen = !isOpen;
    }
    public void ExitHelp() {
        floorPanel.SetActive(false);
        isOpen = false;
    }

    void Update()
    {
        if(input.isHelp) {
            HelpT();
        }
        
    }
}
