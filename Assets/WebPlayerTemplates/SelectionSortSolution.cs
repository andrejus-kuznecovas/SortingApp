using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSortScript : MonoBehaviour
{

    private float updateCount = 0;
    private float fixedUpdateCount = 0;
    private float updateUpdateCountPerSecond;
    private float updateFixedUpdateCountPerSecond;
    private List<int[]> listOfSortingArrays = new List<int[]>();
    private bool userHasMadeError;

    static void Main(string[] args)
    {
        int[] arr = { 23, 16, 4, 15, 8, 42 };
        PrintIntegerArray(numbers);
        PrintIntegerArray(InsertionSort(numbers));
    }

    static void sort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int min_idx = i;
            for (int j = i + 1; j < n; j++)
                if (arr[j] < arr[min_idx])
                    min_idx = j;

            int temp = arr[min_idx];
            arr[min_idx] = arr[i];
            arr[i] = temp;
        }
    }
    static int[] SubSort(int[] inputArray)
    {
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (inputArray[j - 1] > inputArray[j])
                {
                    int temp = inputArray[j - 1];
                    inputArray[j - 1] = inputArray[j];
                    inputArray[j] = temp;
                }
            }
        }
        return inputArray;
    }
    public static void PrintIntegerArray(int[] array)
    {
        foreach (int i in array)
        {
            Console.Write(i.ToString() + "  ");
        }
    }


    public static int[] InsertionSortByShift(int[] inputArray)
    {
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            int j;
            var insertionValue = inputArray[i];
            for (j = i; j > 0; j--)
            {
                if (inputArray[j - 1] > insertionValue)
                {
                    inputArray[j] = inputArray[j - 1];
                }
            }
            inputArray[j] = insertionValue;
        }
        return inputArray;
    }


    // Update is called once per frame
    void Update()
    {
        if (CubesOnGround)
        {
            userHasMadeError = +CheckIfPositionCorrect(listOfSortingArrays);
        }

    }



    static List<int[]> saveArray(int[] arr)
    {
        return this.listOfSortingArrays.Add(arr);
    }


    void Awake()
    {
        //Application.targetFrameRate = 10;
        StartCoroutine(Loop());
    }

    // Increase the number of calls to Update.
    void UpdateCall()
    {
        updateCount += 1;
    }

    // Increase the number of calls to FixedUpdate.
    void FixedUpdate()
    {
        fixedUpdateCount += 1;
    }

    bool CubesOnGround()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 24;
        GUI.Label(new Rect(100, 100, 200, 50), "Update: " + updateUpdateCountPerSecond.ToString(), fontSize);
        if (GUI.Label(new Rect(100, 150, 200, 50), "FixedUpdate: " + updateFixedUpdateCountPerSecond.ToString(),
                fontSize) == null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    // Update both CountsPerSecond values every second.
    IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            updateUpdateCountPerSecond = updateCount;
            updateFixedUpdateCountPerSecond = fixedUpdateCount;

            updateCount = 0;
            fixedUpdateCount = 0;
        }
    }
    bool CheckIfPositionCorrect(List<int[]> sortingArrayOfPlayer)
    {
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}

