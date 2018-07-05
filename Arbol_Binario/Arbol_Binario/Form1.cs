using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol_Binario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Arbol arbol1 = new Arbol();
        Nodo persona = new Nodo();
        Image img;
        List<Nodo> ad = new List<Nodo>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Imagenes (*.jpg)|*.jpg";
            if (o.ShowDialog() == DialogResult.OK)
            {
                Image i = Image.FromFile(o.FileName);
                pictureBox1.Image = i;
                persona.Picture = i;
                img = i;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nombre;
            sbyte año;

            if (textBox1.Text == "" & textBox2.Text == "")
            {
                MessageBox.Show(" Hay Campos Vacios ");
            }
            else
            {
                nombre = textBox1.Text;
                año = Convert.ToSByte(textBox2.Text);
                arbol1.insertarNodo(nombre, año, persona.Picture);
                textBox1.Clear();
                textBox2.Clear();
                pictureBox1.Image = null;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string nombre;
            sbyte año;
            if (textBox1.Text == "" & textBox2.Text == "")
            {
                MessageBox.Show(" Hay Campos Vacios ");
            }
            else
            {
                nombre = textBox1.Text;
                año = Convert.ToSByte(textBox2.Text);
                arbol1.recorrer(nombre, año, persona.Picture);
                textBox1.Clear();
                textBox2.Clear();
                pictureBox1.Image = null;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string j = textBox3.Text;
            persona = arbol1.recorrerBuscar(j);
            if (persona != null)
            {
                textBox1.Text = persona.Name;
                textBox2.Text = Convert.ToString(persona.Age);
                pictureBox1.Image = persona.Picture;
                textBox3.Clear();
            }
            if (persona == null)
            {
                MessageBox.Show(" no se encontraron datos ");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show(" vacio ");
            }
            arbol1.recorrerElin(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = arbol1.recorrerInOrden();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = arbol1.recorrerPreOrden();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = arbol1.recorrerPostOrden();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
    }
}