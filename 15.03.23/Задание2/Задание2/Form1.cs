using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание2
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;

        private IList<Student> studentList = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }

        private void AddButton(object sender, EventArgs e)
        {
            AddStudent(studentName.Text, studentSurname.Text, studentNumber.Text);
        }

        //Создание и инициализация колонок
        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.AutoResizeColumns();
        }
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "" ;
                dataGridViewColumn1.HeaderText = "Имя" ;
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn1;
        }
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Фамилия";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn2;
        }
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Зачетка";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn3;
        }

        //Добавление студента
        private void AddStudent(string name, string surname, string recordBookNumber)
        {
            if (studentName.Text != "" && studentNumber.Text != "" && studentSurname.Text != "")
            {
                Student s = new Student(name, surname, recordBookNumber);
                studentList.Add(s);
                studentName.Text = "";
                studentSurname.Text = "";
                studentNumber.Text = "";
                ShowListInGrid();
            }
        }
        //Удаление студента с колекции
        private void DeleteStudent(int elementIndex)
        {
            studentList.RemoveAt(elementIndex);
            ShowListInGrid();
        }
        //Отображение колекции в таблице
        private void ShowListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Student s in studentList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new
                DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.Name;
                cell2.ValueType = typeof(string);
                cell2.Value = s.Surname;
                cell3.ValueType = typeof(string);
                cell3.Value = s.RecordBookNumber;
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                dataGridView1.Rows.Add(row);
            }
        }

        private void DeleteStudent(object sender, EventArgs e)
        {
            if (studentList.Count > 0)
            {
                int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
                DialogResult dr = MessageBox.Show("Удалить студента?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        DeleteStudent(selectedRow);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

    }
}
