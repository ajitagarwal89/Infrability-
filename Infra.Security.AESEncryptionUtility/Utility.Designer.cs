namespace Infra.Security.AESEncryptionUtility
{
    partial class Utility
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtDecryptedText = new System.Windows.Forms.TextBox();
            this.txtEncryptedText = new System.Windows.Forms.TextBox();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.lblDecryptedValue = new System.Windows.Forms.Label();
            this.lblEncryptedValue = new System.Windows.Forms.Label();
            this.lblPlainText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDecrypt
            // 
            this.txtDecrypt.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecrypt.Location = new System.Drawing.Point(617, 162);
            this.txtDecrypt.Name = "txtDecrypt";
            this.txtDecrypt.Size = new System.Drawing.Size(120, 32);
            this.txtDecrypt.TabIndex = 17;
            this.txtDecrypt.Text = "Decrypt";
            this.txtDecrypt.UseVisualStyleBackColor = true;
            this.txtDecrypt.Click += new System.EventHandler(this.txtDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(617, 63);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(120, 32);
            this.btnEncrypt.TabIndex = 16;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtDecryptedText
            // 
            this.txtDecryptedText.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecryptedText.Location = new System.Drawing.Point(174, 243);
            this.txtDecryptedText.Multiline = true;
            this.txtDecryptedText.Name = "txtDecryptedText";
            this.txtDecryptedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDecryptedText.Size = new System.Drawing.Size(414, 74);
            this.txtDecryptedText.TabIndex = 15;
            // 
            // txtEncryptedText
            // 
            this.txtEncryptedText.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncryptedText.Location = new System.Drawing.Point(174, 141);
            this.txtEncryptedText.Multiline = true;
            this.txtEncryptedText.Name = "txtEncryptedText";
            this.txtEncryptedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEncryptedText.Size = new System.Drawing.Size(414, 74);
            this.txtEncryptedText.TabIndex = 14;
            // 
            // txtPlainText
            // 
            this.txtPlainText.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlainText.Location = new System.Drawing.Point(174, 42);
            this.txtPlainText.Multiline = true;
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlainText.Size = new System.Drawing.Size(414, 74);
            this.txtPlainText.TabIndex = 13;
            // 
            // lblDecryptedValue
            // 
            this.lblDecryptedValue.AutoSize = true;
            this.lblDecryptedValue.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecryptedValue.Location = new System.Drawing.Point(16, 270);
            this.lblDecryptedValue.Name = "lblDecryptedValue";
            this.lblDecryptedValue.Size = new System.Drawing.Size(130, 20);
            this.lblDecryptedValue.TabIndex = 12;
            this.lblDecryptedValue.Text = "Decrypted Text:";
            // 
            // lblEncryptedValue
            // 
            this.lblEncryptedValue.AutoSize = true;
            this.lblEncryptedValue.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncryptedValue.Location = new System.Drawing.Point(16, 168);
            this.lblEncryptedValue.Name = "lblEncryptedValue";
            this.lblEncryptedValue.Size = new System.Drawing.Size(130, 20);
            this.lblEncryptedValue.TabIndex = 11;
            this.lblEncryptedValue.Text = "Encrypted Text:";
            // 
            // lblPlainText
            // 
            this.lblPlainText.AutoSize = true;
            this.lblPlainText.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlainText.Location = new System.Drawing.Point(16, 69);
            this.lblPlainText.Name = "lblPlainText";
            this.lblPlainText.Size = new System.Drawing.Size(137, 20);
            this.lblPlainText.TabIndex = 10;
            this.lblPlainText.Text = "Enter Plain Text:";
            // 
            // Utility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 371);
            this.Controls.Add(this.txtDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtDecryptedText);
            this.Controls.Add(this.txtEncryptedText);
            this.Controls.Add(this.txtPlainText);
            this.Controls.Add(this.lblDecryptedValue);
            this.Controls.Add(this.lblEncryptedValue);
            this.Controls.Add(this.lblPlainText);
            this.MinimizeBox = false;
            this.Name = "Utility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryption";
            this.Load += new System.EventHandler(this.Utility_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button txtDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtDecryptedText;
        private System.Windows.Forms.TextBox txtEncryptedText;
        private System.Windows.Forms.TextBox txtPlainText;
        private System.Windows.Forms.Label lblDecryptedValue;
        private System.Windows.Forms.Label lblEncryptedValue;
        private System.Windows.Forms.Label lblPlainText;
    }
}