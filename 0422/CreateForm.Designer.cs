namespace _0422
{
    partial class CreateForm
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
            this.components = new System.ComponentModel.Container();
            this.Number = new System.Windows.Forms.TextBox();
            this.liteDatabaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.liteDatabaseBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Document = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Organization = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DateDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AddRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.liteDatabaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liteDatabaseBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // Number
            // 
            this.Number.AcceptsReturn = true;
            this.Number.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Number.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Number.Location = new System.Drawing.Point(171, 56);
            this.Number.Name = "Number";
            this.Number.PlaceholderText = "Номер";
            this.Number.Size = new System.Drawing.Size(100, 23);
            this.Number.TabIndex = 0;
            this.Number.Text = "Номер";
            // 
            // liteDatabaseBindingSource
            // 
            this.liteDatabaseBindingSource.DataSource = typeof(LiteDB.LiteDatabase);
            // 
            // liteDatabaseBindingSource1
            // 
            this.liteDatabaseBindingSource1.DataSource = typeof(LiteDB.LiteDatabase);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Номер (Number):";
            // 
            // Document
            // 
            this.Document.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Document.Location = new System.Drawing.Point(171, 103);
            this.Document.Name = "Document";
            this.Document.Size = new System.Drawing.Size(100, 23);
            this.Document.TabIndex = 3;
            this.Document.Text = "Документ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Документ (Document):";
            // 
            // Organization
            // 
            this.Organization.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Organization.Location = new System.Drawing.Point(171, 146);
            this.Organization.Name = "Organization";
            this.Organization.Size = new System.Drawing.Size(100, 23);
            this.Organization.TabIndex = 5;
            this.Organization.Text = "Организация";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Организация (Organization):";
            // 
            // DateDay
            // 
            this.DateDay.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.DateDay.Location = new System.Drawing.Point(171, 193);
            this.DateDay.Name = "DateDay";
            this.DateDay.Size = new System.Drawing.Size(100, 23);
            this.DateDay.TabIndex = 7;
            this.DateDay.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Дата (DateDay):";
            // 
            // AddRecord
            // 
            this.AddRecord.ForeColor = System.Drawing.Color.Navy;
            this.AddRecord.Location = new System.Drawing.Point(21, 230);
            this.AddRecord.Name = "AddRecord";
            this.AddRecord.Size = new System.Drawing.Size(165, 29);
            this.AddRecord.TabIndex = 9;
            this.AddRecord.Text = "Добавить запись";
            this.AddRecord.UseVisualStyleBackColor = true;
            this.AddRecord.Click += new System.EventHandler(this.AddRecord_Click);
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.AddRecord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DateDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Organization);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Document);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Number);
            this.Name = "CreateForm";
            this.Text = "CreateForm";
            this.Load += new System.EventHandler(this.CreateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.liteDatabaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liteDatabaseBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Number;
        private BindingSource liteDatabaseBindingSource;
        private BindingSource liteDatabaseBindingSource1;
        private Label label1;
        private TextBox Document;
        private Label label2;
        private TextBox Organization;
        private Label label3;
        private TextBox DateDay;
        private Label label4;
        private Button AddRecord;
    }
}