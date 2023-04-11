using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ClassLibrary1;

namespace Измерительный_приборы
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;
        private DataGridViewColumn dataGridViewColumn5 = null;
        private DataGridViewColumn dataGridViewColumn6 = null;
        private DataGridViewColumn dataGridViewColumn7 = null;

        private List<Stock> items = new List<Stock>();
        
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
            inBox.Enabled = false;
            yesBox.Enabled = false;
            time.Enabled = true;
        }

        //Инициализация таблицы
        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.Columns.Add(getDataGridViewColumn4());
            dataGridView1.Columns.Add(getDataGridViewColumn5());
            dataGridView1.Columns.Add(getDataGridViewColumn6());
            dataGridView1.Columns.Add(getDataGridViewColumn7());
            dataGridView1.AutoResizeColumns();
        }
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Название";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 7;
            }
            return dataGridViewColumn1;
        }
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {                     
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Фирма";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 7;
            }
            return dataGridViewColumn2;
        }
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {                     
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Количество";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 7;
            }
            return dataGridViewColumn3;
        }
        private DataGridViewColumn getDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {                     
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Стоимость";
                dataGridViewColumn4.ValueType = typeof(string);
                dataGridViewColumn4.Width = dataGridView1.Width / 7;
            }
            return dataGridViewColumn4;
        }
        private DataGridViewColumn getDataGridViewColumn5()
        {
            if (dataGridViewColumn5 == null)
            {                     
                dataGridViewColumn5 = new DataGridViewTextBoxColumn();
                dataGridViewColumn5.Name = "";
                dataGridViewColumn5.HeaderText = "Срок годности";
                dataGridViewColumn5.ValueType = typeof(string);
                dataGridViewColumn5.Width = dataGridView1.Width / 7;
            }
            return dataGridViewColumn5;
        }
        private DataGridViewColumn getDataGridViewColumn6()
        {
            if (dataGridViewColumn6 == null)
            {                     
                dataGridViewColumn6 = new DataGridViewTextBoxColumn();
                dataGridViewColumn6.Name = "";
                dataGridViewColumn6.HeaderText = "Количество в коробке";
                dataGridViewColumn6.ValueType = typeof(string);
                dataGridViewColumn6.Width = dataGridView1.Width / 7;
            }
            return dataGridViewColumn6;
        }
        private DataGridViewColumn getDataGridViewColumn7()
        {
            if (dataGridViewColumn7 == null)
            {
                dataGridViewColumn7 = new DataGridViewTextBoxColumn();
                dataGridViewColumn7.Name = "";
                dataGridViewColumn7.HeaderText = "Хрупкость";
                dataGridViewColumn7.ValueType = typeof(string);
                dataGridViewColumn7.Width = dataGridView1.Width / 7;
                
            }
            return dataGridViewColumn7;
        }
        //Обработчики событий
        private void addObject_Click(object sender, EventArgs e)
        {
            try
            {
                if (Manuf.Checked)
                
                    AddManufactItem(name.Text, producer.Text, Int32.Parse(count.Text), double.Parse(price.Text), Int32.Parse(inBox.Text), yesBox.Checked);
                 
                 else AddGroceryItem(name.Text, producer.Text, Int32.Parse(count.Text), double.Parse(price.Text), Int32.Parse(time.Text));
            }
            catch { MessageBox.Show("Неверный ввод", "ОШИБКА"); }
        }
        private void DeleteItem(Stock el)
        {
            items.Remove(el);
            ShowListInGrid();
        }

        int sel;
        private void change_Click(object sender, EventArgs e)
        {
            if (change.Text=="Изменить" && sel!=-1)
            {
                if (items[sel] is Grocery && Manuf.Checked)
                    Grose.Checked = true;
                if (items[sel] is Manufactured && Grose.Checked)
                    Manuf.Checked = true;

                sel = dataGridView1.SelectedCells[0].RowIndex;
                change.Text = "Подтвердить";
                panel3.Enabled = false;
                panel4.Enabled = false;
                delete.Enabled = false;
                addObject.Enabled = false;
                dataGridView1.Enabled = false;
                button3.Enabled = false;
                name.Text = (string)dataGridView1[0,sel].Value;
                producer.Text = (string)dataGridView1[1, sel].Value;
                count.Text = dataGridView1[2, sel].Value.ToString();
                price.Text = dataGridView1[3, sel].Value.ToString();
                time.Text = (string)dataGridView1[4, sel].Value;
                inBox.Text = dataGridView1[5, sel].Value.ToString();
                
            }
            else if (name.Text != "" && producer.Text != "" && count.Text != "" && price.Text != "" && time.Text != "" && inBox.Text != "")
            {
                change.Text = "Изменить";
                delete.Enabled = true;
                addObject.Enabled = true;
                dataGridView1.Enabled = true;
                button3.Enabled =true;
                panel3.Enabled = true;
                panel4.Enabled = true;
                if (items[sel] is Grocery)
                {
                    items.RemoveAt(sel);
                    items.Insert(sel, new Grocery(name.Text, producer.Text, Int32.Parse(count.Text), double.Parse(price.Text), Int32.Parse(time.Text)));
                }
                else 
                {
                    items.RemoveAt(sel);
                    items.Insert(sel, new Manufactured(name.Text, producer.Text, Int32.Parse(count.Text), double.Parse(price.Text), Int32.Parse(inBox.Text), yesBox.Checked));
                }
                name.Text="";
                producer.Text="";
                count.Text="";
                price.Text="";
                time.Text="";
                inBox.Text="";
            }
            else MessageBox.Show("Пустые поля недопустимы");
            ShowListInGrid();
        }

        //Заполнение таблицы
        private void ShowListInGrid()
        {
            dataGridView1.Rows.Clear();
            if (allChoice.Checked)
            {
                ShowAll(items);
            }
            else if (grosChoice.Checked)
            {
                ShowAll(items.Where(i => i is Grocery));
                dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            else 
            { 
                ShowAll(items.Where(i => i is Manufactured));
                dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        //Функионал
        private void AddGroceryItem(string name, string producer, int count, double price, int time)
        {
            Grocery s = new Grocery(name, producer, count, price, time);
            items.Add(s);
            this.name.Text = "";
            this.producer.Text = "";
            this.count.Text = "";
            this.price.Text = "";
            this.time.Text = "";
            this.inBox.Text = "";
            ShowListInGrid();
        }
        private void AddManufactItem(string name, string producer, int count, double price, int countInBox, bool fragile)
        {
    
                Manufactured s = new Manufactured(name, producer, count, price, countInBox, fragile);
                items.Add(s);
                this.name.Text = "";
                this.producer.Text = "";
                this.count.Text = "";
                this.price.Text = "";
                this.time.Text = "";
                this.inBox.Text = "";
                ShowListInGrid();
        }
        private void ShowAll(IEnumerable<Stock> items)
        {
            dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (var item in items)
            {
                if (item is Grocery)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    DataGridViewTextBoxCell cell1 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell2 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell3 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell4 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell5 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell6 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell7 = new
                    DataGridViewTextBoxCell();
                    cell1.ValueType = typeof(string);
                    cell1.Value = item.Name;
                    cell2.ValueType = typeof(string);
                    cell2.Value = item.Provider;
                    cell3.ValueType = typeof(string);
                    cell3.Value = item.Count;
                    cell4.ValueType = typeof(string);
                    cell4.Value = item.Price;
                    cell5.ValueType = typeof(string);
                    cell5.Value = (item as Grocery).ExpiratioDate; 
                    cell6.ValueType = typeof(string);
                    cell6.Value = "*";
                    cell7.ValueType = typeof(string);
                    cell7.Value = "*";
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    row.Cells.Add(cell6);
                    row.Cells.Add(cell7);
                    dataGridView1.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.DefaultCellStyle.BackColor = Color.Red;
                    DataGridViewTextBoxCell cell1 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell2 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell3 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell4 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell5 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell6 = new
                    DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cell7 = new
                    DataGridViewTextBoxCell();
                    cell1.ValueType = typeof(string);
                    cell1.Value = item.Name;
                    cell2.ValueType = typeof(string);
                    cell2.Value = item.Provider;
                    cell3.ValueType = typeof(string);
                    cell3.Value = item.Count;
                    cell4.ValueType = typeof(string);
                    cell4.Value = item.Price;
                    cell5.ValueType = typeof(string);
                    cell5.Value = "*";
                    cell6.ValueType = typeof(string);
                    cell6.Value = (item as Manufactured).CountInBox;
                    cell7.ValueType = typeof(string);
                    cell7.Value = (item as Manufactured).Fragile;
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    row.Cells.Add(cell6);
                    row.Cells.Add(cell7);
                    dataGridView1.Rows.Add(row);
                }
            }
        }
        private void grosChoice_CheckedChanged(object sender, EventArgs e)
        {
            ShowListInGrid();
        }
        private void manuChoice_CheckedChanged(object sender, EventArgs e)
        {
            ShowListInGrid();
        }
        private void allChoice_CheckedChanged(object sender, EventArgs e)
        {
            ShowListInGrid();
        }
        private void delete_Click_1(object sender, EventArgs e)
        {
            
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить прибор?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    //if (dataGridView1.SelectedCells[6].Value.ToString() == "*")
                        DeleteItem(new Grocery(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), (int)dataGridView1.SelectedCells[2].Value, (double)dataGridView1.SelectedCells[3].Value, (int)dataGridView1.SelectedCells[4].Value) as Stock);
                    //else DeleteItem(new Manufactured(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), (int)dataGridView1.SelectedCells[2].Value, (double)dataGridView1.SelectedCells[3].Value, (int)dataGridView1.SelectedCells[5].Value, (bool)dataGridView1.SelectedCells[6].Value));
                }
                catch (Exception)
                {
                }
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            StreamWriter result = new StreamWriter("test.txt");
            foreach (var item in items)
            {
                result.WriteLine(item.GetInfo() + "\n");
            }
            result.Close();
        }
        private void Manuf_CheckedChanged(object sender, EventArgs e)
        {
            if (Manuf.Checked)
            {
                inBox.Enabled = true;
                yesBox.Enabled = true;
                time.Enabled = false;
            }
            else
            {
                inBox.Enabled = false;
                yesBox.Enabled = false;
                time.Enabled = true;
            }
        }
        private void Grose_CheckedChanged(object sender, EventArgs e)
        {
            if (Grose.Checked)
            {
                inBox.Enabled = false;
                yesBox.Enabled = false;
                time.Enabled = true;
            }
            else
            {
                inBox.Enabled = true;
                yesBox.Enabled = true;
                time.Enabled = false;
            }
        }
    }
}

