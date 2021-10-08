using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private GameObject _splash;


    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "red")
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            target.gameObject.GetComponent<MeshRenderer>().enabled = true;
            target.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            base.GetComponent<Rigidbody>().AddForce(Vector3.down * 50, ForceMode.Impulse);
            target.gameObject.name = "Is colored by Red";
            Destroy(base.gameObject, .5f);
            print("GameOver");
        }
        else
        {
            base.gameObject.GetComponent<Collider>().enabled = false; // Ball is unvisible

            // Creating and destroying a splash
            GameObject SampleSplash = Instantiate(_splash) as GameObject;
            SampleSplash.transform.parent = target.gameObject.transform;
            Destroy(SampleSplash, 0.1f);

            //Information
            target.gameObject.name = "Is colored by Green";
            target.gameObject.tag = "red";
            StartCoroutine(ChangeColor(target.gameObject));
        }
    }

    IEnumerator ChangeColor(GameObject g)
    {
        yield return new WaitForSeconds(0.1f);
        g.gameObject.GetComponent<MeshRenderer>().enabled = true;
        g.gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
        Destroy(base.gameObject);
    }

}
