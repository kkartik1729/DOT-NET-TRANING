// class is the logical entity ,it defines the properity(data) and function that object we have 
// store value of similar data
// eg:- electronics,human being 

class Student
{
    public int rollno;
    public string name;
    public string institute;
    public long dob;
    public string branch;
    public char gender;
    public float hight;

    public void display()
    {
        Console.WriteLine(rollno + " \n" + name + " \n" + dob + " \n" + gender + " \n" + hight);
        Console.WriteLine("");
    }
}