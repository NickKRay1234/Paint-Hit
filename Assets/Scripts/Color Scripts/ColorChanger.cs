using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ColorChanger workes with colliders and collisions. It change color in our cilinder(GREEN, RED)
 * Script created by @Mykola Kalchuk.
 */

[RequireComponent(typeof(SphereCollider))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private GameObject _splash;

    public void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.GetComponent<MeshRenderer>().enabled) // GameOver
        {
            base.gameObject.GetComponent<Collider>().enabled = false; // Ball is unvisible; 
            StartCoroutine(ChangeColor(target.gameObject, Color.red));
            base.GetComponent<Rigidbody>().AddForce(Vector3.down * 50, ForceMode.Impulse); // Ball movement after target hiting;
            //target.gameObject.name = "Is colored by Red";


            Destroy(base.gameObject, .5f);
        }
        else
        {
            base.gameObject.GetComponent<Collider>().enabled = false; // Ball is unvisible;

            // Creating and destroying a splash
            GameObject SampleSplash = Instantiate(_splash) as GameObject;
            SampleSplash.transform.parent = target.gameObject.transform;
            //target.gameObject.name = "Is colored by Green";
            Destroy(SampleSplash, 0.1f);
            

            StartCoroutine(ChangeColor(target.gameObject, Color.green));
            
        }
    }

    IEnumerator ChangeColor(GameObject target, Color color)
    {
        yield return new WaitForSeconds(0.1f);
        target.gameObject.GetComponent<MeshRenderer>().enabled = true;
        target.gameObject.GetComponent<MeshRenderer>().material.color = color;
        Destroy(base.gameObject); // Ball is destroyed;
    }

}
