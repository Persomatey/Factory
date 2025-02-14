﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DefaultPlayer : Player
{
    public Transform shotSpawn;
    public GameObject loseSFX; 

    SubMachineGun rangedAttack;


    public DefaultPlayer(string newPlayerName, string newPlayerClass, Rigidbody2D newPlayerRB2D, bool newIsMelee, int newPlayerLevel, int newHealth, float newSpeed, int newExperience, Animator newAnim) : base(newPlayerName, newPlayerClass, newPlayerRB2D, newIsMelee, newPlayerLevel, newHealth, newSpeed, newExperience, newAnim)
    {

    }

    /// <summary>
    /// Start will override Player Start(), which only contains call to default constructor. LoadData() will eventually load from file
    /// but for now just sets values of this Player
    /// </summary>
    void Start()
    {
        LoadDate();
        Debug.Log("Name: " + playerName + " " + " Class: " + playerClass + " Level: " + playerLevel + " Health: " + health
        + " Melee: " + isMelee + " Speed: " + speed + "  Exp: " + experience + "\n" + "has been created");
    }

    void LateUpdate()
    {
        rangedAttack.LateUpdate();
        if(health <= 0)
        {
            StartCoroutine(DeathSequence()); 
        }
    }

    IEnumerator DeathSequence()
    {
        loseSFX.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("HunterDeathScene");
    }

    void LoadDate()
    {
        DefaultSettings();
        this.playerName     = "Default";
        this.playerClass    = "Default";
        this.PlayerRB2D     = GetComponent<Rigidbody2D>();
        this.isMelee        = true;
        this.playerLevel    = 1;
        this.health         = 100;//making the game a little easier
        this.BASE_HEALTH    = health;
        this.speed          = 100f;
        this.experience     = 0;
        this.anim           = GetComponent<Animator>();
        this.alive          = true;

        this.rangedAttack   = new SubMachineGun(gameObject);
    }

    public override void InputControls()
    {
        base.InputControls();

        if (Input.GetMouseButtonDown(0))
        {
            rangedAttack.Attack(shotSpawn);
        }
        if (Input.GetMouseButton(0))
        {
            rangedAttack.AttackHold(shotSpawn);
        }
        if (Input.GetMouseButtonUp(0))
        {
            rangedAttack.AttackRelease(shotSpawn);
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("MeleeAttack");
        }

        //goig to change this from mouse button 2 to the keyboard key R
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            rangedAttack.Reload();
        }
		//if(Input.GetKeyDown

    }

    public override void GiveAmmo(int value)
    {
        if(alive)
        this.rangedAttack.AddAmmo();
    }

    public override string getHUDString()
    {
        return string.Format("Ammo: \n{0}/{1} \n", rangedAttack.getCurrentMagazine(), rangedAttack.getAmmoCount());
    }
}
