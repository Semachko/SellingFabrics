using System.Drawing;
using System.Windows.Forms;

namespace CorrectInferface
{
    partial class PageObjectAdding
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.PictureBox();
            this.contactInfo = new System.Windows.Forms.TextBox();
            this.nazvaObject = new System.Windows.Forms.TextBox();
            this.bankAcc = new System.Windows.Forms.TextBox();
            this.adresa = new System.Windows.Forms.TextBox();
            this.inn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.typeObject = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 23F, System.Drawing.FontStyle.Bold);
            this.button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.Location = new System.Drawing.Point(40, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(458, 70);
            this.button2.TabIndex = 23;
            this.button2.Text = "Створити новий об\'єкт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16F);
            this.label6.Location = new System.Drawing.Point(395, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(322, 32);
            this.label6.TabIndex = 21;
            this.label6.Text = "Контактна інформація";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 26F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(32, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(957, 53);
            this.label1.TabIndex = 24;
            this.label1.Text = "Додання нового клієнта/експортера";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.BackButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 112);
            this.panel1.TabIndex = 25;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = global::CorrectInferface.Properties.Resources.backButton;
            this.BackButton.Location = new System.Drawing.Point(851, 17);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(80, 80);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackButton.TabIndex = 52;
            this.BackButton.TabStop = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click_1);
            // 
            // contactInfo
            // 
            this.contactInfo.Font = new System.Drawing.Font("Verdana", 16F);
            this.contactInfo.Location = new System.Drawing.Point(690, 280);
            this.contactInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contactInfo.Name = "contactInfo";
            this.contactInfo.Size = new System.Drawing.Size(200, 40);
            this.contactInfo.TabIndex = 26;
            // 
            // nazvaObject
            // 
            this.nazvaObject.Font = new System.Drawing.Font("Verdana", 16F);
            this.nazvaObject.Location = new System.Drawing.Point(690, 150);
            this.nazvaObject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nazvaObject.Name = "nazvaObject";
            this.nazvaObject.Size = new System.Drawing.Size(200, 40);
            this.nazvaObject.TabIndex = 27;
            // 
            // bankAcc
            // 
            this.bankAcc.Font = new System.Drawing.Font("Verdana", 16F);
            this.bankAcc.Location = new System.Drawing.Point(690, 215);
            this.bankAcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bankAcc.Name = "bankAcc";
            this.bankAcc.Size = new System.Drawing.Size(200, 40);
            this.bankAcc.TabIndex = 28;
            // 
            // adresa
            // 
            this.adresa.Font = new System.Drawing.Font("Verdana", 16F);
            this.adresa.Location = new System.Drawing.Point(197, 280);
            this.adresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adresa.Name = "adresa";
            this.adresa.Size = new System.Drawing.Size(170, 40);
            this.adresa.TabIndex = 29;
            // 
            // inn
            // 
            this.inn.Font = new System.Drawing.Font("Verdana", 16F);
            this.inn.Location = new System.Drawing.Point(197, 215);
            this.inn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inn.Name = "inn";
            this.inn.Size = new System.Drawing.Size(170, 40);
            this.inn.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 16F);
            this.label3.Location = new System.Drawing.Point(34, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 32);
            this.label3.TabIndex = 31;
            this.label3.Text = "Адреса";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 16F);
            this.label4.Location = new System.Drawing.Point(395, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(308, 32);
            this.label4.TabIndex = 32;
            this.label4.Text = "Банківський рахунок";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 16F);
            this.label5.Location = new System.Drawing.Point(395, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(291, 32);
            this.label5.TabIndex = 33;
            this.label5.Text = "Назва підприємства";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 16F);
            this.label7.Location = new System.Drawing.Point(34, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 32);
            this.label7.TabIndex = 34;
            this.label7.Text = "Тип об\'єкту";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 16F);
            this.label8.Location = new System.Drawing.Point(34, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 32);
            this.label8.TabIndex = 35;
            this.label8.Text = "ІНН";
            // 
            // typeObject
            // 
            this.typeObject.Font = new System.Drawing.Font("Verdana", 16F);
            this.typeObject.Location = new System.Drawing.Point(197, 150);
            this.typeObject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.typeObject.Name = "typeObject";
            this.typeObject.Size = new System.Drawing.Size(170, 40);
            this.typeObject.TabIndex = 36;
            // 
            // PageObjectAdding
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.typeObject);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inn);
            this.Controls.Add(this.adresa);
            this.Controls.Add(this.bankAcc);
            this.Controls.Add(this.nazvaObject);
            this.Controls.Add(this.contactInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Name = "PageObjectAdding";
            this.Size = new System.Drawing.Size(946, 468);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button2;
        private Label label6;
        private Label label1;
        private Panel panel1;
        private PictureBox BackButton;
        private TextBox contactInfo;
        private TextBox nazvaObject;
        private TextBox bankAcc;
        private TextBox adresa;
        private TextBox inn;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private TextBox typeObject;
    }
}
