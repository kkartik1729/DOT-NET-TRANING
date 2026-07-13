public class FeeCalculator
{
    public static double CalculateFee(StudentType type, int credits)
    {
        double fee = credits * 1000;

        switch (type)
        {
            case StudentType.Regular:
                return fee;

            case StudentType.Scholarship:
                return fee * 0.5;

            case StudentType.PartTime:
                return fee * 0.75;

            default:
                return fee;
        }
    }
}