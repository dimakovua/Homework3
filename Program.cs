using System;
using System.Collections.Generic; //для списку
namespace democonsole
{    
   public class Pair<T, U> {    //Створив клас Пари, для зручності далі
    public Pair() {
    }

    public Pair(T first, U second) {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};
    abstract class Student //абстрактний клас
    {
        public Student(string name){ //конструктор встановлює ім'я студента та
            _name = name;           //порожній стейт
            _state = "";
        }
        public void Relax(){ //метод додає до стейту відпочинок
            _state += "Relax ";
        }
        public void Read(){ //додає до стейту читання
            _state += "Read ";
        }
        public void Write(){ //додає до стейту писання
            _state += "Write ";
        }
        public abstract void Study(); //абстрактний метод Study
        public string _name, _state; //ім'я та стейт
        public Pair<string, string> GetStudentInfo(){ //пара інформації про студента ім'я/стейт
            var pair = new Pair<string, string>(_name, _state);
            return pair;
        }
    }
    
    
    class GoodStudent : Student //клас, що успадковується від абстрактного класу
    {
        public GoodStudent(string name) //конструктор цього класу викликає базовий конструктор 
            :base(name){                //абстрактного класу та змінює значення стейт
            _state += "Good ";
        }
        override public void Study(){ //перепризначаємо абстрактний метод
            Read();
            Write();
            Read();
            Write();
            Relax();
        }
    }
    class BadStudent : Student //все те ж саме, що і в GoodStudent
    {
        public BadStudent(string name)
            :base(name){
            _state += "Bad ";
        }
        override public void Study(){
            Relax();
            Relax();
            Relax();
            Relax();
            Read();
        }
    }
    
    class Group //клас групи
    {
        private string _name; //назва групи
        List<Student> list = new List<Student>(); //список студентів групи
        public Group(string name){ //конструктор
            _name = name;
        }
        public void AddStudent(Student st){ //метод, що додає студента в групу
            list.Add(st);
        }
        public void AddGroup(Group gr){     //метод, що додає студентів 
            foreach (Student st in gr.list){//іншої групи в цю групу
                AddStudent (st);
            }
            gr.ClearGroup();
        }
        private string GetInfo(){ //генерує рядок з короткою інформацією про групу
            string info = "";
            info += _name +": ";
            foreach (var student in list){
                info += student.GetStudentInfo().First + " ";
            }
            return info;
        }
        private string GetFullInfo(){ //генерує рядок з повною інформацією
            string info = "";
            info += _name +": ";
            if(list.Count == 0){
                info = "Група порожня. Всі повтівкали(";
                return info;
            }
            foreach (var student in list){
                info += student.GetStudentInfo().First +": "+ student.GetStudentInfo().Second;
            }
            return info;
        }
        public void PrintInfo(){ //метод, що виводить коротку інформацію
            Console.WriteLine(this.GetInfo());
        }
        public void PrintFullInfo(){ //метод, що виводить повну інформацію
            Console.WriteLine(this.GetFullInfo());
        }
        public void ClearGroup(){
            list.Clear();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {   //перевірка. Створуюємо 4 студента
            GoodStudent a = new GoodStudent("a");
            BadStudent b = new BadStudent("b");
            GoodStudent aa = new GoodStudent("aa");
            BadStudent bb = new BadStudent("bb");
            Group K17 = new Group("K17"); //створюємо дві групи
            Group K18 = new Group("K18");
            K17.AddStudent(a); //Додаємо студентів в дві групи
            K17.AddStudent(aa);
            K18.AddStudent(b);
            K18.AddStudent(bb);
            Console.WriteLine("Коротка інформація про К17 до маніпуляцій:");
            K17.PrintInfo();
            Console.WriteLine("Коротка інформація про К18 до маніпуляцій:");
            K18.PrintInfo();
            K17.AddGroup(K18); //додаємо студентів групи К18 до групи К17
            a.Study(); //Студенти вчаться та змінюють значення стейтів
            b.Study();
            Console.WriteLine("Повна інформація про групу К17 після маніпуляцій:");
            K17.PrintFullInfo(); //виводимо повну інформацію про групу
            Console.WriteLine("Повна інформація про групу К18 після маніпуляцій:");
            K18.PrintFullInfo(); //виводимо багато інформації)
        }    
        
    }

}
