using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emotes : MonoBehaviour
{
    public Animator animator;
    public audioManager audioManager_;
    public save save;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();
    }
    public void MainDisplayAnimations(int index)
    {
        if (save.gameFile_.emotes[index])
        {
            animator.SetTrigger(""+index);
            Debug.Log("Playing animation number " + index);
        }
        else
        {
            Debug.Log("You have not unlocked this yet.");
            audioManager_.PlayAudio("ErrorSound", 1);
        }
    }
}
