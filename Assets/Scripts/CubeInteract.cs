using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteract : MonoBehaviour
{
    [Header("Cube Rotation")]
    public float rotSpeed = 0;

    public Quaternion cubeQuat0; //Starting face of the cube showing
    public Quaternion cubeQuat1; //Second face of the cube showing when first clicked
    public Quaternion cubeQuat2; 
    public Quaternion cubeQuat3;
    public Quaternion cubeQuat4;

    public bool rotateCube;
    public int cubeCurrentSide;

    public bool correctCube;
    public int correctCubes = 0;

    [Header("Cube Images")]

    public int correctSpriteSide;
    public Sprite[] cubeSides;
    public SpriteRenderer[] cubeSpriteRends;

    void Start()
    {
        correctCubes = 0;

        //Rotation stuff
        transform.rotation = cubeQuat0;
        cubeCurrentSide = 0;

        //Sprite stuff
        cubeSpriteRends = GetComponentsInChildren<SpriteRenderer>();
        cubeSpriteRends[0].sprite = cubeSides[0];
        cubeSpriteRends[1].sprite = cubeSides[1];
        cubeSpriteRends[2].sprite = cubeSides[2];
        cubeSpriteRends[3].sprite = cubeSides[3];

    }

    private void Update()
    {
        //Rotate cube is triggered true using CubeClicker Script
        if (rotateCube)
        {
            if (cubeCurrentSide == 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, cubeQuat1, rotSpeed * Time.deltaTime);
                if(transform.rotation == cubeQuat1)
                    {
                    cubeCurrentSide = 1;
                    rotateCube = false;
                    }
            }

            else if (cubeCurrentSide == 1)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, cubeQuat2, rotSpeed * Time.deltaTime);
                if (transform.rotation == cubeQuat2)
                {
                    cubeCurrentSide = 2;
                    rotateCube = false;
                }
            }

            else if (cubeCurrentSide == 2)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, cubeQuat3, rotSpeed * Time.deltaTime);
                if (transform.rotation == cubeQuat3)
                {
                    cubeCurrentSide = 3;
                    rotateCube = false;
                }
            }

            else if (cubeCurrentSide == 3)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, cubeQuat4, rotSpeed * Time.deltaTime);
                if (transform.rotation == cubeQuat4)
                {
                    transform.rotation = cubeQuat0;
                    cubeCurrentSide = 0;
                    rotateCube = false;
                }
            }
        }

        if (cubeCurrentSide == correctSpriteSide)
        {
            correctCube = true;
        }
        else
            correctCube = false;
        
    }


}
