using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;
using System.Formats.Asn1;

namespace HopfieldNetwork
{
    public partial class Form1 : Form
    {

        private Matrix<float> inputMatrix;
        private Matrix<float> outputMatrix;

        private Matrix<float> weight = Matrix<float>.Build.DenseOfArray(new float[,]
            {
                { 0, 0, 2, -2, -2, -2, 2, 0, 2 },
                { 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                { 2, 0, 0, -2, -2, -2, 2, 0, 2 },
                { 2, 0, -2, 0, 2, 2, -2, 0 ,-2 },
                { 2, 0, -2, 2, 0, 2, -2, 0, -2 },
                { 2, 0, -2, 2, 2, 0, -2, 0, -2 },
                { 2, 0, 2, -2, -2, -2, 0, 0, -2},
                { 0, 2, 0, 0, 0, 0, 0, 0, 0},
                { 2, 0, 2, -2, -2, -2, 2, 0, 0 }
            });

        private int Rules(float num)
        {
            if (num > 0) return 1;
            return -1;
        }

        public Form1()
        {
            InitializeComponent();
            inputMatrix = Matrix<float>.Build.Dense(9, 1, -1);
            outputMatrix = Matrix<float>.Build.Dense(9, 1, -1);
        }
        public int boxClick(PictureBox pb) 
        {
            if(pb.BackColor == Color.Black)
            {
                pb.BackColor = Color.White;
                return -1;
            }
            else
            {
                pb.BackColor = Color.Black;
                return 1;
            }
        }

        public Color boxAssign(float num)
        {
            if ((int)num >= 1)
            {
                return Color.Black;
            }
            return Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            inputMatrix[0,0] = boxClick(pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            inputMatrix[1, 0] = boxClick(pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            inputMatrix[2, 0] =  boxClick(pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            inputMatrix[3, 0] = boxClick(pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            inputMatrix[4, 0] = boxClick(pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            inputMatrix[5, 0] = boxClick(pictureBox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            inputMatrix[6, 0] = boxClick(pictureBox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            inputMatrix[7, 0] = boxClick(pictureBox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            inputMatrix[8, 0] = boxClick(pictureBox9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            outputMatrix = weight.Multiply(inputMatrix);
            textBox1.Text = outputMatrix.ToString();
            textBox2.Text = inputMatrix.ToString();
            pictureBox11.BackColor = boxAssign(outputMatrix[0, 0]);
            pictureBox12.BackColor = boxAssign(outputMatrix[1, 0]);
            pictureBox13.BackColor = boxAssign(outputMatrix[2, 0]);
            pictureBox14.BackColor = boxAssign(outputMatrix[3, 0]);
            pictureBox15.BackColor = boxAssign(outputMatrix[4, 0]);
            pictureBox16.BackColor = boxAssign(outputMatrix[5, 0]);
            pictureBox17.BackColor = boxAssign(outputMatrix[6, 0]);
            pictureBox18.BackColor = boxAssign(outputMatrix[7, 0]);
            pictureBox19.BackColor = boxAssign(outputMatrix[8, 0]);
        }
    }
}