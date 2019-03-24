using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimateFrames : MonoBehaviour {

    public List<Sprite> frames = new List<Sprite>();
    public float timeBetweenFrames = 1.0f;
    private float time = 0.0f;
    private int frameCounter = 0;
    private SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeBetweenFrames)
        {
            if (frameCounter < frames.Count - 1)
            {
                frameCounter += 1;
            }
            else
            {
                frameCounter = 0;
            }
            rend.sprite = frames[frameCounter];
            time = 0;
        }

    }
}
