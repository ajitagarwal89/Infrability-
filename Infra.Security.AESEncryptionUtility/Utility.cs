using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infra.Security.AESEncryptionLibrary;

namespace Infra.Security.AESEncryptionUtility
{
    public partial class Utility : Form
    {
        public Utility()
        {
            InitializeComponent();
        }

        private void Utility_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// this event is used to encrypt data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtEncryptedText.Text =  RidjindalEncryption.Encrypt(txtPlainText.Text);
        }
        /// <summary>
        /// this event is used to Dencrypt data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDecrypt_Click(object sender, EventArgs e)
        {
            txtDecryptedText.Text = RidjindalEncryption.Decrypt(txtEncryptedText.Text);
        }


    }
}
