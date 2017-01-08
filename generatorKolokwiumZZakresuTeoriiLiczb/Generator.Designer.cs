namespace generatorKolokwiumZZakresuTeoriiLiczb
{
    partial class Generator
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
            this.Generate = new System.Windows.Forms.Button();
            this.ExercisesList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(13, 204);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(131, 31);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "Generuj";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // ExercisesList
            // 
            this.ExercisesList.FormattingEnabled = true;
            this.ExercisesList.Location = new System.Drawing.Point(0, 0);
            this.ExercisesList.Name = "ExercisesList";
            this.ExercisesList.Size = new System.Drawing.Size(193, 184);
            this.ExercisesList.TabIndex = 1;
            this.ExercisesList.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ExercisesList);
            this.Controls.Add(this.Generate);
            this.Name = "Generator";
            this.Text = "Generator";
            this.Load += new System.EventHandler(this.Generator_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.CheckedListBox ExercisesList;
    }
}

