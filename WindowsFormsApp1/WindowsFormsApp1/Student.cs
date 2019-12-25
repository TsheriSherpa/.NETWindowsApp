using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Student
    {
        private string _filePath = "student.json";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }

        public void Add(Student std)
        {

            Random r = new Random();
            std.Id = r.Next(1000, 9999);
            string data = JsonConvert.SerializeObject(std, Formatting.None);
            Utility.WriteToTextFile(_filePath, data);
            Utility.ReadFromTextFile(_filePath);
        }

        public Student Edit(int id)
        {
            Student obj = new Student();

            return obj;
        }

        public void Edit(Student std)
        {
            Console.WriteLine(std.Id);
            List<Student> list = List();
            Student s = list.Where(x => x.Id == std.Id).FirstOrDefault();
            list.Remove(s);
            list.Add(std);
            string data = JsonConvert.SerializeObject(list, Formatting.None);
            Utility.WriteToTextFile(_filePath, data, false);
        }

        public void Delete(int id)
        {
            List<Student> list = List();
            Student s = list.Where(x => x.Id == id).FirstOrDefault();
            list.Remove(s);
            string data = JsonConvert.SerializeObject(list, Formatting.None);
            Utility.WriteToTextFile(_filePath, data, false);

        }

        public Student Detail(Student std)
        {
            return std;
        }

        public List<Student> List()
        {
            string d = Utility.ReadFromTextFile(_filePath);
            if (d != null)
            {
                List<Student> lst = JsonConvert.DeserializeObject<List<Student>>(d);
                return lst;
            }

            return null;
        }

    }
}
