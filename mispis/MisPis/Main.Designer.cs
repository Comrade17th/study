namespace MisPis
{
    partial class Main
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
            this.button_approximation = new System.Windows.Forms.Button();
            this.button_interpolation = new System.Windows.Forms.Button();
            this.button_poly = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_approximation
            // 
            this.button_approximation.Location = new System.Drawing.Point(119, 82);
            this.button_approximation.Name = "button_approximation";
            this.button_approximation.Size = new System.Drawing.Size(115, 23);
            this.button_approximation.TabIndex = 0;
            this.button_approximation.Text = "Апроксимация";
            this.button_approximation.UseVisualStyleBackColor = true;
            this.button_approximation.Click += new System.EventHandler(this.button_approximation_Click);
            // 
            // button_interpolation
            // 
            this.button_interpolation.Location = new System.Drawing.Point(119, 129);
            this.button_interpolation.Name = "button_interpolation";
            this.button_interpolation.Size = new System.Drawing.Size(115, 23);
            this.button_interpolation.TabIndex = 1;
            this.button_interpolation.Text = "Интерполяция";
            this.button_interpolation.UseVisualStyleBackColor = true;
            this.button_interpolation.Click += new System.EventHandler(this.button_interpolation_Click);
            // 
            // button_poly
            // 
            this.button_poly.Location = new System.Drawing.Point(119, 197);
            this.button_poly.Name = "button_poly";
            this.button_poly.Size = new System.Drawing.Size(115, 23);
            this.button_poly.TabIndex = 2;
            this.button_poly.Text = "Полиномы";
            this.button_poly.UseVisualStyleBackColor = true;
            this.button_poly.Click += new System.EventHandler(this.button_poly_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Решение алгебраических и трансцендентных урванений";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Интерполяционные полиномы";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 312);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_poly);
            this.Controls.Add(this.button_interpolation);
            this.Controls.Add(this.button_approximation);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_approximation;
        private System.Windows.Forms.Button button_interpolation;
        private System.Windows.Forms.Button button_poly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}