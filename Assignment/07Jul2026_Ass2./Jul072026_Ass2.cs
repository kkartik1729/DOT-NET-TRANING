using System;

class Jul072026_Ass2
{
    public void StreetLights()
    {
        int totalPower = 0;
        int maintenance = 0;
        int normal = 0;
        int efficient = 0;

        for (int lightNo = 1; lightNo <= 30; lightNo++)
        {
            int power = 80 + (lightNo * 5);
            totalPower += power;

            if (power > 180)
            {
                Console.WriteLine("Light " + lightNo + " : " + power + " W - Maintenance Required");
                maintenance++;
            }
            else if (power >= 140 && power <= 180)
            {
                Console.WriteLine("Light " + lightNo + " : " + power + " W - Normal Operation");
                normal++;
            }
            else
            {
                Console.WriteLine("Light " + lightNo + " : " + power + " W - Energy Efficient");
                efficient++;
            }
        }

        double averagePower = (double)totalPower / 30;

        Console.WriteLine("\nSummary");
        Console.WriteLine("Total Power Consumed : " + totalPower + " W");
        Console.WriteLine("Average Power Consumption : " + averagePower + " W");
        Console.WriteLine("Maintenance Required : " + maintenance);
        Console.WriteLine("Normal Operation : " + normal);
        Console.WriteLine("Energy Efficient : " + efficient);
    }
}