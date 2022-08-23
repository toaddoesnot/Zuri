using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerAnim : MonoBehaviour
{
    public Animation anim;

    public bool oneCardAnim;
    public bool twoCardAnim;
    public bool noCardAnim;

    public ArgumentSlot bubbleSc;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.Play("partnerTest");
    }

    private void Update()
    {
        
    }

    void StandardAnimation()
    {
        anim.CrossFade("partnerTest");

        oneCardAnim = false;
        twoCardAnim = false;
        noCardAnim = false;
        return;
    }

    public void ChangeAnimation()
    {
        if (oneCardAnim)
        {
            anim.CrossFade("partnerBrushOff");
        
        Invoke("StandardAnimation", 2.4f);
        }
        else
        {
            if (twoCardAnim)
            {
                anim.CrossFade("partnerApproval");
           
            Invoke("StandardAnimation", 2.1f);
        }
            else
            {
                if (noCardAnim)
                {
                    anim.CrossFade("partnerShrug");
                
                Invoke("StandardAnimation", 3.1f);
            }
            }
        }
    }

}
