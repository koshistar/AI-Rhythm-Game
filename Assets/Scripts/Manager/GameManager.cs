using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller beatScroller;
    public static GameManager instance;

    private int currentScore;
    public int scorePerNote = 1;
    public int scorePerGoodNote = 2;
    public int scorePerPerfectNote = 3;
    private int comboNum = 0;
    public Text scoreText;
    public Text comboText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        comboNum = 0;
        comboText.text = "Combo: 0";
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;
                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        // currentScore += scorePreNote;
        comboNum++;
        Debug.Log("Hit On Time");
        scoreText.text = "Score: " + currentScore;
        comboText.text = "Combo: " + comboNum;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote;
        NoteHit();
    }
    public void NoteMissed()
    {
        comboNum = 0;
        Debug.Log("Missed Note");
        comboText.text = "Combo: " + comboNum;
    }
}
