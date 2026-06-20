using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillMinigame : MonoBehaviour
{

    [SerializeField] public GameObject meter;
    [SerializeField] public GameObject movingBox;
    [SerializeField] public GameObject targetBox;
    [SerializeField] public int hitBox;
    [SerializeField] public int meterMax = 300;
    public int meterAmt;
    [SerializeField] public int meterFill;
    [SerializeField] public int meterLoss;

    private bool SpacePressed;

    // Start is called before the first frame update
    void Start()
    {
        //meterAmt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.InputListen();
        this.CheckHit();
    }

    private void updateMeter()
    {

        RectTransform rt = meter.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(meterAmt, rt.sizeDelta.y);

    }

    private void InputListen()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Space pressed");

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space released, box at " + movingBox.transform.position.x + " | Target box at " + targetBox.transform.position.x);
            SpacePressed = true;
        }
    }

    private void CheckHit()
    {

        if (SpacePressed)
        {

            if (movingBox.transform.position.x < (targetBox.transform.position.x + hitBox) && movingBox.transform.position.x > (targetBox.transform.position.x - hitBox))
            {

                Debug.Log("Meter filling");
                meterAmt += meterFill;

                if (meterAmt > meterMax)
                {

                    meterAmt = meterMax;

                }

            }
            else
            {

                meterAmt -= meterFill;

                if (meterAmt < 0) {
                
                    meterAmt = 0;
                    
                }

            }

            updateMeter();
            Debug.Log("Meter at " + meterAmt);
            SpacePressed = false;

        }

    }


}