using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpriteAnimation : MonoBehaviour
{
    //this is called an array of sprites. its a way of containing multiple values or objects in one variable.
    //in this case we will use it to hold sprites that hold multiple frames of animation
    //we won't be discussing arrays in class, look them up later ;)
    public Sprite[] frames;

    public int framesPerSecond = 12;

    SpriteRenderer sRenderer;

    public bool loop = true;
    public bool destroyWhenDone = false;


    //how long has the current frame been displayed
    float timer = 0;

    //current frame
    int frame = 0;

    // Start is called before the first frame update
    void Start()
	{
		sRenderer = GetComponent<SpriteRenderer>();


		SetSpriteRendererToCurrentFrame();
	}


	// Update is called once per frame
	void Update()
    {


        //advance the timer based on how much time has passed since last update
        timer += Time.deltaTime;


        //if zero frames per second, don't continue (return means to stop the function here)
        //we aren't allowed to divide by zero!
        if (framesPerSecond == 0) return;

        //calculate how long each frame should last in seconds
        float timePerFrame = 1f / (float)framesPerSecond;

   

        //check if we should reset the timer
        if (timer >= timePerFrame )
		{
            timer = 0;

            //jump to the next frame
            frame++;

            //check if we have reached the end of the animation
            if(frame>=frames.Length)
			{
                //if it should loop, set frame to 0 (0 is the first frame)
                if (loop)
                    frame = 0;  
                else
                {
                    //otherwise, keep frame within bounds of the array of frames
                    frame = frames.Length - 1;

                    //if it should destroy when done, do it here
                    if (destroyWhenDone == true)
                        Destroy(gameObject);
                }
			}

            SetSpriteRendererToCurrentFrame();
		}

    }

    void SetSpriteRendererToCurrentFrame()
	{
        sRenderer.sprite = frames[frame];
	}
}
