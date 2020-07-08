using System.Collections;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;
using System.Linq;


public class BallController : MonoBehaviour
{
    public int PLe;
    public float speed;
    private Rigidbody rb;
    public int count;
    public GameObject sphere;
    public string String;

    public Text countText;
    public Text palindromeText;
    public Text winText;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        
        setCountText ();
        setCountPalindrmeText ();
        winText.text = "";
    }

    //FixedUpdate run once, zero, or several times per frame,
    //depending on how many physics frames per second 
    //and how fast/slow the framerate.
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, movevertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        Text name;
        if (other.gameObject.CompareTag("spawner"))
        {

            String = Regex.Match(other.gameObject.name, @"\d+").Value;
            sphere = GameObject.Find("Sphere" + Int32.Parse(String));
            name = GameObject.Find("Sphere" + Int32.Parse(String) + "/Canvas/Text").GetComponent<Text>();
           
             var r = new string(name.text.Reverse().ToArray());
             var o = new string(name.text.ToArray());
            
            if (r == o)
            {
                other.gameObject.SetActive(false);
                sphere.gameObject.SetActive(false);
                count = count + 1;
                setCountText ();
                
            }
           
        }
    }

    public void UpdatePL (int PL)
    {
        //WIN
        PLe = PL;
        Debug.Log("PLalidome number" + PLe);
    }

    void setCountText ()
    {
        countText.text = "Palindrome Picked: " + count.ToString();
        if (count == PLe)
        {
             
            winText.text = "All Palindrome Picked: " + PLe.ToString();
        }
    }
    void setCountPalindrmeText()
    {
        palindromeText.text = "Palindrome Generated: " + PLe.ToString();
    }
}