using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DoorTransfer : MonoBehaviour
{
    [SerializeField] private GameObject otherDoor;
    public bool hasTrans=false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTrans&&other.gameObject.tag == "Player")
        {
            Debug.Log("transpot");
            DoorSkillController parentCot=GetComponentInParent<DoorSkillController>();
            DoorTransfer otherTrans = otherDoor.GetComponent<DoorTransfer>();
            otherTrans.hasTrans = true;
            hasTrans = true;


            other.transform.position=otherDoor.transform.position;


            parentCot.DoorClose();
        }
    }
    
}
