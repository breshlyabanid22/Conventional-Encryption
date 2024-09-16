using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Activity1_ABANID
{
    public partial class Form1 : Form
    {
        private static readonly int Shift = 3;
        public Form1()
        {
            InitializeComponent();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            int[] temp = new int[fs.Length];
            for(int x = 0; x < fs.Length; x++)
            {
                temp[x] = fs.ReadByte();
            }
            fs.Close();
            for(int x = 0; x < temp.Length; x++)
            {
                temp[x] += 3;
            }
            fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            for(int x = 0; x < fs.Length; x++)
            {
                fs.WriteByte((byte)(temp[x]));
            }
            fs.Close();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            int[] temp = new int[fs.Length];
            for (int x = 0; x < fs.Length; x++)
            {
                temp[x] = fs.ReadByte();
            }
            fs.Close();
            for (int x = 0; x < temp.Length; x++)
            {
                temp[x] -= 3;
            }
            fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            for (int x = 0; x < fs.Length; x++)
            {
                fs.WriteByte((byte)(temp[x]));
            }
            fs.Close();
            MessageBox.Show("File decrypted using Ceasar cipher!");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        //Shift Cipher
        private void EncryptFileSubstitution(string filePath, int shift)
        {
            byte[] fileContent = File.ReadAllBytes(filePath);
            byte[] encryptedContent = SubstitutionEncryptDecrypt(fileContent, shift);
            File.WriteAllBytes(filePath, encryptedContent);
        }
        private void DecryptFileSubstitution(string filePath, int shift)
        {
            byte[] encryptedContent = File.ReadAllBytes(filePath);
            byte[] decryptedContent = SubstitutionEncryptDecrypt(encryptedContent, -shift);
            File.WriteAllBytes(filePath, decryptedContent);
        }

        private byte[] SubstitutionEncryptDecrypt(byte[] data, int shift)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] + shift);
            }
            return result;
        }
        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {

            string filePath = openFileDialog3.FileName;
            EncryptFileSubstitution(filePath, Shift);
            MessageBox.Show("File encrypted using Shift cipher!");

        }

        private void button4_Click(object sender, EventArgs e)  
        {
            openFileDialog4.ShowDialog();
        }

        private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog4.FileName;
            DecryptFileSubstitution(filePath, Shift);
            MessageBox.Show("File decrypted using Shift cipher!");

        }

    }

}
