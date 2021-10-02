using System;
using System.Collections.Generic;
namespace democonsole
{    
   public class Pair<T, U> {
    public Pair() {
    }

    public Pair(T first, U second) {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};
    abstract class Student
    {
        public Student(string name){
            _name = name;
            _state = "";
        }
        public void Relax(){
            _state += "Relax ";
        }
        public void Read(){
            _state += "Read ";
        }
        public void Write(){
            _state += "Write ";
        }
        public abstract void Study();
        public string _name, _state;
        public Pair<string, string> GetStudentInfo(){
            var pair = new Pair<string, string>(_name, _state);
            return pair;
        }
    }
    
    
    class GoodStudent : Student
    {
        public GoodStudent(string name)
            :base(name){
            _state += "Good ";
        }
        override public void Study(){
            Read();
            Write();
            Read();
            Write();
            Relax();
        }
    }
    class BadStudent : Student
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
    
    class Group
    {
        private string _name;
        List<Student> list = new List<Student>();
        public Group(string name){
            _name = name;
        }
        public void AddStudent(Student st){
            list.Add(st);
        }
        public void AddGroup(Group gr){
            foreach (Student st in gr.list){
                AddStudent (st);
            }
        }
        private string GetInfo(){
            string info = "";
            info += _name +": ";
            foreach (var student in list){
                info += student.GetStudentInfo().First + " ";
            }
            return info;
        }
        private string GetFullInfo(){
            string info = "";
            info += _name +": ";
            foreach (var student in list){
                info += student.GetStudentInfo().First +": "+ student.GetStudentInfo().Second;
            }
            return info;
        }
        public void PrintInfo(){
            Console.WriteLine(this.GetInfo());
        }
        public void PrintFullInfo(){
            Console.WriteLine(this.GetFullInfo());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            GoodStudent a = new GoodStudent("a");
            BadStudent b = new BadStudent("b");
            GoodStudent aa = new GoodStudent("aa");
            BadStudent bb = new BadStudent("bb");
            Group K17 = new Group("K17");
            Group K18 = new Group("K18");
            K17.AddStudent(a);
            K17.AddStudent(aa);
            K18.AddStudent(b);
            K18.AddStudent(bb);
            K17.AddGroup(K18);
            a.Study();
            b.Study();
            K17.PrintFullInfo();
            K17.PrintInfo();
        }    
        
    }

}
