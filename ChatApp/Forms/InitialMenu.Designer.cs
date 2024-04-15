namespace ChatApp
{
    partial class InitialMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            NameTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 196);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(134, 193);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(447, 23);
            NameTextBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(587, 192);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Conectar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // InitialMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(NameTextBox);
            Controls.Add(label1);
            Name = "InitialMenu";
            Text = "InitialForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox NameTextBox;
        private Button button1;
    }
}
