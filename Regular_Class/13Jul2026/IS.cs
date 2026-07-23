// I- interface segreation principle
// clints should not be forced to implement methods they do not 

interface Program
{
    void Work();
    void Walk();
    void eat();
}

class Human : Program
{
    public void work()
    {

    }

    public void walk()
    {

    }
    public void eat()
    {

    }
}

