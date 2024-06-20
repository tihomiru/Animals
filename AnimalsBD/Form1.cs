using AnimalsBD.Controller;
using AnimalsBD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnimalsBD
{
    public partial class Form1 : Form
    {
        AnimalsController animalsController = new AnimalsController();
        BreedsController breedsController = new BreedsController();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Animal animal)
        {
            txtbox.BackColor = Color.White;
            txtbox.Text = animal.Id.ToString();
            txtbox2.Text = animal.Name;
            txtbox3.Text = animal.Age.ToString();
            cmb.Text = animal.Breeds.Name;
        }
        private void ClearScreen()
        {
            txtbox.BackColor = Color.White;
            txtbox.Clear();
            txtbox2.Clear();
            txtbox3.Clear();
            cmb.Text = " ";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbox2.Text) || txtbox2.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txtbox2.Focus();
                return;
            }
            Animal newAnimal = new Animal();
            newAnimal.Age = int.Parse(txtbox3.Text);
            newAnimal.Name = txtbox2.Text;
             newAnimal.BreedsId = (int)cmb.SelectedValue;


            animalsController.Create(newAnimal);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            btnSA_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Breed> allBreeds = breedsController.GetAllBreeds();
            cmb.DataSource = allBreeds;
            cmb.DisplayMember = "Name";
            cmb.ValueMember = "Id";

            btnSA_Click(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtbox.Text) || !txtbox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ID за търсене!");
                txtbox.BackColor = Color.Red;
                txtbox.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtbox.Text);
            }
            Animal findedAnimal = animalsController.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪЕ ЗАПИС В БД!!! \n Въведете ID за търсене");
                txtbox.BackColor = Color.Red;
                txtbox.Focus();
                return;
            }
            LoadRecord(findedAnimal);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtbox.Text) || !txtbox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене");
                txtbox.BackColor = Color.Red;
                txtbox.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtbox.Text);
            }
            if (string.IsNullOrEmpty(txtbox2.Text))
            {
                Animal findedAnimal = animalsController.Get(findId);
                if (findedAnimal == null)
                {
                    MessageBox.Show("НЯМА ТАКЪЕ ЗАПИС В БД!!! \n Въведете ID за търсене");
                    txtbox.BackColor = Color.Red;
                    txtbox.Focus();
                    return;
                }
                LoadRecord(findedAnimal);
            }
            else
            {
                Animal updatedAnimal = new Animal();
                updatedAnimal.Name = txtbox2.Text;
                updatedAnimal.Age = int.Parse(txtbox3.Text);
                updatedAnimal.BreedsId = (int)cmb.SelectedValue;

                animalsController.Update(findId, updatedAnimal);
            }
            btnSA_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtbox.Text))
            {
                MessageBox.Show("Въведете Id за търсене");
                txtbox.BackColor = Color.Red;
                txtbox.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtbox.Text);
            }
            Animal findedAnimal = animalsController.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪЕ ЗАПИС В БД!!! \n Въведете ID за търсене");
                txtbox.BackColor = Color.Red;
                txtbox.Focus();
                return;
            }
            LoadRecord(findedAnimal);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтрието запис " + findId + "?",
                "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                animalsController.Delete(findId);
            }
            btnSA_Click(sender, e);
        }

        private void btnSA_Click(object sender, EventArgs e)
        {
            List<Animal> allAnimals = animalsController.GetAll();
            lb.Items.Clear();
            foreach (var item in allAnimals)
            {
                lb.Items.Add($"Id-то {item.Id}. Казва се {item.Name}! На {item.Age} Години и " +
                    $" Породата му е {item.Breeds.Name}");
            }
        }

        private void pcb_Click(object sender, EventArgs e)
        {

        }
    }
}
