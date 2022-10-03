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
    public bool IAmFemale;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.Play("partnerTest");
        if (IAmFemale)
        {
            anim.Play("partnerTestFem");
        }
    }

    private void Update()
    {
        
    }

    void StandardAnimation()
    {
        anim.CrossFade("partnerTest");
        if (IAmFemale)
        {
            anim.CrossFade("partnerTestFem");
        }
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
            if (IAmFemale)
            {
                anim.CrossFade("partnerBrushOffFem");
            }
            Invoke("StandardAnimation", 2.4f);
        }
        else
        {
            if (twoCardAnim)
            {
                anim.CrossFade("partnerApproval");
                if (IAmFemale)
                {
                    anim.CrossFade("partnerApprovalFem");
                }
                Invoke("StandardAnimation", 2.1f);
        }
            else
            {
                if (noCardAnim)
                {
                    anim.CrossFade("partnerShrug");
                    if (IAmFemale)
                    {
                        anim.CrossFade("partnerShrugFem");
                    }
                    Invoke("StandardAnimation", 3.1f);
            }
            }
        }
    }

}
