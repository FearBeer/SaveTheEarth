using UnityEngine;
using UnityEngine.Events;

public class BeginSlider : MonoBehaviour
{
    private GameObject[] slides;
    private GameObject backButton;
    private GameObject nextButton;
    public UnityEvent<int> OnClickButton;
    private int currentIndex = 0;
    void Start()
    {
        slides = GameObject.FindGameObjectsWithTag("BeginSlide");
        backButton = GameObject.FindGameObjectWithTag("BackButton");
        nextButton = GameObject.FindGameObjectWithTag("NextButton");
        backButton.SetActive(false);

        for (int i = 1; i < slides.Length; i++)
        {
            slides[i].SetActive(false);
        }
        OnClickButton.AddListener((index) =>
        {
            for (int i = 0; i < slides.Length; i++)
            {
                slides[i].SetActive(false);
                if(i == index)
                {
                    slides[i].SetActive(true);
                }
            }
            if (index == 0)
            {
                backButton.SetActive(false);
                nextButton.SetActive(true);
            }
            if (index > 0)
            {
                backButton.SetActive(true);
                nextButton.SetActive(true);
            }
            if (index == slides.Length - 1)
            {
                nextButton.SetActive(false);
            }
        });        
    }

    public void ToNextSlide()
    {
        currentIndex++;
        if(currentIndex >= slides.Length)
        {
            currentIndex = 0;
        }        
        OnClickButton.Invoke(currentIndex);
    }

    public void ToPreviousSlide()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = slides.Length - 1;
        }
        OnClickButton.Invoke(currentIndex);
    }
}
