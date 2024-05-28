namespace Oppgave_Studentadministrasjonssystem
{
    internal class Subject
    {
        public int _subjectCode;
        public string _subjectName;
        public int Credits { get; private set; }

        public Subject(string subjectName, int subjectCode, int credits)
        {
            _subjectCode = subjectCode;
            _subjectName = subjectName;
            Credits = credits;
        }

        public void PrintOutInfo()
        {
            Console.WriteLine($"\nFagnavn: {_subjectName}");
            Console.WriteLine($"Fagkode: {_subjectCode}");
            Console.WriteLine($"Antall Studiepoeng: {Credits}");
        }


    }
}
