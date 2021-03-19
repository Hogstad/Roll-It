namespace RollIT
{
    public class Person
    {
        public int Id;
        public int Modul;
        public string FirstName;
        public string LastName;
    public string GetDescription()
        {
        string description = "";
        if (Modul != 0) description += ("Modul: " + Modul + " ");
        if (Id != 0) description += ("(Nummer=" + Id  + ") ");
        if (FirstName != null) description += (FirstName + " ");
        if (LastName != null) description += (LastName);
        string descriptionTrimmed = description.Trim();
        return descriptionTrimmed;
        }
    }
}
