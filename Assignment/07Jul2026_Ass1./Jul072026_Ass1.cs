using System;

class Jul072026_Ass1
{
    public void conveyor()
    {
        int totalPackages = 0;
        int priorityCheck = 0;
        int normalProcessing = 0;
        int qualityCheck = 0;

        for (int packagesID = 1001; packagesID <= 1020; packagesID++)
        {
            totalPackages++;

            if (packagesID % 4 == 0)
            {
                Console.WriteLine("the Package " + packagesID + " Quality Check Required.");
                qualityCheck++;
            }

            else if (packagesID % 5 == 0)
            {
                Console.WriteLine("the Package " + packagesID + " is an Priority Shipment.");
                priorityCheck++;
            }

            else
            {
                Console.WriteLine("the Package " + packagesID + " is an Normal Processing.");
                normalProcessing++;
            }

        }
        Console.WriteLine("\nSummary");
        Console.WriteLine("Total packages processed: " + totalPackages);
        Console.WriteLine("Number of packages requiring quality check: " + qualityCheck);
        Console.WriteLine("Number of priority shipments: " + priorityCheck);
        Console.WriteLine("Number of normal packages: " + normalProcessing);
    }
}