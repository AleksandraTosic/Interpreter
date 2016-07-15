namespace Interpreter
{
    partial class Form1
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
            this.upBut = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.scintilla = new ScintillaNET.Scintilla();
            this.SuspendLayout();
            // 
            // upBut
            // 
            this.upBut.Location = new System.Drawing.Point(724, 305);
            this.upBut.Name = "upBut";
            this.upBut.Size = new System.Drawing.Size(75, 23);
            this.upBut.TabIndex = 1;
            this.upBut.Text = "Upload";
            this.upBut.UseVisualStyleBackColor = true;
            this.upBut.Click += new System.EventHandler(this.upBut_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // scintilla
            // 
            this.scintilla.Location = new System.Drawing.Point(12, 12);
            this.scintilla.Name = "scintilla";
            this.scintilla.Size = new System.Drawing.Size(706, 586);
            this.scintilla.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 610);
            this.Controls.Add(this.scintilla);
            this.Controls.Add(this.upBut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button upBut;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private ScintillaNET.Scintilla scintilla;
    }
}

