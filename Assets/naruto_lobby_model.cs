using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class naruto_lobby_model : MonoBehaviour
{
    public float nextAnimationTime;
    public AnimationClip[] aniClips;
    public Animator animator;
    public TMP_Text nextAnimationText;
    public TMP_Text newPlayingText;
    public bool pause;

    void Update()
    {
        if (!pause)
        {
            if (nextAnimationTime <= 0)
            {
                int randomAnimationState = Random.Range(0, aniClips.Length);

                newPlayingText.text = "Now playing Pose " + randomAnimationState;

                if (animator.GetBool("Pose " + randomAnimationState) != true)
                {
                    animator.SetBool("Pose " + randomAnimationState, true);
                }
                else
                {
                    animator.SetBool("Pose " + randomAnimationState, false);
                }

                nextAnimationTime = 5;
            }
            else
            {
                nextAnimationTime -= Time.deltaTime;
                nextAnimationText.text = "Next animation in " + nextAnimationTime;
            }
        }
    } 
}
