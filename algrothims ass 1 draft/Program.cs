

using System;
using System.IO;
using System.Reflection.Metadata;

namespace ArraySortingAndSearching
{
    class Program
    {
        // bubble sort implementation
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        static void BubbleSortDescending(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            static void ReadFilesIntoArrays(out int[] road1, out int[] road2, out int[] road3)
            {
                // Initialize arrays with length 256
                road1 = new int[256];
                road2 = new int[256];
                road3 = new int[256];

                // Read file Road_1_256.txt into road1 array
                string[] lines = File.ReadAllLines("Road_1_256.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    road1[i] = int.Parse(lines[i]);
                }

                // Read file Road_2_256.txt into road2 array
                lines = File.ReadAllLines("Road_2_256.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    road2[i] = int.Parse(lines[i]);
                }

                // Read file Road_3_256.txt into road3 array
                lines = File.ReadAllLines("Road_3_256.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    road3[i] = int.Parse(lines[i]);
                }
            }

            static void Main(string[] args)
            {


                // Read files into individual arrays
                ReadFilesIntoArrays("Road_1_256.txt", out int[] road1);
                ReadFilesIntoArrays("Road_2_256.txt", out int[] road2);
                ReadFilesIntoArrays("Road_3_256.txt", out int[] road3);

                Console.WriteLine("Arrays read successfully.");

                // Sort arrays in ascending and descending order using bubble sort
                BubbleSort(road1);
                BubbleSort(road2);
                BubbleSort(road3);

                Console.WriteLine("Arrays sorted in ascending order.");

                BubbleSortDescending(road1);
                BubbleSortDescending(road2);
                BubbleSortDescending(road3);

                Console.WriteLine("Arrays sorted in descending order.");

                // Display every 10th value of the selected array(s)
                static int GetTenthValue(int[] road1)
                {
                    if (road1.Length >= 10)
                    {
                        return road1[9];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("The array must have at least 10 elements.");
                    }
                }
                int tenthValue = GetTenthValue(road1);
                Console.WriteLine("The tenth value in the array1 is: " + tenthValue);

                //displays tenth value for array 2 
                static int GetTenthValue2(int[] road2)
                {
                    if (road2.Length >= 10)
                    {
                        return road2[9];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("The array must have at least 10 elements.");
                    }
                }
                int tenthValue2 = GetTenthValue2(road2);
                Console.WriteLine("The tenth value in the array2  is: " + tenthValue2);

                // Displays the tenth value for array 3 
                static int GetTenthValue3(int[] road3)
                {
                    if (road3.Length >= 10)
                    {
                        return road3[9];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("The array must have at least 10 elements.");
                    }
                }
                int tenthValue3 = GetTenthValue3(road3);
                Console.WriteLine("The tenth value in the array 3 is: " + tenthValue3);

                // Search the selected array for a user-defined value
                Console.WriteLine("Enter a value to search for in Road 1 array:");
                int searchValue = int.Parse(Console.ReadLine());

                Console.WriteLine("Choose a search method:");
                Console.WriteLine("1. Binary search");
                Console.WriteLine("2. Linear search");
                int searchMethod = int.Parse(Console.ReadLine());

                int[] searchResults = new int[256];
                int count = 0;

                if (searchMethod == 1)
                {
                    // Binary search the array for the user-defined value

                    static int BinarySearch(int[] road1, int SearchValue)
                    {
                        int left = 0;
                        int right = road1.Length - 1;

                        while (left <= right)
                        {
                            int mid = (left + right) / 2;

                            if (road1[mid] == SearchValue)
                            {
                                return mid;
                            }
                            else if (road1[mid] < SearchValue)
                            {
                                left = mid + 1;
                            }
                            else
                            {
                                right = mid - 1;
                            }
                        }

                        return -1;
                    }
                    int resultIndex = BinarySearch(int SearchValue);
                    // If value is found, record its location
                    if (resultIndex != -1)
                    {
                        searchResults[count] = resultIndex;
                        count++;

                        // Record any additional occurrences of the value
                        while (resultIndex < road1.Length - 1 && road1[resultIndex + 1] == searchValue)
                        {
                            resultIndex++;
                            searchResults[count] = resultIndex;
                            count++;
                        }

                        Console.WriteLine("Value found at index(es):");
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write("{0} ", searchResults[i]);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Value not found.");
                    }
                }
                else if (searchMethod == 2)
                {
                    // Linear search the array for the user-defined value
                    for (int i = 0; i < road1.Length; i++)
                    {
                        if (road1[i] == searchValue)
                        {
                            searchResults[count] = i;
                            count++;
                        }
                    }

                    if (count > 0)
                    {
                        Console.WriteLine("Value found at index(es):");
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write("{0} ", searchResults[i]);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Value not found.");
                    }
                }
            }
        }
    }
}


