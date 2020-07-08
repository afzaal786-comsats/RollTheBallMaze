using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{

    private BallController bct;
    private static int palindromeLength;
    //String Generation
    private string randomString;
    //String Length
    public int thestringlength;
    //Palindrome Length
    //Colliders
    public Collider[] colliders;
    //Game Object
    public GameObject Cube;
    public GameObject Sphere;
    //Position for Game Object
    public float maxPos = 0f;
    public float minPos = 30f; 

    void Awake()
    {
        bct = GameObject.FindObjectOfType<BallController>();
    }

    //Spawning
    public void spawn()
    {
        List<int> list = new List<int>();
        int randomNumber;

        Text name;
        for (int i = 0; i < palindromeLength; i++)
        {
            randomNumber = Random.Range(0, 9);
            if (!list.Contains(randomNumber) || list.Count == 0)
            {
                list.Add(randomNumber);
            }
            else
            {
                palindromeLength = palindromeLength + 1;
            }
        }


        for (int i = 0; i < 10; i++)
        {
            randomString = "";
            float theXPosition = Random.Range(minPos, maxPos);
            float theZPosition = Random.Range(minPos, maxPos);
            var theNewPos = new Vector3(theXPosition, 0.5f, theZPosition);

            GameObject sphere = Instantiate(Sphere);
            GameObject cube = Instantiate(Cube);
          
            sphere.name = "Sphere" + i;
            cube.name = "Cube" + i;
            sphere.transform.position = new Vector3(theXPosition, 1.0f, theZPosition);
            cube.transform.position = theNewPos;
            name = GameObject.Find("Sphere" + i + "/Canvas/Text").GetComponent<Text>();
            string[] characters = new string[] { "x", "a", "7" };
            thestringlength = Random.Range(9, 15);
            if (list.Contains(i))
            {
                for (int j = 0; j < thestringlength / 2; j++)
                {
                    randomString = randomString + characters[Random.Range(0, characters.Length)];
                }
                randomString = randomString + new string(randomString.Reverse().ToArray());
            }
            else
            {
                for (int j = 0; j < thestringlength; j++)
                {
                    randomString = randomString + characters[Random.Range(0, characters.Length)];
                }
            }
            name.text = randomString;
        }
    }
    public static int getSetValue;
    public static int GetSetValue
    {
        get
        {
            return getSetValue;
        }
        set
        {
            getSetValue = value;
        }

    }

    void Start()
    {

        palindromeLength = Random.Range(3, 10);
        Spawner.GetSetValue = palindromeLength;
        // Debug.Log("Hello: " + palindromeLength);
        bct.UpdatePL(palindromeLength);
        spawn();
    }
}