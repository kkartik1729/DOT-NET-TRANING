//object is the physical entity ,uses class properties and function 

using System;

class ClassObjectEG
{
    static void Main()
    {

        Student s = new Student();
        s.rollno = 49;
        s.name = "Kartik";
        s.dob = 12092006;
        s.gender = 'M';
        s.hight = 5.6f;
        s.institute = "SSGMCE";
        s.branch = "cs";

        s.display();
    }

}