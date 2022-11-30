namespace MisPis
{
    partial class ChooseType
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
            this.button_fullness = new System.Windows.Forms.Button();
            this.button_integrity = new System.Windows.Forms.Button();
            this.button_skill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_fullness
            // 
            this.button_fullness.Location = new System.Drawing.Point(168, 70);
            this.button_fullness.Name = "button_fullness";
            this.button_fullness.Size = new System.Drawing.Size(91, 23);
            this.button_fullness.TabIndex = 0;
            this.button_fullness.Text = "Полнота";
            this.button_fullness.UseVisualStyleBackColor = true;
            this.button_fullness.Click += new System.EventHandler(this.button_fullness_Click);
            // 
            // button_integrity
            // 
            this.button_integrity.Location = new System.Drawing.Point(168, 121);
            this.button_integrity.Name = "button_integrity";
            this.button_integrity.Size = new System.Drawing.Size(91, 23);
            this.button_integrity.TabIndex = 1;
            this.button_integrity.Text = "Целостность";
            this.button_integrity.UseVisualStyleBackColor = true;
            this.button_integrity.Click += new System.EventHandler(this.button_integrity_Click);
            // 
            // button_skill
            // 
            this.button_skill.Location = new System.Drawing.Point(168, 165);
            this.button_skill.Name = "button_skill";
            this.button_skill.Size = new System.Drawing.Size(91, 23);
            this.button_skill.TabIndex = 2;
            this.button_skill.Text = "Умение";
            this.button_skill.UseVisualStyleBackColor = true;
            this.button_skill.Click += new System.EventHandler(this.button_skill_Click);
            // 
            // ChooseType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 276);
            this.Controls.Add(this.button_skill);
            this.Controls.Add(this.button_integrity);
            this.Controls.Add(this.button_fullness);
            this.Name = "ChooseType";
            this.Text = "ChooseType";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_fullness;
        private System.Windows.Forms.Button button_integrity;
        private System.Windows.Forms.Button button_skill;
    }
}