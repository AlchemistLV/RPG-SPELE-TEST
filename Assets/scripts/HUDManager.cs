using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour {

    public Combat player;
    public LevelSystem level;
    public SpecialAttacks spAttack1;
    public SpecialAttacks spAttack2;

    public Texture2D healthFrame;
    public Rect healthFramePos;

    public Texture2D healthBar;
    public Rect healthBarPos;

    public Texture2D expFrame;
    public Rect expFramePos;

    public Texture2D expBar;
    public Rect expBarPos;

    public Texture2D specAttack1;
    public Rect specAttack1Pos;

    public Texture2D specAttack2;
    public Rect specAttack2Pos;

    public Rect cooldownPos1;
    public Rect cooldownPos2;
    public GUIStyle cdStyle;

    public Rect levelPos;
    public GUIStyle levelStyle;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        healthFramePos.x = 0.05f * Screen.width;
        healthFramePos.y = 0.05f * Screen.height;
        healthFramePos.width = 0.3f * Screen.width;
        healthFramePos.height = 0.05f * Screen.height;

        healthBarPos.x = 0.058f * Screen.width; 
        healthBarPos.y = 0.058f * Screen.height;
        healthBarPos.width = 0.286f * Screen.width * player.health / player.maxHealth;
        healthBarPos.height = 0.034f * Screen.height;

        expFramePos.x = 0.05f * Screen.width;
        expFramePos.y = 0.1f * Screen.height;
        expFramePos.width = 0.3f * Screen.width;
        expFramePos.height = 0.02f * Screen.height;

        expBarPos.x = 0.058f * Screen.width;
        expBarPos.y = 0.104f * Screen.height;
        expBarPos.width = 0.286f * Screen.width * level.exp / 100;
        expBarPos.height = 0.011f * Screen.height;

        specAttack1Pos.width = 0.1f * Screen.height;
        specAttack1Pos.height = 0.12f * Screen.height;
        specAttack1Pos.x = (Screen.width - specAttack1Pos.width) / 2 - 0.05f * Screen.width;
        specAttack1Pos.y = 0.85f * Screen.height;

        specAttack2Pos.width = 0.1f * Screen.height;
        specAttack2Pos.height = 0.12f * Screen.height;
        specAttack2Pos.x = (Screen.width - specAttack1Pos.width) / 2 + 0.05f * Screen.width;
        specAttack2Pos.y = 0.85f * Screen.height;

        cooldownPos1.width = 0.1f * Screen.height;
        cooldownPos1.height = 0.12f * Screen.height;
        cooldownPos1.x = (Screen.width - specAttack1Pos.width) / 2 - 0.047f * Screen.width;
        cooldownPos1.y = 0.85f * Screen.height;

        cooldownPos2.width = 0.1f * Screen.height;
        cooldownPos2.height = 0.12f * Screen.height;
        cooldownPos2.x = (Screen.width - specAttack1Pos.width) / 2 + 0.053f * Screen.width;
        cooldownPos2.y = 0.85f * Screen.height;

        levelPos.width = 0.1f * Screen.height;
        levelPos.height = 0.12f * Screen.height;
        levelPos.x = 0.05f * Screen.width;
        levelPos.y = 0.15f * Screen.height;

        cdStyle.fontSize = (int)(0.05f * Screen.height);
        levelStyle.fontSize = (int)(0.1f * Screen.height);

        GUI.DrawTexture(healthFramePos, healthFrame);
        GUI.DrawTexture(healthBarPos, healthBar);
        GUI.DrawTexture(expFramePos, expFrame);
        GUI.DrawTexture(expBarPos, expBar);
        GUI.DrawTexture(specAttack1Pos, specAttack1);
        GUI.DrawTexture(specAttack2Pos, specAttack2);
        GUI.Label(cooldownPos1, ((int)spAttack1.cooldownTime).ToString(), cdStyle);
        GUI.Label(cooldownPos2, ((int)spAttack2.cooldownTime).ToString(), cdStyle);
        GUI.Label(levelPos, "Level " + (level.level).ToString(), levelStyle);
    }
}
