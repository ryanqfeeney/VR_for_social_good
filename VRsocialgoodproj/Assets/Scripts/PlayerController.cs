using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Data data = new Data();
    public Camera cam;
    //player statistics
    public Text textCal;
    public Text textSCarb;
    public Text textCCarb;
    public Text textBloodSugar;
    

    public Text textClock;
    public Text textPoint;

    public Text textFoodName;
    public Text textCaloriesRight;
    public Text textSimpleCarbsRight;
    public Text textComplexCarbsRight;

    public int timeScale = 5;

    public int playerSpeed = 3;

    public double simpleRate = 7;  // conversion rate of simple carbs to blood sugar per in game minute. 
    public double complexRate = 1; // conversion rate of complex carbs to blood sugar per in game minute. 
    public double carbsToBloodSugar = 3.0; //how much does your blood sugar go up for every carb you process. (same for simple and complex) 
    public double calorieRate = 2000 / 24 / 60; // calories burned per minute on 2000 calorie diet. 


    [HideInInspector]
    public double simpleCarbs ;
    [HideInInspector]
    public double complexCarbs;
    [HideInInspector]
    public double totalCalories ;
    [HideInInspector]
    public double bloodSugar ;

    public float rayDistance = .8f;

    private System.DateTime clock = new System.DateTime(2019, 3, 26, 10, 30, 00);





    void Start()
    {
        InvokeRepeating("convertSimpleToBloodSugar", 60.0f / timeScale, 60.0f / timeScale);
        InvokeRepeating("convertComplexToBloodSugar", 60.0f / timeScale, 60.0f / timeScale);
        InvokeRepeating("burnCalories", 60.0f / timeScale, 60.0f / timeScale);
        textPoint.text = "";
	LoadPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance) && data.getSCarbs(hit.collider.tag) != -1)
        {
            string tag = hit.collider.tag;
            Food food = data.getFood(tag);
            textPoint.text = food.name;
            textFoodName.text = food.name;
            textCaloriesRight.text = food.calories.ToString();
            textSimpleCarbsRight.text = food.simpleCarbs.ToString();
            textComplexCarbsRight.text = food.complexCarbs.ToString();
            if (Input.GetMouseButtonDown(0))
            {

                addItemToPlayerStats(tag);
                textFoodName.text = food.name;
            }

        }
        else
        {
            textPoint.text = "";
            textFoodName.text = "Food";
            textCaloriesRight.text = "0";
            textSimpleCarbsRight.text = "0";
            textComplexCarbsRight.text = "0";
        }
        if (Input.GetButton("Fire1") && (textPoint.text.CompareTo("") == 0))
        {
            Vector3 naturalForward = Camera.main.transform.forward;
            naturalForward.y = 0;

            transform.position = transform.position + naturalForward.normalized * playerSpeed * Time.deltaTime;
        }




        textCal.text = Mathf.RoundToInt((float)totalCalories).ToString();
        textSCarb.text = Mathf.RoundToInt((float)simpleCarbs).ToString();
        textCCarb.text = Mathf.RoundToInt((float)complexCarbs).ToString();
        textBloodSugar.text = Mathf.RoundToInt((float)bloodSugar).ToString();
        textClock.text = clock.ToShortTimeString();


        clock = clock.AddSeconds(timeScale * Time.deltaTime);

    }
    void OnMouseDown()
    {


    }

    public void addItemToPlayerStats(string food)
    {
        totalCalories += data.getFood(food).calories;
        simpleCarbs += data.getFood(food).simpleCarbs;
        complexCarbs += data.getFood(food).complexCarbs;
    }

    public void useInsulin(int ins)
    {
        bloodSugar -= ins;
    }
    public void convertSimpleToBloodSugar()
    {
        if (simpleCarbs > simpleRate)
        {
            bloodSugar += simpleRate * carbsToBloodSugar;
            simpleCarbs -= simpleRate;
        }
        else if (simpleCarbs > 0)
        {
            bloodSugar += simpleCarbs * carbsToBloodSugar;
            simpleCarbs = 0;
        }
    }
    public void convertComplexToBloodSugar()
    {
        if (complexCarbs > complexRate)
        {
            bloodSugar += complexRate * carbsToBloodSugar;
            complexCarbs -= complexRate;
        }
        else if (complexCarbs > 0)
        {
            bloodSugar += complexCarbs * carbsToBloodSugar;
            complexCarbs = 0;
        }
    }
    public void burnCalories()
    {
        if (totalCalories > calorieRate)
        {
            totalCalories -= calorieRate;
        }
        else if (totalCalories > 0)
        {
            totalCalories = 0;
        }
    }
 public void SavePlayer()
    {
       DontDestroy.Instance.bloodSugar = bloodSugar;
 	DontDestroy.Instance.complexCarbs = complexCarbs;
 	DontDestroy.Instance.simpleCarbs = simpleCarbs;
 	DontDestroy.Instance.calories = totalCalories;
	DontDestroy.Instance.clock = clock;
    }
 public void LoadPlayer()
    {
       bloodSugar = DontDestroy.Instance.bloodSugar ;
 	complexCarbs = DontDestroy.Instance.complexCarbs ;
 	simpleCarbs = DontDestroy.Instance.simpleCarbs ;
 	totalCalories = DontDestroy.Instance.calories;
	clock= DontDestroy.Instance.clock;
    }

}
