using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject footstep_outside;
    public GameObject footstep_dungeon;
    public GameObject spellcast_sound;
    

    // Start is called before the first frame update
    void Start()
    {
        footstep_outside.SetActive(false);
        footstep_dungeon.SetActive(false);
        spellcast_sound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            StopFootsteps();
            StopSpellcast();
        }

        if(!PauseMenu.GameIsPaused)
        {
        if(Input.GetKeyDown("w"))
        {
            footsteps();
        }

        if(Input.GetKeyDown("s"))
        {
            footsteps();
        }

        if(Input.GetKeyDown("a"))
        {
            footsteps();
        }

        if(Input.GetKeyDown("d"))
        {
            footsteps();
        }
        if (Input.GetMouseButtonDown(1))
        {
            spellcast1();
        }



        if(Input.GetKeyUp("w"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyUp("s"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyUp("a"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyUp("d"))
        {
            StopFootsteps();
        }
        if(Input.GetMouseButtonUp(1))
        {
            StopSpellcast();
        }

        }
    }

    void footsteps()
    {
        if (GameManager.instance.inDungeon == true)
        {
            
            footstep_dungeon.SetActive(true);
        }
        else
        {
           
           footstep_outside.SetActive(true); 
        }
        
    }

    void spellcast1()
    {
        spellcast_sound.SetActive(true);
    }



    void StopFootsteps()
    {
        footstep_outside.SetActive(false);
        footstep_dungeon.SetActive(false);
    }

    void StopSpellcast()
    {
        spellcast_sound.SetActive(false);
    }
}
