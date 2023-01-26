using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject poison, illusion, agony;
    private float launchVelocity = 500f;
    private static bool bot1, bot2, bot3;

    // Update is called once per frame
    void Update()
    {
        if(bot1){
            GameObject ball = Instantiate(poison, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, launchVelocity,0));    
            bot1 = false;
        }
        if(bot2){
            GameObject ball = Instantiate(illusion, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, launchVelocity,0));    
            bot2 = false;
        }
        if(bot3){
            GameObject ball = Instantiate(agony, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, launchVelocity,0));    
            bot3 = false;
        }
        
    }

    public static void FlaskOfPoison(){
        bot1 = true;
    }
    public static void FlaskOfIllusion(){
        bot2 = true;
    }
    public static void FlaskOfAgony(){
        bot3 = true;

    }


}
