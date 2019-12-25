using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindGrid();
            Clear();
        }


        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Student obj = new Student();
            obj.Id = int.Parse(textBoxId.Text);
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            obj.Name = firstName + " " + lastName;
            obj.Address = textBoxAddress.Text;
            obj.Email = textBoxEmail.Text;
            obj.BirthDate = dateTimePickerBirthDate.Value;
            obj.ContactNo = textBoxContactNo.Text;
            obj.Gender = comboBoxGender.SelectedItem.ToString();
            obj.Add(obj);
            BindGrid();
            Clear();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Student obj = new Student();
            if( e.ColumnIndex == 0)
            {
                string value = dataGridView[2, e.RowIndex].Value.ToString();
                int id = int.Parse(value);
                if(String.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Invalid Data");
                }
                else
                {
                    id = int.Parse(value);
                    Student s = obj.List().Where(x => x.Id == id).FirstOrDefault();
                    textBoxId.Text = s.Id.ToString();
                    textBoxFirstName.Text = s.Name.Split(' ')[0];
                    textBoxLastName.Text = s.Name.Split(' ')[1];
                    textBoxAddress.Text = s.Address;
                    textBoxEmail.Text = s.Email;
                    dateTimePickerBirthDate.Value = s.BirthDate;
                    textBoxContactNo.Text = s.ContactNo;
                    comboBoxGender.Text = s.Gender;
                    buttonSubmit.Visible = false;
                    buttonUpdate.Visible = true;
                }
            }
            else if (e.ColumnIndex == 1)
            {
                string value = dataGridView[2, e.RowIndex].Value.ToString();
                obj.Delete(int.Parse(value));
                BindGrid();
            }
        }

        public void BindGrid()
        {
            Student obj = new Student();
            List<Student> listStudents = obj.List();
            DataTable dt = Utility.ConvertToDataTable(listStudents);
            dataGridView.DataSource = dt;
            //BindChart(listStudents);
        }

        public void Clear()
        {
            textBoxId.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            textBoxContactNo.Text = "";
            comboBoxGender.SelectedItem = null;
            dateTimePickerBirthDate.Value = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student obj = new Student();
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            obj.Id = int.Parse(textBoxId.Text);
            obj.Name = firstName + " " + lastName;
            obj.Address = textBoxAddress.Text;
            obj.Email = textBoxEmail.Text;
            obj.BirthDate = dateTimePickerBirthDate.Value;
            obj.ContactNo = textBoxContactNo.Text;
            obj.Gender = comboBoxGender.SelectedItem.ToString();
            obj.Edit(obj);
            BindGrid();
            Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


        /**private void BindChart(List<Student> lst)
        {
            if( lst != null)
            {
                var result = lst.GroupBy(l => l.Gender)
                                .Select(cl => new
                                {
                                    Gender = cl.First().Gender,
                                    Count = cl.Count().ToString()
                                }).ToList();
                DataTable dt = Utility.ConvertToDataTable(result);
                chart1.DataSource = dt;
                chart1.Name = "Gender";
                chart1.Series["Series1"].XValueMember = "Gender";
                chart1.Series["Series1"].YValueMembers = "Count";
                this.chart1.Titles.Remove(this.chart1.Titles.FirstOrDefault());
                this.chart1.Titles.Add("Weekly Enrollment chart");
                chart1.Series["Series1"].IsValueShownAsLabel = true;
            }
        }*/
    }
}
