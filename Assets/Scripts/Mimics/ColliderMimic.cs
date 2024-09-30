using UnityEngine;
using UnityEngine.Rendering;

public class ColliderMimic : MonoBehaviour
{
    [Header("References")]
    MimicsController mc;

    [Header("Seconds")]
    bool min, med, max = false;

    private void Awake()
    {
        mc = gameObject.GetComponentInParent<MimicsController>();
    }

    private void OnTriggerEnter(Collider p)
    {
        if (p.transform.name == "PlayerObj")
        {
            if (gameObject.name == "MinAtk")
            {
                if (mc.seconds >= 3)
                    mc.seconds = 3;
                Debug.Log("In min");
            }
            else if (gameObject.name == "MedAtk")
            {
                if (mc.seconds >= 7)
                    mc.seconds = 5;
                Debug.Log("In Med");
            }
            else if (gameObject.name == "MaxAtk")
            {               
                    mc.seconds = 7;
                Debug.Log("In Max");
            }
        }
    }

    private void OnTriggerStay(Collider p)
    {
        if (p.transform.name == "PlayerObj")
        {
            if (gameObject.name == "MinAtk")
            {
                min = true;
            }
            else if (gameObject.name == "MedAtk")
            {
                med = true;
            }
            else
            {
                max = true;
            }
        }
    }

    private void OnTriggerExit(Collider p)
    {
        if (p.transform.name == "PlayerObj")
        {
            if (gameObject.name == "MinAtk")
            {
                min = false;
            }
            else if (gameObject.name == "MedAtk")
            {
                med = false;
            }
            else
            {
                max = false;
                mc.seconds = 0;
            }
        }
    }

    private void Update()
    {
        if (min || med || max)
        {
            mc.seconds -= Time.deltaTime;
        }

        if (mc.seconds <= 0 && min)
        {
            mc.damage = 10;
            mc.Attack();
        }
        else if ((mc.seconds <= 0 && med))
        {
            mc.damage = 7;
            mc.Attack();
        }
        else if (mc.seconds <= 0 && max == true)
        {
            mc.damage = 5;
            mc.Attack();
            Debug.Log(mc.damage);
        }
    }
}
