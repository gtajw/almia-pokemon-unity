using System.Collections;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;


    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
    }

    public IEnumerator SetHPSmooth(float newHp)
    {
        float curHp = health.transform.transform.localScale.x;
        float changeAmt = curHp - newHp;

        while (curHp - newHp > Mathf.Epsilon)
        {
            curHp -= changeAmt * Time.deltaTime;
            health.transform.localScale = new Vector3(curHp, 1f);
            yield return null;
        }
        health.transform.localScale = new Vector3(newHp, 1f);
    }
    public IEnumerator ColorHP()
    {
        float curHP = health.transform.localScale.x;

        Image img = health.GetComponent<Image>();

        if (img != null)
        {
            if (curHP <= 0.2f)
            {
                img.color = Color.red;
            }
            else if (curHP <= 0.5f)
            {
                img.color = Color.yellow;
            }
            else
            {
                img.color = Color.green;
            }
        }
        else
        {
            Debug.LogWarning("No Image component found on the health GameObject!");
            yield return null;
        }
    }
}
